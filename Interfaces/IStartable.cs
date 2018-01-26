using EngineBuilder;

namespace BehaviourEngine
{
    public interface IStartable : IEntity
    {
        void Start();
        bool IsStarted { get; set; }

    }
}
