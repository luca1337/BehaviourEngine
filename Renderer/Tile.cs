using Aiv.Fast2D;
using OpenTK;
using BehaviourEngine.Interfaces;
using System;

namespace BehaviourEngine.Renderer
{
    public class Tile : GameObject, IPhysical
    {
        private Sprite sprite;
        public Vector2 Position
        {
            get
            {
                return sprite.position;
            }
            set
            {
                sprite.position = value;
            }
        }

        public BoxCollider BoxCollider { get; set; }

        public Tile(Vector2 position) : base((int)RenderLayer.Level, "Wall")
        {
            sprite       = new Sprite(1, 1);
            Position     = position;
            BoxCollider  = new BoxCollider(position, 1, 1, this);
            AddBehaviour<BoxCollider>(BoxCollider);
        }

        public void OnIntersect(IPhysical other)
        {
            if (other is Tile)
                return;
            Console.WriteLine(this.ToString() + "Collided with:" + other.ToString());
        }
    }
}
