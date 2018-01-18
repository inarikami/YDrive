using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using YDrive.Helpers;
using YDrive.Common;

namespace YDrive.Services
{
    public static class DataService
    {

        //Convert File to video ready to upload
        public static void EncryptAndConvert(string filepath)
        {
            //fetch file
            string base64 = ConvertFileToBase64(filepath);

            //password string for encryption
            string encryptBase64Pass = RandomData.GetRandomString(12);

            //encrypt with random string
            string encryptedBase64 = EncryptAndDecrypt.SimpleEncryptWithPassword(base64, encryptBase64Pass);

            //convert to video
 
        }



        //Convert Video from temp folder to file
        public static void ConvertAndDecrypt(string ydPath)
        {

        }

        //Parse the yd file
        public static string ParseYDFile()
        {

            string ydFolder = "";


            return "";
        }

        //save info as yd file
        public static async void SaveToYDFile(string vidID, string password)
        {
            var keyPath = Path.GetTempFileName();
            var newKeyFile = File.Create(vidID + ".yd");

            StreamWriter keyWriter = new StreamWriter(newKeyFile);
            keyWriter.WriteLine(vidID);
            keyWriter.WriteLine(password);

            //done
            keyWriter.Dispose();

        }


        private static string ConvertFileToBase64(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            String file = Convert.ToBase64String(bytes);
            return file;
        }

        private static void ConvertBase64ToFile(string b64Str, string path)
        {
            Byte[] bytes = Convert.FromBase64String(b64Str);
            File.WriteAllBytes(path, bytes);
        }

        private static void EncodeStringToVideo(string encryptbase64, string filePath)
        {
            List<BitmapImage> bitmapList = new List<BitmapImage>();
            //convert string to image(s)
            int numberOfImages = encryptbase64.Length / (BitmapEncoding.imageWidth * BitmapEncoding.imageHeight);
            int stringSequence = 0;
            Parallel.For(0, numberOfImages,
                i =>
                {
                    BitmapImage writeBitmap = new BitmapImage();
                    writeBitmap.DecodePixelWidth = BitmapEncoding.imageWidth;
                    writeBitmap.DecodePixelHeight = BitmapEncoding.imageHeight;
                    for(int yCount = 0; yCount < BitmapEncoding.imageHeight; yCount++)
                    {
                        for(int xCount = 0; xCount < BitmapEncoding.imageWidth; xCount++, stringSequence++)
                        {
                            //set pixel value according to bitmapencoding base64torgba dictionary


                        }
                    }



                    bitmapList.Add(writeBitmap);
                }
            );
            //create video

        }

        private static void DecodeVideoToString(string filePath)
        {

        }
    }

}
