using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Interfaces
{
    public interface IState
    {
        GameObject Owner {get;set;}
        void OnStateEnter();
        void OnStateExit();
        IState OnStateUpdate();
    }
}
