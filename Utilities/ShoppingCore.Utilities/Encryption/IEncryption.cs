using System.Collections.Generic;

namespace ShoppingCore.Utilities.Encryption
{
    public interface IEncryption
    {
        string EncryptString(string stringData);

        string DecryptString(string stringData);

        Dictionary<int,string> EncryptBulk(Dictionary<int, string> stringDatas);
    }
}
