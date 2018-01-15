using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class ExtensionMethod
    {
        //float
        public static float RadToDeg(this float fRad) => 180f / MathHelper.Pi * fRad;
        public static float DegToRad(this float fDeg) => MathHelper.Pi / 180f * fDeg;

        //vec3
        public static Vector3 Forward(this Vector3 v) => v = new Vector3(0f, 0f, 1f); 
        public static Vector3 Right(this Vector3 v) => v = new Vector3(1f, 0f, 0f);

        //vec2
        public static Vector2 Forward(this Vector2 v) => v = new Vector2(0f, -1f);
        public static Vector2 Right(this Vector2 v) => v = new Vector2(-1f, 0f);
    }
}
