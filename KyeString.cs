using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using System.Management;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Kye
{
    public class KyeString
    {
        public static string GetIP()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    return web.DownloadString("http://ip-api.com/line/?fields=8192");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
           
        }
        public static string GetHWID()
        {
            return GetSha256(GetMachineGuid() + GetCPUID());
        }

        private static string GetCPUID()
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            foreach (ManagementObject mo in mbsList)
            {
                return mo["ProcessorId"].ToString();
            }
            return "none";
        }

        private static string GetMachineGuid()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        throw new KeyNotFoundException(
                            string.Format("Key Not Found: {0}", location));

                    object machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException(
                            string.Format("Index Not Found: {0}", name));

                    return machineGuid.ToString();
                }
            }
        }
        static string GetSha256(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
        public static string RandomStringWithoutNumbers(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string Encodebase64(string TextToEncode)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(TextToEncode);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static string DecodeBase64(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string GetMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        
        public static string GetThisMD5()
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(AppDomain.CurrentDomain.FriendlyName))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        public static string InstalledRAM()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            double res;
            double fres = 0;
            foreach (ManagementObject result in results)
            {
                res = Convert.ToDouble(result["TotalVisibleMemorySize"]);
                fres = Math.Round((res / (1024 * 1024)), 2);
            }
            return fres + "GB";
        }

        public static string[] GetGPU()
        {
            string gpu = "";
            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in objvide.Get())
            {
                if (obj["Name"].ToString().All(char.IsLetterOrDigit));
                {
                    gpu += obj["Name"] + "|".ToString();
                }
            }
            string[] gpus = gpu.Split('|');
            return gpus;
        }

        public static string ReadLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }

        public static string GetCountry()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    return web.DownloadString("http://ip-api.com/line/?fields=1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }

        }
    }
}
