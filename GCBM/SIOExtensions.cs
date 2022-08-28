using System.IO;
using System.Text;

namespace GCBM
{
    public static class SIOExtensions
    {
        private static int resI;
        private static int resH;
        private static string resS;
        private static int i;
        private static byte b;

        public static int ReadInt32BE(this BinaryReader br)
        {
            i = br.ReadByte();
            resI = i << 0x18;
            i = br.ReadByte();
            resI += i << 0x10;
            i = br.ReadByte();
            resI += i << 0x08;
            i = br.ReadByte();
            resI += i;

            return resI;
        }

        public static string ReadStringNT(this BinaryReader br)
        {
            resS = "";
            b = br.ReadByte();

            while (b != 0)
            {
                resS += Encoding.Default.GetChars(new[] { b })[0];
                b = br.ReadByte();
            }

            return resS;
        }

        public static string ToStringC(char[] chars)
        {
            resS = "";
            resH = chars.Length;

            for (int resI = 0; resI < resH; resI++)
            {
                if (chars[resI] == '\n')
                {
                    resS += '\r';
                }

                resS += chars[resI];
            }

            return resS;
        }
    }
}