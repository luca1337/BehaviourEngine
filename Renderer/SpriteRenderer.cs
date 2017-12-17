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
    public class SpriteRenderer : Behaviour, IDrawable, IUpdatable
    {
        public Sprite sprite;

        private Texture texture;
        public Vector2 Size;
        public int TilesPerRow;

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
        public Vector2 OwnerPosition
        {
            get
            {
                return Owner != null ? Owner.Transform.Position : Vector2.Zero;
            }
            set
            {
                if (Owner == null) return;
                Owner.Transform.Position = value;
            }
        }
        public float Width => sprite.Width;
        public float Height => sprite.Height;

        public SpriteRenderer(string fileName, GameObject owner) : base(owner)
        {
            sprite = new Sprite(1, 1);
            texture = FlyWeight.Get(fileName);
        }

        public void Draw()
        {
            try
            {
                sprite.DrawTexture(texture);
            }

            catch (NullReferenceException)
            {
                throw new NullReferenceException("Probably Texture is null!");
            }
        }

        /// <summary>
        /// //check wether the sprite it's flipped or not.
        /// </summary>
        /// <returns>the flip state</returns>
        public bool GetFlip()
        {
            return sprite.FlipX;
        }

        /// Flip sprite
        /// </summary>
        /// <param name="bAxis">0 is X 1 is Y</param>
        ///// <param name="bFlip">flip or not</param> // we dont need this
        public void SetFlip(bool bAxis, bool bFlip)
        {
            if (!bAxis)
                sprite.FlipX = bFlip;
            else
                sprite.FlipY = bFlip;
        }

        public void Update()
        {
        }
    }
}
