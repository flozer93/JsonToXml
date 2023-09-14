using System;
using System.Security.Cryptography;
using System.Text;

namespace JsonToXml_Config
{
    public class Secret
    {
        private SymmetricAlgorithm sa = (SymmetricAlgorithm)new RijndaelManaged();
        private string schl = "a4SX1dVfADEGHHlkYImZpdnYhDynpPKD";
        private string iv = "rBgUR4pO9im5nJxW";

        public string Encrypt(string source)
        {
            switch (source)
            {
                case "":
                    return "";

                case null:
                    return "";

                default:
                    try
                    {
                        ICryptoTransform encryptor = this.sa.CreateEncryptor(Encoding.ASCII.GetBytes(this.schl), Encoding.ASCII.GetBytes(this.iv));
                        byte[] bytes = Encoding.ASCII.GetBytes(source);
                        return Convert.ToBase64String(encryptor.TransformFinalBlock(bytes, 0, bytes.Length));
                    }
                    catch (FormatException ex)
                    {
                        return "";
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
            }
        }

        public string Decrypt(string encrypted)
        {
            switch (encrypted)
            {
                case "":
                    return "";

                case null:
                    return "";

                default:
                    try
                    {
                        ICryptoTransform decryptor = this.sa.CreateDecryptor(Encoding.ASCII.GetBytes(this.schl), Encoding.ASCII.GetBytes(this.iv));
                        byte[] inputBuffer = Convert.FromBase64String(encrypted);
                        byte[] bytes = decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                        return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    }
                    catch (FormatException ex)
                    {
                        return "";
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
            }
        }
    }
}