using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivcoTest.Helpers
{
    public static class Codificator
    {
        public static string Encode(string input, char[] transcode)
        {
            try
            {
                int l = input.Length;
                int cb = (l / 3 + (Convert.ToBoolean(l % 3) ? 1 : 0)) * 4;

                char[] output = new char[cb];
                for (int i = 0; i < cb; i++)
                {
                    output[i] = '=';
                }

                int c = 0;
                int reflex = 0;
                const int s = 0x3f;

                for (int j = 0; j < l; j++)
                {
                    reflex <<= 8;
                    reflex &= 0x00ffff00;
                    reflex += input[j];

                    int x = ((j % 3) + 1) * 2;
                    int mask = s << x;
                    while (mask >= s)
                    {
                        int pivot = (reflex & mask) >> x;
                        output[c++] = transcode[pivot];
                        int invert = ~mask;
                        reflex &= invert;
                        mask >>= 6;
                        x -= 6;
                    }
                }

                switch (l % 3)
                {
                    case 1:
                        reflex <<= 4;
                        output[c++] = transcode[reflex];
                        break;
                    case 2:
                        reflex <<= 2;
                        output[c++] = transcode[reflex];
                        break;
                }

                Console.WriteLine("{0} --> {1}\n", input, new string(output));
                return new string(output);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static string Decode(string input, char[] code)
        {
            int l = input.Length;
            int cb = (l / 4 + ((Convert.ToBoolean(l % 4)) ? 1 : 0)) * 3 + 1;
            char[] output = new char[cb];
            int c = 0;
            int bits = 0;
            int reflex = 0;
            for (int j = 0; j < l; j++)
            {
                reflex <<= 6;
                bits += 6;
                bool fTerminate = ('=' == input[j]);
                if (!fTerminate)
                    reflex += IndexOf(code, input[j]);

                while (bits >= 8)
                {
                    int mask = 0x000000ff << (bits % 8);
                    output[c++] = (char)((reflex & mask) >> (bits % 8));
                    int invert = ~mask;
                    reflex &= invert;
                    bits -= 8;
                }

                if (fTerminate)
                    break;
            }
            Console.WriteLine("{0} --> {1}\n", input, new string(output));
            return new string(output);
        }
        private static int IndexOf(char[] code, char ch)
        {
            int index;
            for (index = 0; index < code.Length; index++)
                if (ch == code[index])
                    break;
            return index;
        }
    }
}
