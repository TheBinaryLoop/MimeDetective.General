using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MimeDetective.InMemory.Tests
{
    [TestClass]
    public class Tests
    {
        private static readonly Random R = new Random();

        [TestMethod]
        [DynamicData(nameof(TestDataSet))]
        public void CanDetectMime(FileType file)
        {
            //Arrange
            var data = new byte[file.Signatures.Max(s => s.Offset + s.SignatureBytes.Length)];
            R.NextBytes(data);

            foreach (var signature in file.Signatures)
            {
                for (int i = 0; i < signature.SignatureBytes.Length; i++)
                {
                    data[signature.Offset + i] = signature.SignatureBytes[i] ?? 0;
                }
            }

            //Act
            var mime = data.DetectMimeType();

            //Assert
            Assert.AreEqual(mime, file);
        }

        private static IEnumerable<object[]> TestDataSet =>
            MimeTypes.AllTypes
                .Where(x => x.Signatures.All(s => s.SignatureBytes.Length > 0) && x != MimeTypes.MCF)
                .Select(x => new object[] { x });
    }
}

