using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace MimeDetective.InMemory
{
    public static class MimeTypes
    {
        static MimeTypes()
        {
            AllTypes = new List<FileType> 
            { 
                PDF, MCF, JPEG, ZIP, RAR, RTF, PNG, GIF, DLL_EXE,
                BMP, DLL_EXE, /*ZIP_7z,*/ ZIP_7z_2, GZ_TGZ, TAR_ZH, TAR_ZV, OGG, ICO, XML, MIDI, FLV, WAVE, DWG, DEB, PST, PSD,
                AES, SKR, SKR_2, PKR, EML_FROM, ELF, TXT_UTF8, TXT_UTF16_BE, TXT_UTF16_LE, TXT_UTF32_BE, TXT_UTF32_LE, TIFF, BZ2,
                DWG_AutoCAD_v12_R2, DWG_AutoCAD_v13_R3, DWG_AutoCAD_v140_R4, DWG_AutoCAD_v205_R5, DWG_AutoCAD_v210_R6, DWG_AutoCAD_v25_R7,
                DWG_AutoCAD_v26_R8, DWG_AutoCAD_v90_R9, DWG_AutoCAD_v10_R10, DWG_AutoCAD_v11_v12_R12, DWG_AutoCAD_v13_R13, DWG_AutoCAD_v14_R14,
                DWG_AutoCAD_v15_v151_v152, DWG_AutoCAD_v16_v161_v162, DWG_AutoCAD_v17_v171_v172, DWG_AutoCAD_v18_v181_v182,
                DWG_AutoCAD_v19_v191_v20_v201_v202, DWG_AutoCAD_v22,
                //PYC_1_5, PYC_1_6, PYC_2_0, PYC_2_1, PYC_2_2, PYC_2_3_A0_1, PYC_2_3_A0_2, PYC_2_3_A0_3, PYC_2_4_A0, PYC_2_4_A3, PYC_2_4_B1,
                //PYC_2_5_A0_1, PYC_2_5_A0_2, PYC_2_5_A0_3, PYC_2_5_A0_4, PYC_2_5_B3_1, PYC_2_5_B3_2, PYC_2_5_C1, PYC_2_5_C2, PYC_2_6_A0,
                //PYC_2_6_A1, PYC_2_7_A0_1, PYC_2_7_A0_2, PYC_2_7_A0_3, PYC_2_7_A0_4, PYC_2_7_A0_5, PYC_3_0_1, PYC_3_0_2, PYC_3_0_3, PYC_3_0_4,
                //PYC_3_0_5, PYC_3_0_6, PYC_3_0_7, PYC_3_0_7, PYC_3_0_8, PYC_3_0_9, PYC_3_0_10, PYC_3_0_11, PYC_3_0_12, PYC_3_0_13, PYC_3_0_A4,
                //PYC_3_0_A5, PYC_3_1_A0_1, PYC_3_1_A0_2, PYC_3_2_A0, PYC_3_2_A1, PYC_3_2_A2, PYC_3_3_A0_1, PYC_3_3_A0_2, PYC_3_3_A1, PYC_3_3_A4,
                //PYC_3_4_A1_1, PYC_3_4_A1_2, PYC_3_4_A1_3, PYC_3_4_A1_4, PYC_3_4_A4_1, PYC_3_4_A4_2, PYC_3_4_RC2, PYC_3_5_A0, PYC_3_5_B1,
                //PYC_3_5_B2_1, PYC_3_5_B2_2, PYC_3_5_2, PYC_3_6_A0_1, PYC_3_6_A0_2, PYC_3_6_A1_1, PYC_3_6_A1_2, PYC_3_6_A1_3, PYC_3_6_A1_4,
                //PYC_3_6_B1_1, PYC_3_6_B1_2, PYC_3_6_B1_3, PYC_3_6_B2, PYC_3_6_RC2, PYC_3_7_A1, PYC_3_7_A2, PYC_3_7_A4, PYC_3_7_B1, PYC_3_7_B5,
                MKVAS3D_WEBM, ISO_1, ISO_2, ISO_3, MPEGTS, VMDK, NVRAM, PCAP_1, PCAP_2, PCAPNG, SQLITEDB, TTF, WOFF, WOFF2
            };
        }

        public static List<FileType> AllTypes { get; }

        #region Constants

        #region Temp

        // office and documents
        public static readonly FileType MCF = new FileType("", "", new FileSignature(new byte?[] { 0xd0, 0xcf, 0x11, 0xe0, 0xa1, 0xb1, 0x1a, 0xe1 }, 0));

        // old office documents are detecting in case of MCF type by GUIDs custom logic, so we don't add them to list
        public static readonly FileType WORD = new FileType("doc", "application/msword", new FileSignature(new byte?[] { 0xd0, 0xcf, 0x11, 0xe0, 0xa1, 0xb1, 0x1a, 0xe1 }, 0), new FileSignature(new byte?[] { 0xEC, 0xA5, 0xC1, 0x00 }, 512));
        public static readonly FileType EXCEL = new FileType("xls", "application/vnd.ms-excel", new FileSignature(new byte?[] { 0xd0, 0xcf, 0x11, 0xe0, 0xa1, 0xb1, 0x1a, 0xe1 }, 0), new FileSignature(new byte?[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 }, 512));
        public static readonly FileType PPT = new FileType("ppt", "application/vnd.ms-powerpoint", new FileSignature(new byte?[] { 0xd0, 0xcf, 0x11, 0xe0, 0xa1, 0xb1, 0x1a, 0xe1 }, 0), new FileSignature(new byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, null, 0x00, 0x00, 0x00 }, 512));
        public static readonly FileType MSG = new FileType("msg", "application/vnd.ms-outlook", new FileSignature(new byte?[] { 0xd0, 0xcf, 0x11, 0xe0, 0xa1, 0xb1, 0x1a, 0xe1 }, 0));

        //ms office and openoffice docs (they're zip files: rename and enjoy!)
        //don't add them to the list, as they will be 'subtypes' of the ZIP type
        public static readonly FileType WORDX = new FileType("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", new FileSignature(new byte?[0], 512));
        public static readonly FileType EXCELX = new FileType("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new FileSignature(new byte?[0], 512));
        public static readonly FileType PPTX = new FileType("pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", new FileSignature(new byte?[0], 512));
        public static readonly FileType VSDX = new FileType("vsdx", "application/vnd-ms-visio.drawing", new FileSignature(new byte?[0], 512));
        public static readonly FileType ODT = new FileType("odt", "application/vnd.oasis.opendocument.text", new FileSignature(new byte?[0], 512));
        public static readonly FileType ODS = new FileType("ods", "application/vnd.oasis.opendocument.spreadsheet", new FileSignature(new byte?[0], 512));

        // common documents
        public static readonly FileType RTF = new FileType("rtf", "application/rtf", new FileSignature(new byte?[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 }, 0));
        public static readonly FileType PDF = new FileType("pdf", "application/pdf", new FileSignature(new byte?[] { 0x25, 0x50, 0x44, 0x46 }, 0));

        //application/xml text/xml
        public static readonly FileType XML = new FileType("xml,xul", "text/xml", new FileSignature(new byte?[] { 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x22, 0x31, 0x2E, 0x30, 0x22, 0x3F, 0x3E }, 0));

        //text files
        public static readonly FileType TXT = new FileType("txt", "text/plain", new FileSignature(new byte?[0], 0));
        public static readonly FileType TXT_UTF8 = new FileType("txt", "text/plain", new FileSignature(new byte?[] { 0xEF, 0xBB, 0xBF }, 0));
        public static readonly FileType TXT_UTF16_BE = new FileType("txt", "text/plain", new FileSignature(new byte?[] { 0xFE, 0xFF }, 0));
        public static readonly FileType TXT_UTF16_LE = new FileType("txt", "text/plain", new FileSignature(new byte?[] { 0xFF, 0xFE }, 0));
        public static readonly FileType TXT_UTF32_BE = new FileType("txt", "text/plain", new FileSignature(new byte?[] { 0x00, 0x00, 0xFE, 0xFF }, 0));
        public static readonly FileType TXT_UTF32_LE = new FileType("txt", "text/plain", new FileSignature(new byte?[] { 0xFF, 0xFE, 0x00, 0x00 }, 0));

        //images
        public static readonly FileType JPEG = new FileType("jpg", "image/jpeg", new FileSignature(new byte?[] { 0xFF, 0xD8, 0xFF }, 0));
        public static readonly FileType PNG = new FileType("png", "image/png", new FileSignature(new byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, 0));
        public static readonly FileType GIF = new FileType("gif", "image/gif", new FileSignature(new byte?[] { 0x47, 0x49, 0x46, 0x38, null, 0x61 }, 0));
        public static readonly FileType BMP = new FileType("bmp", "image/bmp", new FileSignature(new byte?[] { 66, 77 }, 0));
        public static readonly FileType ICO = new FileType("ico", "image/x-icon", new FileSignature(new byte?[] { 0, 0, 1, 0 }, 0));
        public static readonly FileType TIFF = new FileType("tif", "image/tiff", new FileSignature(new byte?[] { 0x49, 0x49, 0x2A, 0x00 }, 0));

        //archives
        public static readonly FileType GZ_TGZ = new FileType("gz, tgz", "application/x-gz", new FileSignature(new byte?[] { 0x1F, 0x8B, 0x08 }, 0));

        //public static readonly FileType ZIP_7z = new FileType(new byte?[] { 66, 77 }, "7z", "application/x-7z-compressed");
        public static readonly FileType ZIP_7z_2 = new FileType("7z", "application/x-7z-compressed", new FileSignature(new byte?[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C }, 0));

        public static readonly FileType ZIP = new FileType("zip", "application/x-compressed", new FileSignature(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, 0));
        public static readonly FileType RAR = new FileType("rar", "application/x-rar-compressed", new FileSignature(new byte?[] { 0x52, 0x61, 0x72, 0x21 }, 0));
        public static readonly FileType DLL_EXE = new FileType("dll, exe", "application/octet-stream", new FileSignature(new byte?[] { 0x4D, 0x5A }, 0));

        //Compressed tape archive file using standard (Lempel-Ziv-Welch) compression
        public static readonly FileType TAR_ZV = new FileType("tar.z", "application/x-tar", new FileSignature(new byte?[] { 0x1F, 0x9D }, 0));

        //Compressed tape archive file using LZH (Lempel-Ziv-Huffman) compression
        public static readonly FileType TAR_ZH = new FileType("tar.z", "application/x-tar", new FileSignature(new byte?[] { 0x1F, 0xA0 }, 0));

        //bzip2 compressed archive
        public static readonly FileType BZ2 = new FileType("bz2,tar,bz2,tbz2,tb2", "application/x-bzip2", new FileSignature(new byte?[] { 0x42, 0x5A, 0x68 }, 0));

        // NuGet package
        public static readonly FileType NUPKG = new FileType("nupkg", "application/x-compressed", new FileSignature(new byte?[0], 0));

        // Epub
        public static readonly FileType EPUB = new FileType("epub", "application/epub+zip", new FileSignature(new byte?[0], 0));

        // Jar
        public static readonly FileType JAR = new FileType("jar", "application/java-archive", new FileSignature(new byte?[0], 0));

        // media
        public static readonly FileType OGG = new FileType("oga,ogg,ogv,ogx", "application/ogg", new FileSignature(new byte?[] { 0x4f, 0x67, 0x67, 0x53 }, 0));

        //MID, MIDI     Musical Instrument Digital Interface (MIDI) sound file
        public static readonly FileType MIDI = new FileType("midi,mid", "audio/midi", new FileSignature(new byte?[] { 0x4D, 0x54, 0x68, 0x64 }, 0));

        //FLV       Flash video file
        public static readonly FileType FLV = new FileType("flv", "application/unknown", new FileSignature(new byte?[] { 0x46, 0x4C, 0x56, 0x01 }, 0));

        //WAV       Resource Interchange File Format -- Audio for Windows file, where xx xx xx xx is the file size (little endian), audio/wav audio/x-wav
        public static readonly FileType WAVE = new FileType("wav", "audio/wav", new FileSignature(new byte?[] { 0x52, 0x49, 0x46, 0x46, null, null, null, null,
                                                            0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20 }, 0));

        public static readonly FileType PST = new FileType("pst", "application/octet-stream", new FileSignature(new byte?[] { 0x21, 0x42, 0x44, 0x4E }, 0));

        //MPEG Transport Stream (MPEG-2 Part 1)
        public static readonly FileType MPEGTS = new FileType("ts,tsv,tsa", "video/mp2t", new FileSignature(new byte?[]
            {
                0x47, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, 0x47
            }, 0));

        //MKV,MKA,MKS,MK3D,WEBM
        public static readonly FileType MKVAS3D_WEBM = new FileType("mkv,mka,mks,mk3d,webm", "video/x-matroska", new FileSignature(new byte?[] { 0x1a, 0x45, 0xdf, 0xa3 }, 0));
        
        //Photoshop image file
        public static readonly FileType PSD = new FileType("psd", "application/octet-stream", new FileSignature(new byte?[] { 0x38, 0x42, 0x50, 0x53 }, 0));

        //deb  linux deb file
        public static readonly FileType DEB = new FileType("deb", "application/vnd.debian.binary-package", new FileSignature(new byte?[] { 0x21, 0x3C, 0x61, 0x72, 0x63, 0x68, 0x3E }, 0));

        //AES Crypt file format. (The fourth byte is the version number.)
        public static readonly FileType AES = new FileType("aes", "application/octet-stream", new FileSignature(new byte?[] { 0x41, 0x45, 0x53 }, 0));

        //SKR       PGP secret keyring file
        public static readonly FileType SKR = new FileType("skr", "application/octet-stream", new FileSignature(new byte?[] { 0x95, 0x00 }, 0));

        //SKR       PGP secret keyring file
        public static readonly FileType SKR_2 = new FileType("skr", "application/octet-stream", new FileSignature(new byte?[] { 0x95, 0x01 }, 0));

        //PKR       PGP public keyring file
        public static readonly FileType PKR = new FileType("pkr", "application/octet-stream", new FileSignature(new byte?[] { 0x99, 0x01 }, 0));

        /*
         * 46 72 6F 6D 20 20 20 or      From
        46 72 6F 6D 20 3F 3F 3F or      From ???
        46 72 6F 6D 3A 20       From:
        EML     A commmon file extension for e-mail files. Signatures shown here
        are for Netscape, Eudora, and a generic signature, respectively.
        EML is also used by Outlook Express and QuickMail.
         */
        public static readonly FileType EML_FROM = new FileType("eml", "message/rfc822", new FileSignature(new byte?[] { 0x46, 0x72, 0x6F, 0x6D }, 0));


        //EVTX      Windows Vista event log file
        public static readonly FileType ELF = new FileType("elf", "text/plain", new FileSignature(new byte?[] { 0x45, 0x6C, 0x66, 0x46, 0x69, 0x6C, 0x65, 0x00 }, 0));

        //ISO
        public static readonly FileType ISO_1 = new FileType("iso,img,cdr,dvdr", "application/x-iso-image", new FileSignature(new byte?[] { 0x43, 0x44, 0x30, 0x30, 0x31 }, 32769));
        public static readonly FileType ISO_2 = new FileType("iso,img,cdr,dvdr", "application/x-iso-image", new FileSignature(new byte?[] { 0x43, 0x44, 0x30, 0x30, 0x31 }, 34817));
        public static readonly FileType ISO_3 = new FileType("iso,img,cdr,dvdr", "application/x-iso-image", new FileSignature(new byte?[] { 0x43, 0x44, 0x30, 0x30, 0x31 }, 36865));

        //VMDK
        public static readonly FileType VMDK = new FileType("vmdk", "application/octet-stream", new FileSignature(new byte?[] { 0x4b, 0x44, 0x4d, 0x56, 0x01 }, 0));

        //NVRAM
        public static readonly FileType NVRAM = new FileType("nvram", "application/octet-stream", new FileSignature(new byte?[] { 0x4d, 0x52, 0x56, 0x4e, 0x01 }, 0));

        //PCAP Libpcap File Format
        public static readonly FileType PCAP_1 = new FileType("pcap", "application/vnd.tcpdump.pcap", new FileSignature(new byte?[] { 0xa1, 0xb2, 0xc3, 0xd4 }, 0));
        public static readonly FileType PCAP_2 = new FileType("pcap", "application/vnd.tcpdump.pcap", new FileSignature(new byte?[] { 0xd4, 0xc3, 0xb2, 0xa1 }, 0));

        //PCAPNG PCAP Next Generation Dump File Format
        public static readonly FileType PCAPNG = new FileType("pcapng", "application/octet-stream", new FileSignature(new byte?[] { 0x0a, 0x0d, 0x0d, 0x0a }, 0));

        //SQLite Database
        public static readonly FileType SQLITEDB = new FileType("db,sqlitedb,sqlite", "application/x-sqlite3", new FileSignature(new byte?[]
                {
                    0x53, 0x51, 0x4c, 0x69, 0x74, 0x65, 0x20, 0x66, 0x6f, 0x72, 0x6d, 0x61, 0x74, 0x20, 0x33, 0x00
                }, 0));

        //TTF Font
        public static readonly FileType TTF = new FileType("ttf,ttc", "application/x-font-ttf", new FileSignature(new byte?[] { 0x00, 0x01, 0x00, 0x00, 0x00 }, 0));

        //WOFF font
        public static readonly FileType WOFF = new FileType("woff", "font/woff", new FileSignature(new byte?[] { 0x77, 0x4f, 0x46, 0x46 }, 0));

        //WOFF2 font
        public static readonly FileType WOFF2 = new FileType("woff2", "font/woff2", new FileSignature(new byte?[] { 0x77, 0x4f, 0x46, 0x32 }, 0));

        //MSG Outlook file
        

        #endregion
        //#region Python

        //// Python 1
        //public static readonly FileType PYC_1_5 = new FileType(new byte?[] { 0x99, 0x4e }, "pyc", "application/octet-stream", "Python 1.5/1.5.1/1.5.2");
        //public static readonly FileType PYC_1_6 = new FileType(new byte?[] { 0x4c, 0xc4 }, "pyc", "application/octet-stream", "Python 1.6");

        //// Python 2
        //public static readonly FileType PYC_2_0 = new FileType(new byte?[] { 0x87, 0xc6 }, "pyc", "application/octet-stream", "Python 2.0/2.0.1");
        //public static readonly FileType PYC_2_1 = new FileType(new byte?[] { 0x2a, 0xeb }, "pyc", "application/octet-stream", "Python 2.1/2.1.1/2.1.2");
        //public static readonly FileType PYC_2_2 = new FileType(new byte?[] { 0x2d, 0xed }, "pyc", "application/octet-stream", "Python 2.2");
        //public static readonly FileType PYC_2_3_A0_1 = new FileType(new byte?[] { 0x3b, 0xf2 }, "pyc", "application/octet-stream", "Python 2.3a0");
        //public static readonly FileType PYC_2_3_A0_2 = new FileType(new byte?[] { 0x45, 0xf2 }, "pyc", "application/octet-stream", "Python 2.3a0");
        //public static readonly FileType PYC_2_3_A0_3 = new FileType(new byte?[] { 0x3b, 0xf2 }, "pyc", "application/octet-stream", "Python 2.3a0");
        //public static readonly FileType PYC_2_4_A0 = new FileType(new byte?[] { 0x59, 0xf2 }, "pyc", "application/octet-stream", "Python 2.4a0");
        //public static readonly FileType PYC_2_4_A3 = new FileType(new byte?[] { 0x63, 0xf2 }, "pyc", "application/octet-stream", "Python 2.4a3");
        //public static readonly FileType PYC_2_4_B1 = new FileType(new byte?[] { 0x6d, 0xf2 }, "pyc", "application/octet-stream", "Python 2.4b1");
        //public static readonly FileType PYC_2_5_A0_1 = new FileType(new byte?[] { 0x77, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5a0");
        //public static readonly FileType PYC_2_5_A0_2 = new FileType(new byte?[] { 0x81, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5a0");
        //public static readonly FileType PYC_2_5_A0_3 = new FileType(new byte?[] { 0x8b, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5a0");
        //public static readonly FileType PYC_2_5_A0_4 = new FileType(new byte?[] { 0x8c, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5a0");
        //public static readonly FileType PYC_2_5_B3_1 = new FileType(new byte?[] { 0x95, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5b3");
        //public static readonly FileType PYC_2_5_B3_2 = new FileType(new byte?[] { 0x9f, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5b3");
        //public static readonly FileType PYC_2_5_C1 = new FileType(new byte?[] { 0xa9, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5c1");
        //public static readonly FileType PYC_2_5_C2 = new FileType(new byte?[] { 0xb3, 0xf2 }, "pyc", "application/octet-stream", "Python 2.5c2");
        //public static readonly FileType PYC_2_6_A0 = new FileType(new byte?[] { 0xc7, 0xf2 }, "pyc", "application/octet-stream", "Python 2.6a0");
        //public static readonly FileType PYC_2_6_A1 = new FileType(new byte?[] { 0xd1, 0xf2 }, "pyc", "application/octet-stream", "Python 2.6a1");
        //public static readonly FileType PYC_2_7_A0_1 = new FileType(new byte?[] { 0xdb, 0xf2 }, "pyc", "application/octet-stream", "Python 2.7a0");
        //public static readonly FileType PYC_2_7_A0_2 = new FileType(new byte?[] { 0xe5, 0xf2 }, "pyc", "application/octet-stream", "Python 2.7a0");
        //public static readonly FileType PYC_2_7_A0_3 = new FileType(new byte?[] { 0xef, 0xf2 }, "pyc", "application/octet-stream", "Python 2.7a0");
        //public static readonly FileType PYC_2_7_A0_4 = new FileType(new byte?[] { 0xf9, 0xf2 }, "pyc", "application/octet-stream", "Python 2.7a0");
        //public static readonly FileType PYC_2_7_A0_5 = new FileType(new byte?[] { 0x03, 0xf3 }, "pyc", "application/octet-stream", "Python 2.7a0");

        //// Python 3
        //public static readonly FileType PYC_3_0_1 = new FileType(new byte?[] { 0xb8, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_2 = new FileType(new byte?[] { 0xc2, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_3 = new FileType(new byte?[] { 0xcc, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_4 = new FileType(new byte?[] { 0xd6, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_5 = new FileType(new byte?[] { 0xe0, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_6 = new FileType(new byte?[] { 0xea, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_7 = new FileType(new byte?[] { 0xf4, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_8 = new FileType(new byte?[] { 0xf5, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_9 = new FileType(new byte?[] { 0xff, 0x0b }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_10 = new FileType(new byte?[] { 0x09, 0x0c }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_11 = new FileType(new byte?[] { 0x13, 0x0c }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_12 = new FileType(new byte?[] { 0x1d, 0x0c }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_13 = new FileType(new byte?[] { 0x1f, 0x0c }, "pyc", "application/octet-stream", "Python 3.0");
        //public static readonly FileType PYC_3_0_A4 = new FileType(new byte?[] { 0x27, 0x0c }, "pyc", "application/octet-stream", "Python 3.0a4");
        //public static readonly FileType PYC_3_0_A5 = new FileType(new byte?[] { 0x3b, 0x0c }, "pyc", "application/octet-stream", "Python 3.0a5");

        //// Python 3.1
        //public static readonly FileType PYC_3_1_A0_1 = new FileType(new byte?[] { 0x45, 0x0c }, "pyc", "application/octet-stream", "Python 3.1a0");
        //public static readonly FileType PYC_3_1_A0_2 = new FileType(new byte?[] { 0x4f, 0x0c }, "pyc", "application/octet-stream", "Python 3.1a0");

        //// Python 3.2
        //public static readonly FileType PYC_3_2_A0 = new FileType(new byte?[] { 0x58, 0x0c }, "pyc", "application/octet-stream", "Python 3.2a0");
        //public static readonly FileType PYC_3_2_A1 = new FileType(new byte?[] { 0x62, 0x0c }, "pyc", "application/octet-stream", "Python 3.2a1");
        //public static readonly FileType PYC_3_2_A2 = new FileType(new byte?[] { 0x6c, 0x0c }, "pyc", "application/octet-stream", "Python 3.2a2");

        //// Python 3.3
        //public static readonly FileType PYC_3_3_A0_1 = new FileType(new byte?[] { 0x76, 0x0c }, "pyc", "application/octet-stream", "Python 3.3a0");
        //public static readonly FileType PYC_3_3_A0_2 = new FileType(new byte?[] { 0x80, 0x0c }, "pyc", "application/octet-stream", "Python 3.3a0");
        //public static readonly FileType PYC_3_3_A1 = new FileType(new byte?[] { 0x94, 0x0c }, "pyc", "application/octet-stream", "Python 3.3a1");
        //public static readonly FileType PYC_3_3_A4 = new FileType(new byte?[] { 0x9e, 0x0c }, "pyc", "application/octet-stream", "Python 3.3a4");

        //// Python 3.4
        //public static readonly FileType PYC_3_4_A1_1 = new FileType(new byte?[] { 0xb2, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a1");
        //public static readonly FileType PYC_3_4_A1_2 = new FileType(new byte?[] { 0xbc, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a1");
        //public static readonly FileType PYC_3_4_A1_3 = new FileType(new byte?[] { 0xc6, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a1");
        //public static readonly FileType PYC_3_4_A1_4 = new FileType(new byte?[] { 0xd0, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a1");
        //public static readonly FileType PYC_3_4_A4_1 = new FileType(new byte?[] { 0xda, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a4");
        //public static readonly FileType PYC_3_4_A4_2 = new FileType(new byte?[] { 0xe4, 0x0c }, "pyc", "application/octet-stream", "Python 3.4a4");
        //public static readonly FileType PYC_3_4_RC2 = new FileType(new byte?[] { 0xee, 0x0c }, "pyc", "application/octet-stream", "Python 3.4rc2");

        //// Python 3.5
        //public static readonly FileType PYC_3_5_A0 = new FileType(new byte?[] { 0xf8, 0x0c }, "pyc", "application/octet-stream", "Python 3.5a0");
        //public static readonly FileType PYC_3_5_B1 = new FileType(new byte?[] { 0x20, 0xd0 }, "pyc", "application/octet-stream", "Python 3.5b1");
        //public static readonly FileType PYC_3_5_B2_1 = new FileType(new byte?[] { 0xc0, 0xd0 }, "pyc", "application/octet-stream", "Python 3.5b2");
        //public static readonly FileType PYC_3_5_B2_2 = new FileType(new byte?[] { 0x16, 0x0d }, "pyc", "application/octet-stream", "Python 3.5b2");
        //public static readonly FileType PYC_3_5_2 = new FileType(new byte?[] { 0x17, 0x0d }, "pyc", "application/octet-stream", "Python 3.5.2");

        //// Python 3.6
        //public static readonly FileType PYC_3_6_A0_1 = new FileType(new byte?[] { 0x20, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a0");
        //public static readonly FileType PYC_3_6_A0_2 = new FileType(new byte?[] { 0x21, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a0");
        //public static readonly FileType PYC_3_6_A1_1 = new FileType(new byte?[] { 0x2a, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a1");
        //public static readonly FileType PYC_3_6_A1_2 = new FileType(new byte?[] { 0x2b, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a1");
        //public static readonly FileType PYC_3_6_A1_3 = new FileType(new byte?[] { 0x2c, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a1");
        //public static readonly FileType PYC_3_6_A1_4 = new FileType(new byte?[] { 0x2d, 0x0d }, "pyc", "application/octet-stream", "Python 3.6a1");
        //public static readonly FileType PYC_3_6_B1_1 = new FileType(new byte?[] { 0x2f, 0x0d }, "pyc", "application/octet-stream", "Python 3.6b1");
        //public static readonly FileType PYC_3_6_B1_2 = new FileType(new byte?[] { 0x30, 0x0d }, "pyc", "application/octet-stream", "Python 3.6b1");
        //public static readonly FileType PYC_3_6_B1_3 = new FileType(new byte?[] { 0x31, 0x0d }, "pyc", "application/octet-stream", "Python 3.6b1");
        //public static readonly FileType PYC_3_6_B2 = new FileType(new byte?[] { 0x32, 0x0d }, "pyc", "application/octet-stream", "Python 3.6b2");
        //public static readonly FileType PYC_3_6_RC2 = new FileType(new byte?[] { 0x33, 0x0d }, "pyc", "application/octet-stream", "Python 3.6rc2");

        //// Python 3.7
        //public static readonly FileType PYC_3_7_A1 = new FileType(new byte?[] { 0x3e, 0x0d }, "pyc", "application/octet-stream", "Python 3.7a1");
        //public static readonly FileType PYC_3_7_A2 = new FileType(new byte?[] { 0x3f, 0x0d }, "pyc", "application/octet-stream", "Python 3.7a2");
        //public static readonly FileType PYC_3_7_A4 = new FileType(new byte?[] { 0x40, 0x0d }, "pyc", "application/octet-stream", "Python 3.7a4");
        //public static readonly FileType PYC_3_7_B1 = new FileType(new byte?[] { 0x41, 0x0d }, "pyc", "application/octet-stream", "Python 3.7b1");
        //public static readonly FileType PYC_3_7_B5 = new FileType(new byte?[] { 0x42, 0x0d }, "pyc", "application/octet-stream", "Python 3.7b5");

        //// System.Net.IPAddress.NetworkToHostOrder(3394).ToString("x").Substring(0, 4)

        //#endregion

        #region AutoCAD

        /// <summary>
        /// AutoCAD v1.2 (Release 2)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v12_R2 = new FileType("dwg", "application/acad", "AutoCAD v1.2 (Release 2)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x2E, 0x32 }, 0));
        
        /// <summary>
        /// AutoCAD v1.3 (Release 3)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v13_R3 = new FileType("dwg", "application/acad", "AutoCAD v1.3 (Release 3)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x2E, 0x33 }, 0));

        /// <summary>
        /// AutoCAD v1.40 (Release 4)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v140_R4 = new FileType("dwg", "application/acad", "AutoCAD v1.40 (Release 4)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x2E, 0x34, 0x30 }, 0));

        /// <summary>
        /// AutoCAD v2.05 (Release 5)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v205_R5 = new FileType("dwg", "application/acad", "AutoCAD v2.05 (Release 5)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x2E, 0x35, 0x30 }, 0));

        /// <summary>
        /// AutoCAD v2.10 (Release 6)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v210_R6 = new FileType("dwg", "application/acad", "AutoCAD v2.10 (Release 6)", new FileSignature(new byte?[] { 0x41, 0x43, 0x32, 0x2E, 0x31, 0x30 }, 0));

        /// <summary>
        /// AutoCAD v2.5 (Release 7)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v25_R7 = new FileType("dwg", "application/acad", "AutoCAD v2.5 (Release 7)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x30, 0x32 }, 0));

        /// <summary>
        /// AutoCAD v2.6 (Release 8)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v26_R8 = new FileType("dwg", "application/acad", "AutoCAD v2.6 (Release 8)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x30, 0x33 }, 0));

        /// <summary>
        /// AutoCAD v9.0 (Release 9)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v90_R9 = new FileType("dwg", "application/acad", "AutoCAD v9.0 (Release 9)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x30, 0x34 }, 0));

        /// <summary>
        /// AutoCAD v10.0 (Release 10)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v10_R10 = new FileType("dwg", "application/acad", "AutoCAD v10.0 (Release 10)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x30, 0x36 }, 0));

        /// <summary>
        /// AutoCAD v11.0 (Release 11)/v12.0 (Release 12)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v11_v12_R12 = new FileType("dwg", "application/acad", "AutoCAD v11.0 (Release 11)/v12.0 (Release 12)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x30, 0x39 }, 0));

        /// <summary>
        /// AutoCAD v13.0 (Release 13)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v13_R13 = new FileType("dwg", "application/acad", "AutoCAD v13.0 (Release 13)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x31, 0x32 }, 0));

        /// <summary>
        /// AutoCAD v14.0 (Release 14)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v14_R14 = new FileType("dwg", "application/acad", "AutoCAD v14.0 (Release 14)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x31, 0x34 }, 0));

        /// <summary>
        /// AutoCAD 2000 (v15.0)/2000i (v15.1)/2002 (v15.2) -- (Releases 15-17)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v15_v151_v152 = new FileType("dwg", "application/acad", "AutoCAD 2000 (v15.0)/2000i (v15.1)/2002 (v15.2) -- (Releases 15-17)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x31, 0x35 }, 0));

        /// <summary>
        /// AutoCAD 2004 (v16.0)/2005 (v16.1)/2006 (v16.2) -- (Releases 18-20)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v16_v161_v162 = new FileType("dwg", "application/acad", "AutoCAD 2004 (v16.0)/2005 (v16.1)/2006 (v16.2) -- (Releases 18-20)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x31, 0x38 }, 0));

        /// <summary>
        /// AutoCAD 2007 (v17.0)/2008 (v17.1)/2009 (v17.2) -- (Releases 21-23)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v17_v171_v172 = new FileType("dwg", "application/acad", "AutoCAD 2007 (v17.0)/2008 (v17.1)/2009 (v17.2) -- (Releases 21-23)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x32, 0x31 }, 0));

        /// <summary>
        /// AutoCAD 2010 (v18.0)/2011 (v18.1)/2012 (v18.2) -- (Releases 24-26)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v18_v181_v182 = new FileType("dwg", "application/acad", "AutoCAD 2010 (v18.0)/2011 (v18.1)/2012 (v18.2) -- (Releases 24-26)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x32, 0x34 }, 0));

        /// <summary>
        /// AutoCAD 2013 (v19.0)/2014 (v19.1)/2015 (v20.0)/2016 (v20.1)/2017 (v20.2) -- (Releases 27-31)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v19_v191_v20_v201_v202 = new FileType("dwg", "application/acad", "AutoCAD 2013 (v19.0)/2014 (v19.1)/2015 (v20.0)/2016 (v20.1)/2017 (v20.2) -- (Releases 27-31)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x32, 0x37 }, 0));

        /// <summary>
        /// AutoCAD 2018 (v22.0) (Release 32)
        /// </summary>
        public static readonly FileType DWG_AutoCAD_v22 = new FileType("dwg", "application/acad", "AutoCAD 2018 (v22.0) (Release 32)", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30, 0x33, 0x32 }, 0));

        //Generic AutoCAD drawing image/vnd.dwg image/x-dwg application/acad
        public static readonly FileType DWG = new FileType("dwg", "application/acad", new FileSignature(new byte?[] { 0x41, 0x43, 0x31, 0x30 }, 0));

        #endregion

        #endregion
    }
}
