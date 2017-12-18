using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class Generator
    {
        /// <summary>
        /// Generate a new *.csv level
        /// </summary>
        /// <param name="originalPath"></param>
        /// <param name="newPath"></param>
        /// <param name="oldVal"></param>
        /// <param name="newVal"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void GenerateLevel(string originalPath, string newPath, string oldVal, int min, int max)
        {
            Validate(min, max);
            uint rnd = (uint)RandomManager.Instance.Random.Next(min, max);
            string str = File.ReadAllText(originalPath);
            str = str.Replace(oldVal, rnd.ToString());
            File.WriteAllText(newPath, str);
        }

        internal static void Validate(int val0, int val1)
        {
            if (val0 < 0 || val1 < 0)
                throw new Exception("Numbers must be unsigned int values instead.");
        }
    }
}
