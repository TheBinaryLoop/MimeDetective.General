namespace MimeDetective.InMemory
{
    public sealed class FileSignature
    {
        public FileSignature(byte?[] bytes, int offset)
        {
            SignatureBytes = bytes;
            Offset = offset;
        }

        public byte?[] SignatureBytes { get; }
        public int Offset { get; }
    }
}
