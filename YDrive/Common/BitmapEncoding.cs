using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YDrive.Common
{
    public static class BitmapEncoding
    {
        //image settings
        public static readonly int imageHeight = 1080;
        public static readonly int imageWidth = 1920;
        public static readonly int framerate = 25;

        //steganography settings
        public static readonly int pixelDensity = 3; // base64 chars per pixel
        public static readonly int imageDensity = 1; //pixels per data, adjust for compression and attacks, 1 has highest storage per image
        public static readonly int[] emptyPixel = new int[4] { 0, 0, 0, 0 };
        public static readonly Dictionary<char, int[]> Base64ToRGBA = new Dictionary<char, int[]>() {
            { 'A', new int[4] {0, 0, 0, 0} },
            { 'B', new int[4] {0, 0, 0, 0} },
            { 'C', new int[4] {0, 0, 0, 0} },
            { 'D', new int[4] {0, 0, 0, 0} },
            { 'E', new int[4] {0, 0, 0, 0} },
            { 'F', new int[4] {0, 0, 0, 0} },
            { 'G', new int[4] {0, 0, 0, 0} },
            { 'H', new int[4] {0, 0, 0, 0} },
            { 'I', new int[4] {0, 0, 0, 0} },
            { 'J', new int[4] {0, 0, 0, 0} },
            { 'K', new int[4] {0, 0, 0, 0} },
            { 'L', new int[4] {0, 0, 0, 0} },
            { 'M', new int[4] {0, 0, 0, 0} },
            { 'N', new int[4] {0, 0, 0, 0} },
            { 'O', new int[4] {0, 0, 0, 0} },
            { 'P', new int[4] {0, 0, 0, 0} },
            { 'Q', new int[4] {0, 0, 0, 0} },
            { 'R', new int[4] {0, 0, 0, 0} },
            { 'S', new int[4] {0, 0, 0, 0} },
            { 'T', new int[4] {0, 0, 0, 0} },
            { 'U', new int[4] {0, 0, 0, 0} },
            { 'V', new int[4] {0, 0, 0, 0} },
            { 'W', new int[4] {0, 0, 0, 0} },
            { 'X', new int[4] {0, 0, 0, 0} },
            { 'Y', new int[4] {0, 0, 0, 0} },
            { 'Z', new int[4] {0, 0, 0, 0} },
            { 'a', new int[4] {0, 0, 0, 0} },
            { 'b', new int[4] {0, 0, 0, 0} },
            { 'c', new int[4] {0, 0, 0, 0} },
            { 'd', new int[4] {0, 0, 0, 0} },
            { 'e', new int[4] {0, 0, 0, 0} },
            { 'f', new int[4] {0, 0, 0, 0} },
            { 'g', new int[4] {0, 0, 0, 0} },
            { 'h', new int[4] {0, 0, 0, 0} },
            { 'i', new int[4] {0, 0, 0, 0} },
            { 'j', new int[4] {0, 0, 0, 0} },
            { 'k', new int[4] {0, 0, 0, 0} },
            { 'l', new int[4] {0, 0, 0, 0} },
            { 'm', new int[4] {0, 0, 0, 0} },
            { 'n', new int[4] {0, 0, 0, 0} },
            { 'o', new int[4] {0, 0, 0, 0} },
            { 'p', new int[4] {0, 0, 0, 0} },
            { 'q', new int[4] {0, 0, 0, 0} },
            { 'r', new int[4] {0, 0, 0, 0} },
            { 's', new int[4] {0, 0, 0, 0} },
            { 't', new int[4] {0, 0, 0, 0} },
            { 'u', new int[4] {0, 0, 0, 0} },
            { 'v', new int[4] {0, 0, 0, 0} },
            { 'w', new int[4] {0, 0, 0, 0} },
            { 'x', new int[4] {0, 0, 0, 0} },
            { 'y', new int[4] {0, 0, 0, 0} },
            { 'z', new int[4] {0, 0, 0, 0} },
            { '0', new int[4] {0, 0, 0, 0} },
            { '1', new int[4] {0, 0, 0, 0} },
            { '2', new int[4] {0, 0, 0, 0} },
            { '3', new int[4] {0, 0, 0, 0} },
            { '4', new int[4] {0, 0, 0, 0} },
            { '5', new int[4] {0, 0, 0, 0} },
            { '5', new int[4] {0, 0, 0, 0} },
            { '6', new int[4] {0, 0, 0, 0} },
            { '7', new int[4] {0, 0, 0, 0} },
            { '8', new int[4] {0, 0, 0, 0} },
            { '9', new int[4] {0, 0, 0, 0} },
            { '+', new int[4] {0, 0, 0, 0} },
            { '/', new int[4] {0, 0, 0, 0} },



        };
    }
}
