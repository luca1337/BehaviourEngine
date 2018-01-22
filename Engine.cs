using System;
using System.Collections.Generic;
using Aiv.Fast2D;
using Aiv.Fast2D.Utils.Input;
using BehaviourEngine.Interfaces;

namespace BehaviourEngine
{
    public enum RenderLayer
    {
        None = -1,
        Gui = 0,
        Pawn = 1,
        Level = 100,
        Background = 1000
    }

    public static class Engine
    {
        //Public
        public static bool IsRunning => Window.IsOpened;
        public static Window Window;
        public const string LevelPath = "Levels";
        public const string SoundPath = "Sounds";
        public static bool Pause;
        public static List<IPhysical> PhysicalObjects => physicalObjects;

        //Private
        private static Queue<GameObject> waitForSpawnObjs;
        private static List<IPhysical> physicalObjects;

        static Engine()
        {
            waitForSpawnObjs    = new Queue<GameObject>();
            physicalObjects     = new List<IPhysical>();
        }

        public static void CreateContext(int width, int height, string title, float orthoSize = 0.0f, float r = 0f, float g = 0f, float b = 0f)
        {
            Window = new Window(width, height, title);
            Window.SetClearColor(r, g, b);
            Window.SetDefaultOrthographicSize(orthoSize);
            Window.SetVSync(false);
        }

        public static GameObject Spawn(GameObject gameObject)
        {
            waitForSpawnObjs.Enqueue(gameObject);
            return gameObject;
        }

        public static bool PauseGame()
        {
            if (!Pause)
                return Pause = true;
            return Pause = false;
        }

        public static void AddPhysicalObject(IPhysical obj)
        {
            physicalObjects.Add(obj);
        }

        public static void Destroy<T>(T gameObject) where T : GameObject
        {
            GameObject hG = gameObject as GameObject;
            if (GameObject.currentScene.GetGameObjectsRootList().Count <= 0) return;
            GameObject.currentScene.GetGameObjectsRootList().Remove(hG);
        }

        private static void Sort(List<GameObject> drawableObjects)
        {
            for (int i = 0; i < drawableObjects.Count - 1; i++)
            {
                GameObject drawable1 = drawableObjects[i];
                for (int j = i + 1; j < drawableObjects.Count; j++)
                {
                    GameObject drawable2 = drawableObjects[j];

                    if (drawableObjects[i].RenderOffset == -1 || drawableObjects[j].RenderOffset == -1)
                        continue;

                    if (drawable1.RenderOffset >= drawable2.RenderOffset) continue;
                    GameObject temp = drawableObjects[i];
                    drawableObjects[i] = drawableObjects[j];
                    drawableObjects[j] = temp;
                }
            }
        }

        private static void DoSorting()
        {
            Sort(GameObject.currentScene.GetGameObjectsRootList());
        }

        private static void DoLazyRegistration()
        {
            if (waitForSpawnObjs.Count > 0)
            {
                for (int i = 0; i < waitForSpawnObjs.Count; i++)
                {
                    GameObject.currentScene.GetGameObjectsRootList().Add(waitForSpawnObjs.Dequeue());
                }
            }
        }

        private static void CheckCollision()
        {
            for (int i = 0; i < physicalObjects.Count - 1; i++)
            {
                IPhysical physical1 = physicalObjects[i];
                if (physical1 != null)
                {
                    for (int j = i + 1; j < physicalObjects.Count; j++)
                    {
                        IPhysical physical2 = physicalObjects[j];
                        if (physical2 != null)
                        {
                            if (PhysicsManager.Intersect(physical1.BoxCollider, physical2.BoxCollider))
                            {
                                physical1.OnIntersect(physical2);
                                physical2.OnIntersect(physical1);
                            }
                        }
                    }
                }
            }
        }

        public static void Run()
        {
            while (IsRunning)
            {
                Input.Update(Window);

                DoLazyRegistration();

                DoSorting();

                //update current assigned gameObject scene
                GameObject.UpdateScene();

                CheckCollision();

                Window.Update();
            }
        }

        internal static void SetCamera(Camera camera)
        {
            Window.SetCamera(camera);
        }
    }
}
