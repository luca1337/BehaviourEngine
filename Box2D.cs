using OpenTK;
using Aiv.Fast2D;
using BehaviourEngine.Interfaces;

namespace BehaviourEngine
{
    public class Box2D : Behaviour, IDrawable
    {
        public Vector2 Position { get { return mesh.position; } set { mesh.position = value; } }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public Vector2 Center { get { return Position + Half; } }
        public Vector2 Half { get { return new Vector2(Width * 0.5f, Height * 0.5f); } }

        public float Rotation { get { return mesh.Rotation; } set { mesh.Rotation = value; } }

        private Mesh mesh;

        public Box2D(Vector2 position, float width, float height, GameObject owner) : base(owner)
        {
            this.Width = width;
            this.Height = height;

            this.mesh = new Mesh();
            this.mesh.v = new float[]
            {
                position.X, position.Y,
                position.X + width, position.Y,
                position.X, position.Y + height,
                position.X + width, position.Y,
                position.X, position.Y + height,
                position.X + width, position.Y + height
            };
            mesh.pivot = position;
            mesh.position = position;
            mesh.Update();
        }

        public void Draw()
        {
            mesh.DrawWireframe(1f, 0f, 0f);
        }
    }
}
