using System.Diagnostics;
using System.Net;
using System.Collections.Specialized;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
namespace Kye
{
    public class KyeFunction
    {
        public static void sendDiscordWebhook(string URL, string profilepic, string username, string message)
        {
            using (WebClient web = new WebClient())
            {
                NameValueCollection discordValues = new NameValueCollection();
                discordValues.Clear();
                discordValues.Add("username", username);
                discordValues.Add("avatar_url", profilepic);
                discordValues.Add("content", message);
                web.UploadValues(URL, discordValues);
            }
        }
        public static void CheckForMalicious()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Contains("Fiddler") | theprocess.ProcessName.Contains("HTTP") && theprocess.ProcessName.Contains("Debug"))
                    theprocess.Kill();
            }
        }

        public static void CheckMD5(string url_with_official_md5, [Optional] string optional_message_to_show_when_modified)
        {
            WebClient webClient = new WebClient();
            string websitehash = webClient.DownloadString(url_with_official_md5);
            string programhash = KyeString.GetThisMD5();
            string programname = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "");
            if (!websitehash.Contains(programhash))
            {
                if (optional_message_to_show_when_modified == null)
                {
                    MessageBox.Show("This program has been modified and is NOT official. Please download the original one", programname,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show(optional_message_to_show_when_modified, programname, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            webClient.Dispose();
        }

        public static void DeleteFile(string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
        }

        public static void WriteLine(string filepath, string newText, int line_to_edit)
        {
            string programname = AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "");
            try
            {
            string[] arrLine = File.ReadAllLines(filepath, Encoding.UTF8);
            arrLine[line_to_edit - 1] = newText;
                File.WriteAllLines(filepath, arrLine);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Line " + line_to_edit + " does not exist in " + filepath, programname, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, programname, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
