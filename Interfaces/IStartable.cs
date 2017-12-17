using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public interface IStartable
    {
        void Start();
        bool IsStarted { get; set; }

    }
}
