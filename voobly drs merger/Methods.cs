 
using System;
using System.IO; 
namespace voobly_drs_merger
{



    public static class Methods
    {
        public static byte[] ReadBytes(this Stream s, int count)
        {
            byte[] buffer = count >= 0 ? new byte[count] : throw new ArgumentOutOfRangeException(nameof(count), "Non-negative number required.");
            if (s.Read(buffer, 0, count) < count)
                throw new EndOfStreamException();
            return buffer;
        }

        public static byte ToByte(this int i) => BitConverter.GetBytes(i)[0];

        public static uint ReadUInt32(this Stream s) => BitConverter.ToUInt32(s.ReadBytes(4), 0);
    }

}