using System;
using System.Net;
namespace Kye
{
    public static class KyeBool
    {
        public static bool HasInternet()
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string a = webClient.DownloadString("https://google.com");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool RandomBool()
        {
            Random rng = new Random();
            return rng.Next(0, 2) > 0;
        }
    }
}
