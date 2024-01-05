using System.Security.Cryptography;
using System.Text;

namespace DataProtectionOnServer.Security
{
    public class DataProtector
    {
        private string path;
        private byte[] entropy;

        public DataProtector(string path)
        {
            this.path = path;
            entropy = RandomNumberGenerator.GetBytes(16);

        }

        public int EncryptData(string value)
        {
            //value -> byte[]
            //FileStream verilecek.
            var encodedData = Encoding.UTF8.GetBytes(value);
            using var fileStream = new FileStream(path, FileMode.OpenOrCreate);
            int length = encryptDataToFile(encodedData, entropy, DataProtectionScope.CurrentUser, fileStream);
            return length;

        }

        private int encryptDataToFile(byte[] encodedData, byte[] entropy, DataProtectionScope scope, FileStream fileStream)
        {
            var encrypted = ProtectedData.Protect(encodedData, entropy, scope);
            if (fileStream.CanWrite && encrypted != null)
            {
                fileStream.Write(encrypted, 0, encrypted.Length);
            }

            return encrypted.Length;

            // ProtectedData.Unprotect()
        }

        public string DecryptData(int length)
        {
            using FileStream fileStream = new FileStream(path, FileMode.Open);
            byte[] decrypt = decryptDataFromFile(fileStream, entropy, DataProtectionScope.CurrentUser, length);
            return Encoding.UTF8.GetString(decrypt);


        }

        private byte[] decryptDataFromFile(FileStream fileStream, byte[] entropy, DataProtectionScope currentUser, int length)
        {
            var input = new byte[length];
            var output = new byte[length];

            if (fileStream.CanRead)
            {
                fileStream.Read(input, 0, input.Length);
                output = ProtectedData.Unprotect(input, entropy, currentUser);

            }

            return output;

        }
    }
}
