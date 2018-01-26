using System;
using System.Collections.Generic;
using System.Linq;
using EngineBuilder;

namespace BehaviourEngine
{
    interface ISystem
    {
        int UpdateOffset { get; set; }
        void Update();
        void Add(IEntity entity);
        void Remove(IEntity entity);
    }
}
