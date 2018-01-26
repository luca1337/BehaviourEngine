using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine.Interfaces;

namespace BehaviourEngine
{
    public class Rigidbody2D : Component, IPhysical
    {
        public Vector2 Velocity;
        public bool IsGravityAffected = true;
        public float LinearFriction;

        void IPhysical.PhysicsUpdate()
        {
            if (IsGravityAffected)
            {
                this.AddForce(Physics.Instance.Gravity);
            }

            this.AddForce(-Velocity * LinearFriction);

            Owner.Transform.Position += Velocity * Time.DeltaTime;
        }

        public void AddForce(Vector2 force)
        {
            Velocity += force * Time.DeltaTime;
        }
    }
}
