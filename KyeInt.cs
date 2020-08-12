using System;
namespace Kye
{
    public class KyeInt
    {
        public static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static int GetGPUCount()
        {
            int gpucount = KyeString.GetGPU().Length - 1;
            return gpucount;
        }
    }
}
