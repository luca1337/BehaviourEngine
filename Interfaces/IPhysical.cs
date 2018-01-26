using System;
using EngineBuilder;

namespace BehaviourEngine.Interfaces
{
    public interface IPhysical : IEntity
    {
        void PhysicsUpdate();
    }
}
