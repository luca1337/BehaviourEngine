using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class Time
    {
        public static float DeltaTime => Engine.Pause ? DeltaPause : Engine.Window.deltaTime;
        public static float DeltaPause => Engine.Window.deltaTime * 0;
        public static Vector2 Half => new Vector2(Width, Height) * 0.5f;
        public static float Width => Engine.Window.Width;
        public static float Height => Engine.Window.Height;
    }
}
