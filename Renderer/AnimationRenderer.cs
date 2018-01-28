using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
using BehaviourEngine;
using BehaviourEngine.Interfaces;

namespace BomberMan
{
    public class AnimationRenderer : Component, IStartable, IDrawable, IUpdatable
    {
        public bool         Stop            { get; set; }
        public bool         Show            { get; set; }
        public bool         UpdatePosition  { get; set; }
        public int          RenderOffset    { get; set; }
        public Vector2 Size => new Vector2(width, height);
        protected Transform internalTransform;

        public bool IsStarted { get; set; }

        private Texture     spriteSheet;
        private Sprite      sprite;
        private int         width;
        private int         height;
        private int         tilesPerRow;
        private int[]       keyFrames;
        private float       frameLenght;
        private float       time;
        private int         currentIndex;
        private int         index;

        public virtual void Start()
        {
            internalTransform = Transform.InitInternalTransform(this.Owner);
        }

        public AnimationRenderer(Texture spriteSheet, int width, int height, int tilesPerRow, int[] keyFrames, float frameLenght, bool show, bool stop) : base()
        {
            sprite              = new Sprite(1f, 1f);
            this.tilesPerRow    = tilesPerRow;
            this.spriteSheet    = spriteSheet;
            this.width          = width;
            this.height         = height;
            this.keyFrames      = keyFrames;
            this.frameLenght    = frameLenght;
            this.Stop           = stop;
            this.Show           = show;
            index               = 0;
            currentIndex        = keyFrames[0];
        }

        public virtual void Update()
        {
            this.sprite.position = internalTransform.Position;
            this.sprite.Rotation = internalTransform.Rotation;
            this.sprite.scale = internalTransform.Scale;

            if (Stop)
                return;

            time += Time.DeltaTime;
            if (time > frameLenght)
            {
                time = 0f;
                currentIndex = keyFrames[index];
                index++;
            }
            else
                return;

            if (index > keyFrames.Length - 1)
            {
                currentIndex = keyFrames[0];
                index = 0;
            }
        }

        public virtual void Draw()
        {
            if (!Show) return;

            int xIndex = currentIndex  % tilesPerRow;
            int yIndex = currentIndex  / tilesPerRow;

            sprite.DrawTexture(spriteSheet, xIndex * width, yIndex * height, width, height);
        }

        public void Reset()
        {
            this.currentIndex = 0;
            index = 0;
        }
    }
}
