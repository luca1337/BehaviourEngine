using EngineBuilder;
using OpenTK;
using BehaviourEngine.Interfaces;
using System;

namespace BehaviourEngine.Renderer
{
    public class Tile : GameObject, IPhysical
    {
        private SpriteRenderer renderer;
        public Tile(string fileName, Vector2 position) : base("Tile")
        {
            Transform.Position = position;
            renderer     = new SpriteRenderer(FlyWeight.Get(fileName));

            AddComponent(renderer);
        }

        public bool Enabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void PhysicsUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
