using System;
using System.ComponentModel.Design;
using System.IO;
using System.Windows.Forms;
using MimeDetective.InMemory;
using Newtonsoft.Json;
using SemVersion;

namespace MimeTypeManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //var bv = new ByteViewer();
            //Controls.Add(bv);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var magicFile = new MagicFile
            {
                Maintainer = "Lukas Eßmann",
                Version = new SemanticVersion(1,0,0),
                FileTypes = MimeTypes.AllTypes
            };

            File.WriteAllText("magic.json", JsonConvert.SerializeObject(magicFile, Formatting.Indented));
        }
    }
}
