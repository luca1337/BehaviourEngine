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
    }
}
