using EngineBuilder;

namespace BehaviourEngine.Interfaces
{
    public interface IDrawable : IEntity
    {
        int RenderOffset { get; set; }
        void Draw();
    }
}
