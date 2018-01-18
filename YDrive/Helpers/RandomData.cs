using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

namespace YDrive.Helpers
{
    class RandomData
    {
        public static uint GetRandomNumber(uint maxNumber)
        {
            if (maxNumber < 1)
                throw new System.Exception("The maxNumber value should be greater than 1");
            // Generate a random number.
            uint random = CryptographicBuffer.GenerateRandomNumber();
            //create random number within maxNumber
            //this hurt my brain
            if (maxNumber < random)
            {
                uint randomMod = GetNDigits(random, (int)Math.Floor(Math.Log10(maxNumber) + 1));
                if (maxNumber < randomMod)
                {
                    return randomMod - maxNumber;
                }
                else { return randomMod; }
            }
            else { return random; }

        }

        public static string GetRandomString(int length)
        {
            string pool = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < length; i++) sb.Append(pool[Convert.ToInt32(GetRandomNumber((uint)pool.Length - 1))]);
            return sb.ToString();
        }

        public string GenerateRandomData()
        {
            // Define the length, in bytes, of the buffer.
            uint length = 32;

            // Generate random data and copy it to a buffer.
            IBuffer buffer = CryptographicBuffer.GenerateRandom(length);

            // Encode the buffer to a hexadecimal string (for display).
            string randomHex = CryptographicBuffer.EncodeToHexString(buffer);

            return randomHex;
        }

        private static uint GetNDigits(uint number, int N)
        {

            // special case for 0 as Log of 0 would be infinity
            if (number == 0)
                return number;

            // getting number of digits on this input number
            int numberOfDigits = (int)Math.Floor(Math.Log10(number) + 1);

            // check if input number has more digits than the required get first N digits
            if (numberOfDigits >= N)
                return (uint)Math.Truncate((number / Math.Pow(10, numberOfDigits - N)));
            else
                return number;
        }
    }
}

