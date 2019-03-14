using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Utilities.Encryption
{
    public class Encryption : IEncryption
    {
        public string EncryptString(string stringData)
        {
            return stringData;
        }

        public string DecryptString(string stringData)
        {
            return stringData;
        }

        public Dictionary<int, string> EncryptBulk(Dictionary<int, string> stringDatas)
        {
            return stringDatas;
        }
    }
}
