using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MimeDetective.InMemory.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var file in Directory.GetFiles(@"C:\Python39", string.Empty, SearchOption.AllDirectories))
            {
                if (!File.Exists(file)) continue;
                using var fsIn = File.OpenRead(file);
                Console.WriteLine($"{file} | {fsIn.DetectMimeType()?.Mime}");
            }

            //using (var fsIn = File.OpenRead(@"C:\Users\l.essmann\Downloads\visualization_-_aerial.dwg"))
            //{
            //    Console.WriteLine(fsIn.DetectMimeType().Description);
            //}

            //Console.WriteLine($"Generate thumbnail: {(GetPreviewForCadDwg(0, 0, @"C:\Users\l.essmann\Downloads\visualization_-_aerial.dwg", "") ? "Success" : "Failed")}");

        }

        public static bool GetPreviewForCadDwg(int width, int height, string inputPath, string outputPath)
        {
            var tmpPath = Path.GetTempFileName();
            try
            {
                var fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var br = new BinaryReader(fs);
                br.BaseStream.Seek(0x0D, SeekOrigin.Begin);
                var imgPos = br.ReadInt32();
                br.BaseStream.Seek(imgPos, SeekOrigin.Begin);
                byte[] imgBSentinel = { 0x1F, 0x25, 0x6D, 0x07, 0xD4, 0x36, 0x28, 0x28, 0x9D, 0x57, 0xCA, 0x3F, 0x9D, 0x44, 0x10, 0x2B };
                var imgCSentinel = new byte[16];
                imgCSentinel = br.ReadBytes(16);

                if (imgBSentinel.ToString() == imgCSentinel.ToString())
                {
                    var imgSize = br.ReadUInt32();
                    //Get number of images present
                    var imgPresent = br.ReadByte();
                    // header
                    var imgHeaderStart = 0;
                    var imgHeaderSize = 0;
                    // bmp data
                    var imgBmpStart = 0;
                    var imgBmpSize = 0;
                    var bmpDataPresent = false;
                    // wmf data
                    var imgWmfStart = 0;
                    var imgWmfSize = 0;
                    //bool wmfDataPresent = false;

                    //get each image present
                    for (var I = 0; I <= imgPresent; I++)
                    {
                        if (bmpDataPresent) continue;
                        // Get image type
                        var imgCode = br.ReadByte();
                        switch (imgCode)
                        {
                            case 1:
                                // Header data
                                imgHeaderStart = br.ReadInt32();
                                imgHeaderSize = br.ReadInt32();
                                break;
                            case 2:
                                // bmp data
                                imgBmpStart = br.ReadInt32();
                                imgBmpSize = br.ReadInt32();
                                bmpDataPresent = true;
                                break;
                            case 3:
                                //wmf data
                                imgWmfStart = br.ReadInt32();
                                imgWmfSize = br.ReadInt32();
                                //wmfDataPresent = true;
                                break;
                        }
                    }
                    if (bmpDataPresent)
                    {
                        br.BaseStream.Seek(imgBmpStart, SeekOrigin.Begin);
                        var tempPixelData = new byte[imgBmpSize + 14];

                        // indicate it is a bit map
                        tempPixelData[0] = 0x42;
                        tempPixelData[1] = 0x4D;

                        //offBits
                        tempPixelData[10] = 0x36;
                        tempPixelData[11] = 0x04;

                        var tempBuffData = new byte[imgBmpSize];
                        tempBuffData = br.ReadBytes(imgBmpSize);
                        tempBuffData.CopyTo(tempPixelData, 14);

                        var memStream = new MemoryStream(tempPixelData);
                        var bmp = new Bitmap(memStream);
                        bmp.Save(tmpPath, ImageFormat.Png);
                        //TODO: Resize
                        return true;
                    }
                }

                //using (var fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                //{
                //    using (var binaryReader = new BinaryReader(fileStream))
                //    {
                //        fileStream.Seek(0xd, SeekOrigin.Begin);
                //        fileStream.Seek(0x14 + binaryReader.ReadInt32(), SeekOrigin.Begin);

                //        var byteCount = binaryReader.ReadByte();
                //        if (byteCount <= 1)
                //        {
                //            return false;
                //        }

                //        for (short i = 1; i <= byteCount; i++)
                //        {
                //            var imageCode = binaryReader.ReadByte();
                //            var imageHeaderStart = binaryReader.ReadInt32();
                //            var imageHeaderSize = binaryReader.ReadInt32();
                //            //var outms = new MemoryStream();

                //            switch (imageCode)
                //            {
                //                case 1: // Raw
                //                {
                //                    break;
                //                }
                //                case 2: // BMP

                //                    #region BMP Preview (2010 file format and lower)

                //                    // BITMAPINFOHEADER (40 bytes)
                //                    binaryReader.ReadBytes(0xe);
                //                    var biBitCount = binaryReader.ReadUInt16();
                //                    binaryReader.ReadBytes(4);
                //                    var biSizeImage = binaryReader.ReadUInt32();
                //                    //-----------------------------------------------------
                //                    fileStream.Seek(imageHeaderStart, SeekOrigin.Begin);
                //                    var bitmapBuffer = binaryReader.ReadBytes(imageHeaderSize);
                //                    var colorTableSize =
                //                        Convert.ToUInt32(
                //                            Math.Truncate((biBitCount < 9) ? 4 * Math.Pow(2, biBitCount) : 0));
                //                    using (var fsOut = new FileStream(tmpPath, FileMode.Create))
                //                    {
                //                        using (var binaryWriter = new BinaryWriter(fsOut))
                //                        {
                //                            binaryWriter.Write(Convert.ToUInt16(0x4d42));
                //                            binaryWriter.Write(54u + colorTableSize + biSizeImage);
                //                            binaryWriter.Write(new ushort());
                //                            binaryWriter.Write(new ushort());
                //                            binaryWriter.Write(54u + colorTableSize);
                //                            binaryWriter.Write(bitmapBuffer);

                //                            using (var imageTmp = new Bitmap(fsOut))
                //                            {
                //                                imageTmp.Save(fsOut, ImageFormat.Png);
                //                                //TODO: Resize
                //                                return true;
                //                            }
                //                        }
                //                    }

                //                #endregion

                //                case 3: // WMF
                //                {
                //                    break;
                //                }
                //                case 6:

                //                    #region PNG Preview (2013 file format and higher)

                //                    fileStream.Seek(imageHeaderStart, SeekOrigin.Begin);
                //                    using (var fsOut = new FileStream(tmpPath, FileMode.Create))
                //                    {
                //                        fileStream.CopyTo(fsOut, imageHeaderStart);
                //                    }

                //                    //TODO: Resize
                //                    return true;

                //                #endregion

                //                //case 3:
                //                //    break; // DWG file doesn't contain a thumbnail
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(
                    $"Failed to extract the thumbnail of the following CAD drawing: {inputPath}", ex);
            }
            finally
            {
                File.Delete(tmpPath);
            }

            return false;
        }
    }
}
