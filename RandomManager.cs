using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public sealed class RandomManager
    {
        private static RandomManager instance;
        public static RandomManager Instance => instance ?? (instance = new RandomManager());

        private RandomManager()
        {
            Random = new Random();
        }

        public Random Random;
    }
}
