using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public class Behaviour
    {
        public bool Enabled;
        public GameObject Owner { get; protected set; }

        protected Behaviour(GameObject owner)
        {
            this.Owner = owner;
            Enabled = true;
        }
    }
}