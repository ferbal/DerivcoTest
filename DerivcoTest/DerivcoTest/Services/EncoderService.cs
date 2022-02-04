using DerivcoTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivcoTest.Services
{
    public class EncoderService
    {        
        private char[] transcode;
        public EncoderService()
        {
        }

        private char[] GetKeyCode()
        {
            if (this.transcode == null)
                this.PrepeareKey();

            return this.transcode;
        }

        public bool CompareString(string testString)
        {
            if (testString == null)
                throw new Exception("The String should not be null");

            return String.Compare(testString, Codificator.Decode(Codificator.Encode(testString, this.GetKeyCode()), this.GetKeyCode())) == 0;
        }
        public bool CompareString(string originalString, string encodedString, string key)
        {
            if (originalString == null || encodedString == null)
                throw new Exception("The String should not be null");

            return String.Compare(originalString, Codificator.Decode(encodedString, ConvertStringToKey(key))) == 0;
        }

        public string Encode(string originalString, string key = null)
        {
            if (originalString == null || key == null)
                throw new Exception("The String should not be null");

            return Codificator.Encode(originalString, ConvertStringToKey(key) ?? this.GetKeyCode());
        }        

        private char[] ConvertStringToKey(string content)
        {
            var key = new char[65];

            for (int i = 0; i < key.Length-1; i++)
            {
                if (i <= content.ToCharArray().Length-1)
                    key[i] = (char)content.ToCharArray()[i];
                else
                    key[i] = '=';                
            }

            return key;
        }
    
        private void PrepeareKey()
        {
            this.transcode = new char[65];

            for (int i = 0; i < this.transcode.Length -1 ; i++)
            {
                this.transcode[i] = (char)((int)'A' + i);
                if (i > 25) this.transcode[i] = (char)((int)this.transcode[i] + 6);
                if (i > 51) transcode[i] = (char)((int)this.transcode[i] - 0x4b);
            }
            this.transcode[this.transcode.Length - 4] = '+';
            this.transcode[this.transcode.Length - 3] = '/';
            this.transcode[this.transcode.Length - 2] = '=';
        }

        
    }
}
