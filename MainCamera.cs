using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    public class MainCamera : GameObject
    {
        private Camera mainCam;

        public MainCamera(float posX, float posY, bool centerPivot = false) : base((int)RenderLayer.Pawn, "main", "Main Camera")
        {
            mainCam = new Camera();

            if (centerPivot)
            {
                float halfOrthoWidth = Engine.Window.OrthoWidth * 0.5f;
                float halfOrthoHeight = Engine.Window.OrthoHeight * 0.5f;
                mainCam.pivot = new Vector2(halfOrthoWidth, halfOrthoHeight);
                mainCam.position += mainCam.pivot;
            }

            mainCam.position = new Vector2(posX, posY);

            Engine.SetCamera(mainCam);

            //TODO: replace this with the sceneManager method
            Engine.Spawn(this);
        }
    }
}
