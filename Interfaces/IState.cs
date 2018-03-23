using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Interfaces
{
    public interface IState
    {
        //Don' t do the Update in the enter point of the state

        //you are dyslexic bro :p

        void OnStateEnter();
        void OnStateExit();
        IState OnStateUpdate();
    }
}
