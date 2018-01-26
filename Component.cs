using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineBuilder;

namespace BehaviourEngine
{
    public abstract class Component : IEntity
    {
        public bool Enabled
        {
            get { return enabled && Owner.Active; }
            set { enabled = value; }
        }
        private bool enabled;

        public GameObject Owner;

        internal void SetOwner(GameObject gameObject)
        {
            Owner = gameObject;
        }
    }
}