using BehaviourEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public class Scene
    {
        internal List<GameObject> GameObjects = new List<GameObject>();

        internal GameObject[] InternalGetGameObjectsRoot()
        {
            return GameObjects.ToArray();
        }

        internal List<GameObject> InternalGetGameObjectsRootList()
        {
            return GameObjects;
        }

        public void AssignToScene(GameObject go)
        {
            GameObjects.Add(go);
        }

        private int handle;

        internal int Handle => handle;

        private bool isLoaded;

        public bool IsLoaded => IsLoaded;


        public GameObject[] GetGameObjectsRoot()
        {
            return InternalGetGameObjectsRoot();
        }
        public List<GameObject> GetGameObjectsRootList()
        {
            return InternalGetGameObjectsRootList();
        }

        public static bool operator ==(Scene lhs, Scene rhs)
        {
            return lhs.Handle == rhs.Handle;
        }

        public static bool operator !=(Scene lhs, Scene rhs)
        {
            return lhs.Handle != rhs.Handle;
        }

        public override int GetHashCode()
        {
            return this.handle;
        }

        public override bool Equals(object other)
        {
            bool result;
            if (!(other is Scene))
            {
                result = false;
            }
            else
            {
                Scene scene = (Scene)other;
                result = (this.Handle == scene.Handle);
            }
            return result;
        }

        public void Update()
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObject go = GameObjects[i];

                if (go.Active)
                {
                    for (int j = 0; j < go.Components.Count; j++)
                    {
                        Component b = go.Components[j];

                        if (!b.Enabled)
                            continue;

                        if (b is IStartable)
                        {
                            IStartable startable = b as IStartable;
                            if (!startable.IsStarted)
                            {
                                startable.Start();
                                startable.IsStarted = true;
                            }
                        }

                        if (b is IUpdatable)
                        {
                            IUpdatable updatable = b as IUpdatable;
                            updatable.Update();
                        }

                        if (b is IDrawable)
                        {
                            IDrawable drawable = b as IDrawable;
                            drawable.Draw();
                        }
                    }
                }
            }
        }
    }
}
