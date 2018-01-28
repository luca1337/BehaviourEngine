using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast2D;
using BehaviourEngine.Interfaces;

namespace BehaviourEngine
{
    public class SpriteRenderer : Component, IStartable, IDrawable, IUpdatable
    {
        public Texture Texture;
        public Sprite Sprite = new Sprite(50f, 50f);

        protected Transform internalTransform;

        public SpriteRenderer(Texture texture) : base()
        {
            this.Texture = texture;
        }

        bool IStartable.IsStarted { get; set; }
        public virtual void Start()
        {
            internalTransform = Transform.InitInternalTransform(this.Owner);
        }

        public virtual void Update()
        {
            this.Sprite.position = internalTransform.Position;
            this.Sprite.Rotation = internalTransform.Rotation;
            this.Sprite.scale = internalTransform.Scale;
        }

        public void SetTexture(string p)
        {
            Texture = FlyWeight.Get(p);
        }

        public int RenderOffset { get; set; }
        public virtual void Draw()
        {
            Sprite.DrawTexture(Texture);
        }
    }
}
