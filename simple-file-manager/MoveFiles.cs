using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_file_manager
{
    public static class MoveFiles
    {
        public static string SourcePath { get; set; }
        public static string DestinationPath { get; set; }
        public static bool IsSource { get; set; } = true;
        public static string  Name { get; set; }
        public static List<OpenFolderUI> openFolderUIRefs { get; set; } = new List<OpenFolderUI>();

        public static void Reset()
        {
            SourcePath = "";
            DestinationPath = "";
            IsSource = true;
            Name = "";
            // openFolderUIRefs = new List<OpenFolderUI>();
        }
    }
}
