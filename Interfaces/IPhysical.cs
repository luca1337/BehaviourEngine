using System;
using EngineBuilder;

namespace BehaviourEngine
{
    public interface IPhysical : IEntity
    {
        void PhysicsUpdate();
    }
}
