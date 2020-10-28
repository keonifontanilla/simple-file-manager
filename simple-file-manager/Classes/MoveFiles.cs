using System.Collections.Generic;

namespace simple_file_manager
{
    /// <summary>
    /// This static class handles the moving and updating of folder or file paths between all open
    /// folder instances and the main ui instance.
    /// </summary>
    public static class MoveFiles
    {
        /// <summary>
        /// The source path for moving a folder or file.
        /// </summary>
        public static string SourcePath { get; set; }
        /// <summary>
        /// The destination path for moving a folder or file.
        /// </summary>
        public static string DestinationPath { get; set; }
        /// <summary>
        /// A check if the source or destination path is being set for moving.
        /// </summary>
        public static bool IsSource { get; set; } = true;
        /// <summary>
        /// A check if the move button is clicked.
        /// </summary>
        public static bool MoveClicked { get; set; } = false;
        /// <summary>
        /// The name of the folder.
        /// </summary>
        public static string Name { get; set; }
        /// <summary>
        /// A list of OpenFolderUI references to keep track of the OpenFolderUI forms that are open.
        /// </summary>
        public static List<OpenFolderUI> OpenFolderUIRefs { get; set; } = new List<OpenFolderUI>();
        /// <summary>
        /// An array of strings of all paths on the main ui that the user has added.
        /// </summary>
        public static string[] MainUIPaths { get; set; } = new string[6];
        /// <summary>
        /// A reference to the main ui.
        /// </summary>
        public static FolderNavigationUI MainUIRef { get; set; }

        /// <summary>
        /// Resets to the default values.
        /// </summary>
        public static void Reset()
        {
            SourcePath = "";
            DestinationPath = "";
            IsSource = true;
            MoveClicked = false;
            Name = "";
        }
    }
}
