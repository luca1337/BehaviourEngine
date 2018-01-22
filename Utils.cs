using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class Utils
    {
        public static bool IsOutOfScreen(Vector2 position) => position.X > Engine.Window.Width || position.X < 0 || position.Y > Engine.Window.Height || position.Y < 0;

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
