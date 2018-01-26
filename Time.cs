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
        //public static float DeltaTime => Engine.Pause ? DeltaPause : Graphics.Instance.Window.deltaTime;
        public static float DeltaTime => Graphics.Instance.Window.deltaTime;
        public static float DeltaPause => Graphics.Instance.Window.deltaTime * 0;
        public static Vector2 Half => new Vector2(Width, Height) * 0.5f;
        public static float Width => Graphics.Instance.Window.Width;
        public static float Height => Graphics.Instance.Window.Height;
    }
}
