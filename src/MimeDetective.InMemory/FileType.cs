using System;

namespace MimeDetective.InMemory
{
    public sealed class FileType : IEquatable<FileType>
    {
        public FileType(string extension, string mime, params FileSignature[] signatures)
            : this(extension, mime, string.Empty, signatures)
        {
        }

        public FileType(string extension, string mime, string description, params FileSignature[] signatures)
        {
            Signatures = signatures;
            Extension = extension;
            Mime = mime;
            Description = description;
        }

        public FileSignature[] Signatures { get; }
        public string Extension { get; }
        public string Mime { get; }
        public string Description { get; set; }

        public override string ToString() => Extension;

        public override int GetHashCode()
        {
            unchecked { return ((Extension?.GetHashCode() ?? 0) * 397) ^ (Mime?.GetHashCode() ?? 0); }
        }

        public override bool Equals(object other) => other is FileType ft && Equals(ft);

        public bool Equals(FileType other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(Extension, other.Extension, StringComparison.OrdinalIgnoreCase)
                   && string.Equals(Mime, other.Mime, StringComparison.OrdinalIgnoreCase)
                   && string.Equals(Description, other.Description, StringComparison.OrdinalIgnoreCase);
        }
    }
}
