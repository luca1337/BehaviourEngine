using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BehaviourEngine
{
    public class Transform : Behaviour
    {
        public Vector2 Position;
        public float Rotation;

        public float EulerRotation
        {
            get
            {
                //deg
                return Rotation.RadToDeg();
            }
            set
            {
                //rad
                Rotation = value.DegToRad();
            }
        }
        public Vector2 Scale = Vector2.One;

        public Transform(GameObject owner) : base(owner) { }
    }
}
