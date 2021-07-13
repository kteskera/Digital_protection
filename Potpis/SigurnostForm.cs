using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Potpis
{
    public partial class SigurnostForm : Form
    {
        public SigurnostForm()
        {
            InitializeComponent();
        }
        #region Inicijalizacija
        byte[] _Key, _IV;
        string xml;
        string xml2;
        #endregion

        private void symmetricEncryptionBtn_Click(object sender, EventArgs e)
        {
            using (Aes myAes = Aes.Create())
            {
                _Key = myAes.Key;
                _IV = myAes.IV;
                string Key = Convert.ToBase64String(myAes.Key);
                string IV = Convert.ToBase64String(myAes.IV);
                string simetricniKljuc = @"C:\Users\Karlo\Desktop\Potpis\SymmetricKey.txt";
                string simetricniIV = @"C:\Users\Karlo\Desktop\Potpis\SymmetricIV.txt";
                File.WriteAllText(simetricniKljuc, Key);
                File.WriteAllText(simetricniIV, IV);

                var fileContent = string.Empty;
                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = @"C:\Users\Karlo\Desktop\Potpis\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        var fileStream = openFileDialog.OpenFile();
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                            textBox1.Text = fileContent;
                        }
                    }
                }
                byte[] encrypted = EncryptStringToBytes_Aes(fileContent, myAes.Key, myAes.IV);
                textBox2.Text = Convert.ToBase64String(encrypted);
                string kriptiraniTekst = @"C:\Users\Karlo\Desktop\Potpis\SymmetricEncryptedText.txt";
                File.WriteAllText(kriptiraniTekst, Convert.ToBase64String(encrypted));

            }
        }

        private void symmetricDecryption_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\\Users\Karlo\Desktop\Potpis\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        textBox1.Text = fileContent;
                    }
                }
            }
            string enkriptiraniTekstPutanja = @"C:\Users\Karlo\Desktop\Potpis\SymmetricEncryptedText.txt";
            string EnkriptiraniTekst = File.ReadAllText(enkriptiraniTekstPutanja);
            string dekriptiraniTeksr = DecryptStringFromBytes_Aes(Convert.FromBase64String(EnkriptiraniTekst), _Key, _IV);
            textBox1.Text = EnkriptiraniTekst;
            textBox2.Text = dekriptiraniTeksr;
            string dekrtiptiraniTekst = @"C:\Users\Karlo\Desktop\Potpis\SymmetricDecryptedText.txt";
            File.WriteAllText(dekrtiptiraniTekst, dekriptiraniTeksr);

        }

        #region AES metode za kriptiranje i dekriptiranje
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
        #endregion

        private void asymetricEncryptionBtn_Click(object sender, EventArgs e)
        {
            try
            {

                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                var fileContent = string.Empty;
                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = @"C:\Users\Karlo\Desktop\Potpis\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                            textBox1.Text = fileContent;
                        }
                    }
                }
                byte[] encryptedData;
                byte[] dataToEncrypt = ByteConverter.GetBytes(fileContent);

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    var rsaKeyPair = DotNetUtilities.GetRsaKeyPair(RSA);
                    var writer1 = new StringWriter();
                    var writer2 = new StringWriter();
                    var pemWriter1 = new PemWriter(writer1);
                    var pemWriter2 = new PemWriter(writer2);
                    pemWriter1.WriteObject(rsaKeyPair.Public);
                    pemWriter2.WriteObject(rsaKeyPair.Private);

                    xml = RSA.ToXmlString(true);
                    string path2 = @"C:\Users\Karlo\Desktop\Potpis\AsymetricPrivateKey.txt";
                    File.WriteAllText(path2, writer2.ToString());
                    string path3 = @"C:\Users\Karlo\Desktop\Potpis\AsymetricPublicKey.txt";
                    File.WriteAllText(path3, writer1.ToString());


                    encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                    textBox2.Text = ByteConverter.GetString(encryptedData);

                    string path4 = @"C:\Users\Karlo\Desktop\Potpis\AsymetricEncryptedText.txt";
                    File.WriteAllBytes(path4, encryptedData);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void asymetricDecryptionBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\Karlo\Desktop\Potpis\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                      
                    }
                }
            }
            
            textBox1.Text = ByteConverter.GetString(File.ReadAllBytes(filePath));
            byte[] kriptirani = File.ReadAllBytes(filePath);
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(xml);

            byte[] decryptedData = RSADecrypt(kriptirani, RSA.ExportParameters(true), false);
            string dekriptiraniTekstPutanja = @"C:\Users\Karlo\Desktop\Potpis\AsymetricDecryptedText.txt";

           
            File.WriteAllText(dekriptiraniTekstPutanja, ByteConverter.GetString(decryptedData));
            textBox2.Text = ByteConverter.GetString(decryptedData);
        }

        #region RSA metode kriptiranje i dekriptiranje
        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }

            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }

            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);

                return null;
            }
        }
        #endregion

        private void sazetakPorukeBtn_Click(object sender, EventArgs e)
        {

            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\Karlo\Desktop\Potpis\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        textBox1.Text = fileContent;
                    }
                }
            }
            string has;
            using (FileStream stream = File.OpenRead(filePath))
            {
                SHA512Managed sha = new SHA512Managed();
                byte[] hash = sha.ComputeHash(stream);
                has = BitConverter.ToString(hash).Replace("-", String.Empty);
            }
            string sazetakDatoteke = @"C:\Users\Karlo\Desktop\Potpis\SHA512.txt";
            File.WriteAllText(sazetakDatoteke, has);
            textBox1.Text = fileContent;
            textBox2.Text = has;
        }

        private void digitalniPotpisBtn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\Karlo\Desktop\Potpis\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        textBox1.Text = fileContent;
                    }
                }
            }


            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            xml2 = RSA.ToXmlString(true);
            string messageToSign = fileContent;
            string signedMessage = SignFile(messageToSign, RSA.ExportParameters(true));
            string potpis = @"C:\Users\Karlo\Desktop\Potpis\Signature.txt";
            File.WriteAllText(potpis, signedMessage);
            textBox2.Text = "Datoteka je digitalno potpisana!";
        }

        private void provjeraPotpisaBtn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\Karlo\Desktop\Potpis\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        textBox1.Text = fileContent;
                    }
                }
            }
            textBox1.Text = fileContent;
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(xml2);
            string potpis = @"C:\Users\Karlo\Desktop\Potpis\Signature.txt";
            string potpisanaPoruka = File.ReadAllText(potpis);
            bool success = VerifyFile(fileContent, potpisanaPoruka, RSA.ExportParameters(false));
            if (success == false)
            {
                textBox2.Text = "Provjera nije uspješna!";
            }
            else
            {
                textBox2.Text = "Provjera je uspješna!";
            }

        }

        #region Metode digitalni potpis i provjera potpisa

        public static string SignFile(string message, RSAParameters privateKey)
        {
            byte[] signedBytes;
            using (var rsa = new RSACryptoServiceProvider())
            {
                var encoder = new UTF8Encoding();
                byte[] originalData = encoder.GetBytes(message);
                try
                {
                    rsa.ImportParameters(privateKey);
                    signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA512"));
                }
                catch (CryptographicException e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            return Convert.ToBase64String(signedBytes);
        }

        public static bool VerifyFile(string originalMessage, string signedMessage, RSAParameters publicKey)
        {
            bool success = false;
            using (var rsa = new RSACryptoServiceProvider())
            {
                var encoder = new UTF8Encoding();
                byte[] bytesToVerify = encoder.GetBytes(originalMessage);
                byte[] signedBytes = Convert.FromBase64String(signedMessage);
                try
                {
                    rsa.ImportParameters(publicKey);
                    SHA512Managed Hash = new SHA512Managed();
                    byte[] hashedData = Hash.ComputeHash(signedBytes);
                    success = rsa.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA512"), signedBytes);
                }
                catch (CryptographicException e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            return success;
        }

        #endregion
    }
}
