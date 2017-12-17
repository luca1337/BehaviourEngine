using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine.Interfaces;

namespace BehaviourEngine
{
    public class RigidBody : Behaviour, IUpdatable
    {
        public Vector2 Velocity { get; set; }

        public float LinearFriction { get { return linearFriction; } set { linearFriction = MathHelper.Clamp(value, 0f, 1f); } }

        private float linearFriction;
        public RigidBody(GameObject owner) : base(owner)
        {
        }

        void IUpdatable.Update()
        {
            AddForce(-Velocity * linearFriction);
            Owner.Transform.Position += Velocity;
        }

        public void AddForce(Vector2 force)
        {
            Velocity += force * Time.DeltaTime;
        }
    }
}
