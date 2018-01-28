using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Utils
{
    public class Utils
    {
        public static float GenerateRandomFloatInRange(float max, float min)
        {
            return (float)RandomManager.Instance.Random.NextDouble() * (max - min) + min;
        }

        public static double GenerateRandomDoubleInRange(double max, double min)
        {
            return RandomManager.Instance.Random.NextDouble() * (max - min) + min;
        }

        public static int GenerateRandomIntInRange(int max, int min)
        {
            return RandomManager.Instance.Random.Next(max, min);
        }

        public static bool IsOutOfScreen(Vector2 position) => position.X > Graphics.Instance.Window.Width || position.X < 0 || position.Y > Graphics.Instance.Window.Height || position.Y < 0;

        public static T Clamp<T>(T value, T max, T min) where T : IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }
    }
}
