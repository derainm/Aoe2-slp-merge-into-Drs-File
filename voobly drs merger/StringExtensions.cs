using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace voobly_drs_merger
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to a byte array of a specified size.
        /// The string will be encoded using UTF-8.
        /// If the string's byte representation is shorter than the desired size, it will be padded with null bytes (0x00).
        /// If the string's byte representation is longer than the desired size, it will be truncated.
        /// </summary>
        /// <param name="inputString">The string to convert.</param>
        /// <param name="size">The desired size of the byte array.</param>
        /// <returns>A byte array of the specified size containing the string's bytes.</returns>
        public static byte[] ReadBytes(this string inputString, int size)
        {
            // Get the bytes of the string using UTF-8 encoding
            byte[] stringBytes = Encoding.UTF8.GetBytes(inputString);

            // Create a new byte array of the desired size, initialized with zeros
            byte[] resultBytes = new byte[size];

            // Copy the string bytes to the result array, up to the minimum of stringBytes.Length and size
            Buffer.BlockCopy(stringBytes, 0, resultBytes, 0, Math.Min(stringBytes.Length, size));

            return resultBytes;
        }

        /// <summary>
        /// Converts a string to a byte array of a specified size, using a specified encoding.
        /// If the string's byte representation is shorter than the desired size, it will be padded with null bytes (0x00).
        /// If the string's byte representation is longer than the desired size, it will be truncated.
        /// </summary>
        /// <param name="inputString">The string to convert.</param>
        /// <param name="size">The desired size of the byte array.</param>
        /// <param name="encoding">The encoding to use for converting the string to bytes.</param>
        /// <returns>A byte array of the specified size containing the string's bytes.</returns>
        public static byte[] ReadBytes(this string inputString, int size, Encoding encoding)
        {
            // Get the bytes of the string using the specified encoding
            byte[] stringBytes = encoding.GetBytes(inputString);

            // Create a new byte array of the desired size, initialized with zeros
            byte[] resultBytes = new byte[size];

            // Copy the string bytes to the result array, up to the minimum of stringBytes.Length and size
            Buffer.BlockCopy(stringBytes, 0, resultBytes, 0, Math.Min(stringBytes.Length, size));

            return resultBytes;
        }
    }

}
