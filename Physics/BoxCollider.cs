using OpenTK;
using Aiv.Fast2D;
using BehaviourEngine.Interfaces;
using System;

namespace BehaviourEngine
{
    public class BoxCollider : Component, IDrawable /*, IUpdatable*/
    {
        public Vector2 Position { get { return mesh.position; } set { mesh.position = value; } }

        public Vector2 Offset;
        public float Width { get; private set; }
        public float Height { get; private set; }
        public Vector2 Center { get { return Position + Half; } }
        public Vector2 Half { get { return new Vector2(Width * 0.5f, Height * 0.5f); } }

        public float Rotation { get { return mesh.Rotation; } set { mesh.Rotation = value; } }

        private Mesh mesh;

        //Added
        public bool IsTrigger { get; set; }

        public BoxCollider(float width, float height)
        {
            this.Width  = width;
            this.Height = height;
            this.mesh   = new Mesh();
            this.mesh.v = new float[]
            {
                owner.Transform.Position.X, owner.Transform.Position.Y,
                owner.Transform.Position.X + width, owner.Transform.Position.Y,
                owner.Transform.Position.X, owner.Transform.Position.Y + height,
                owner.Transform.Position.X + width, owner.Transform.Position.Y,
                owner.Transform.Position.X, owner.Transform.Position.Y + height,
                owner.Transform.Position.X + width, owner.Transform.Position.Y + height
            };
            mesh.pivot    = owner.Transform.Position;
            mesh.position = owner.Transform.Position;
            this.Position = Owner.Transform.Position + Offset;
            mesh.Update();
        }

        public void Draw()
        {
            //mesh.DrawWireframe(1f, 0f, 0f);
        }
    }
}
