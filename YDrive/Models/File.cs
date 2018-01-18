using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace YDrive.Models
{
    class File
    {
        //file name and extension
        public string Name { get; set; }

        //File to base64 string
        public string Content { get; set; }

        //Encrypted file 
        public string EncryptedContent { get; set; }

        public List<BitmapImage> YoutubeReadyVideo { get; set; }




        //Status updates

        public bool IsEncrypted { get; set; }

        public bool IsConvertingToVideo { get; set; }

        public bool IsUploading { get; set; }

        public bool IsDone { get; set; }



    }
}

