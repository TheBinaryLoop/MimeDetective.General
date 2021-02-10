using System.Collections.Generic;
using SemVersion;

namespace MimeDetective.InMemory
{
    public class MagicFile
    {
        public string Maintainer { get; set; }
        public SemanticVersion Version { get; set; }
        public IEnumerable<FileType> FileTypes { get; set; }
    }
}