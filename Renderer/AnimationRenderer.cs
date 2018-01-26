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
    public class AnimationRenderer : Component, IUpdatable, IDrawable
    {
        public bool         Stop            { get; set; }
        public bool         Show            { get; set; }
        public bool         UpdatePosition  { get; set; }
        public int RenderOffset { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Texture     spriteSheet;
        private Sprite      tile;
        private int         width;
        private int         height;
        private int         tilesPerRow;
        private int[]       keyFrames;
        private float       frameLenght;
        private float       time;
        private int         currentIndex;
        private int         index;

        public AnimationRenderer(GameObject owner, Texture spriteSheet, int width, int height, int tilesPerRow,int[] keyFrames, float frameLenght, Vector2 position, bool show, bool stop, Vector2 scale = default(Vector2))
        {
            tile                = new Sprite(1f, 1f);
            tile.position       = position;
            tile.scale          = scale;
            this.tilesPerRow    = tilesPerRow;
            this.spriteSheet    = spriteSheet;
            this.width          = width;
            this.height         = height;
            this.keyFrames      = keyFrames;
            this.frameLenght    = frameLenght;
            index               = 0;
            currentIndex        = keyFrames[0];
            this.Stop           = stop;
            this.Show           = show;
            UpdatePosition      = true;
        }

        public void Draw()
        {
            if (!Show) return;

            if(UpdatePosition)
            {
                tile.scale    = Owner.Transform.Scale;
                tile.position = Owner.Transform.Position;
                tile.Rotation = Owner.Transform.Rotation;
            }
            
            int xIndex = currentIndex  % tilesPerRow;
            int yIndex = currentIndex  / tilesPerRow;

            tile.DrawTexture(spriteSheet, xIndex * width, yIndex * height, width, height);
        }

        public void Update()
        {
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
                index        = 0;
            }
        }

        public void Reset()
        {
            this.currentIndex = 0;
            index = 0;
        }
    }
}
