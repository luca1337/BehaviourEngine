using Aiv.Fast2D;
using OpenTK;
using BehaviourEngine.Interfaces;
using System;

namespace BehaviourEngine.Renderer
{
    public class Tile : GameObject, IPhysical
    {
        public BoxCollider BoxCollider { get; set; }
        private SpriteRenderer renderer;
        public Tile(string fileName, Vector2 position) : base((int)RenderLayer.Level, "Wall")
        {
            Transform.Position = position;
            renderer     = new SpriteRenderer(fileName, this);
            BoxCollider  = new BoxCollider(renderer.Width, renderer.Height, this);

            AddBehaviour<SpriteRenderer>(renderer);
            AddBehaviour<BoxCollider>(BoxCollider);
        }

        public void OnIntersect(IPhysical other)
        {
            if (other is Tile)
                return;

            //Console.WriteLine(this.ToString() + "Collided with:" + other.ToString());
        }

        public void OnTriggerEnter(IPhysical other)
        {
            if (other is Tile)
                return;

            Console.WriteLine("wall");
        }
    }
}
