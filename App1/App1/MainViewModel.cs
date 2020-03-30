using System.Collections.Generic;

namespace App1
{
    public class MainViewModel
    {
        /// <summary>
        /// Background color or fx for blurring.
        /// </summary>
        public OverlayBackground OverlayBackground { get; set; } = OverlayBackground.black; // Change it to black to get memory leak.

        /// <summary>
        /// How long image should be shown.
        /// </summary>
        public int DisplayImageTime { get; set; } = 1;

        /// <summary>
        /// List of files to show.
        /// </summary>
        public IList<File> Files { get; private set; } = new List<File>()
        {
            new File() { LocalPath = "/Assets/Files/image1.jpg" },
            new File() { LocalPath = "/Assets/Files/image2.jpg" },
        };
    }
}
