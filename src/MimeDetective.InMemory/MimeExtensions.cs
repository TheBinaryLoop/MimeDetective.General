using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace MimeDetective.InMemory
{
    public static class MimeExtensions
    {
        private static readonly FileType DefaultFallback = new FileType(null, "application/octet-stream");

        public static FileType DetectMimeType(this Stream stream)
        {
            var maxLengthToAnalyze = MimeTypes.AllTypes
                .SelectMany(x => x.Signatures)
                .Max(x => x.Offset + x.SignatureBytes.Length);

            var data = new byte[maxLengthToAnalyze];
            stream.Read(data, 0, data.Length);
            stream.Position = 0;

            return DetectMimeType(data);
        }

        public static FileType DetectMimeType(this byte[] file)
        {
            var comparer = new IgnoreNullComparer();

            var result = MimeTypes.AllTypes
                .OrderByDescending(t => t.Signatures.Length)
                .ThenByDescending(t => t.Signatures.Sum(s => s.SignatureBytes.Length))
                .FirstOrDefault(t => t.Signatures.All(s => s.SignatureBytes.SequenceEqual(GetSignature(file, s), comparer)));

            if (result == null)
                return DefaultFallback;

            if (result.Equals(MimeTypes.MCF))
            {
                return CheckForMsOldOfficeTypes(file) ?? DefaultFallback;
            }

            if (!result.Equals(MimeTypes.ZIP))
                return result;

            using (var ms = new MemoryStream(file))
            {
                return CheckForMsOfficeTypes(ms) ?? MimeTypes.ZIP;
            }
        }

        private static FileType CheckForMsOfficeTypes(Stream zip)
        {
            try
            {
                using (var zipFile = new ZipArchive(zip)) 
                {
                    if (zipFile.Entries.Any(e => e.FullName.StartsWith("word/")))
                        return MimeTypes.WORDX;

                    if (zipFile.Entries.Any(e => e.FullName.StartsWith("xl/")))
                        return MimeTypes.EXCELX;

                    if (zipFile.Entries.Any(e => e.FullName.StartsWith("ppt/")))
                        return MimeTypes.PPTX;

                    if (zipFile.Entries.Any(e => e.FullName.StartsWith("visio/")))
                        return MimeTypes.VSDX;

                    return CheckForMimeTypeFile(zipFile);
                }
            }
            catch (InvalidDataException)
            {
                return null;  //ZIP archive can be corrupted
            }

        }

        private static FileType CheckForMimeTypeFile(ZipArchive zipFile)
        {
            var ooMimeType = zipFile.Entries.FirstOrDefault(e => e.FullName == "mimetype");
            if (ooMimeType == null || ooMimeType.Length > 127) //zip bomb protection
                return CheckForOtherTypes(zipFile);

            using (var textReader = new StreamReader(ooMimeType.Open()))
            {
                var mimeType = textReader.ReadToEnd();

                if (mimeType == MimeTypes.ODT.Mime)
                    return MimeTypes.ODT;

                if (mimeType == MimeTypes.ODS.Mime)
                    return MimeTypes.ODS;

                if (mimeType == MimeTypes.EPUB.Mime)
                    return MimeTypes.EPUB;
            }

            return null;
        }

        private static FileType CheckForOtherTypes(ZipArchive zipFile)
        {
            if (zipFile.Entries.Any(x => x.Name.EndsWith(".nuspec")))
                return MimeTypes.NUPKG;

            if (zipFile.Entries.Any(x => x.FullName.Contains("META-INF/")))
                return MimeTypes.JAR;
            
            return null;
        }

        private static FileType CheckForMsOldOfficeTypes(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(stream, Encoding.Unicode, true))
                {
                    // Get sector size (2 byte uint) at offset 30 in the header
                    // Value at 1C specifies this as the power of two. The only valid values are 9 or 12, which gives 512 or 4096 byte sector size.
                    stream.Position = 30;
                    var sectorSize = 1 << reader.ReadUInt16();

                    // Get first directory sector index at offset 48 in the header
                    stream.Position = 48;
                    var rootDirectoryIndex = reader.ReadUInt32();

                    // File header is one sector wide. After that we can address the sector directly using the sector index
                    var rootDirectoryAddress = sectorSize + (rootDirectoryIndex * sectorSize);

                    // Object type field is offset 80 bytes into the directory sector. It is a 128 bit GUID, encoded as "DWORD, WORD, WORD, BYTE[8]".
                    stream.Position = rootDirectoryAddress + 80;
                    var bits127_96 = reader.ReadInt32();
                    var bits95_80 = reader.ReadInt16();
                    var bits79_64 = reader.ReadInt16();
                    var bits63_0 = reader.ReadBytes(8);

                    var guid = new Guid(bits127_96, bits95_80, bits79_64, bits63_0);

                    // Compare to known file format GUIDs
                    if (guid.Equals(new Guid("{00020810-0000-0000-c000-000000000046}")) ||
                        guid.Equals(new Guid("{00020820-0000-0000-c000-000000000046}")))
                    {
                        return MimeTypes.EXCEL;
                    }

                    if (guid.Equals(new Guid("{00020906-0000-0000-c000-000000000046}")))
                    {
                        return MimeTypes.WORD;
                    }

                    if (guid.Equals(new Guid("{64818d10-4f9b-11cf-86ea-00aa00b929e8}")))
                    {
                        return MimeTypes.PPT;
                    }

                    if (guid.Equals(new Guid("{00020d0b-0000-0000-c000-000000000046}")) ||
                        guid.Equals(new Guid("{0006f046-0000-0000-c000-000000000046}")))
                    {
                        return MimeTypes.MSG;
                    }

                    return null;
                }
            }
        }

        private static byte?[] GetSignature(byte[] data, FileSignature signature)
        {
            return data
                .Skip(signature.Offset)
                .Take(signature.SignatureBytes.Length)
                .Cast<byte?>()
                .ToArray();
        }

        private class IgnoreNullComparer : IEqualityComparer<byte?>
        {
            public int GetHashCode(byte? obj) => obj.HasValue ? obj.GetHashCode() : 0;

            public bool Equals(byte? x, byte? y) => !x.HasValue || !y.HasValue || x == y;
        }
    }
}
