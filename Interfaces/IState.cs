using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public interface IState
    {
        //Don' t do the Update in OnStateEnter method

        void OnStateEnter();
        void OnStateExit();
        IState OnStateUpdate();
    }
}
