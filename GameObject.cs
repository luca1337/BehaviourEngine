using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using BehaviourEngine.Interfaces;

namespace BehaviourEngine
{
    public class GameObject
    {
        public Transform    Transform       { get; }
        public GameObject   Parent          { get; set; }
        public string       Name            { get; }
        public int          RenderOffset    { get; }
        public List<Behaviour> Behaviours
        {
            get
            {
                return behaviours;
            }

        }

        public GameObject( int RenderOffset, string name = default( string ) )
        {
            this.RenderOffset   = RenderOffset;
            this.Name           = name;
            behaviours          = new List<Behaviour>();
            Transform           = new Transform(this);
            behaviours.Add(Transform);
            Active              = true;
        }

        public bool Active;

        private List<Behaviour> behaviours;

        public T AddBehaviour<T>(Behaviour behavior) where T : Behaviour
        {
            if (behaviours == null)
                behaviours = new List<Behaviour>();

            behaviours.Add(behavior);
            return behavior as T;
        }

        public T GetComponent<T>() where T : Behaviour
        {
            return behaviours.OfType<T>().FirstOrDefault();
        }

        public void Update()
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                Behaviour b = behaviours[i];

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
            }
        }

        public void Draw()
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                Behaviour b = behaviours[i];

                if (!b.Enabled)
                    continue;

                if (b is IDrawable)
                {
                    IDrawable drawable = b as IDrawable;
                    drawable.Draw();
                }
            }
        }

        public override string ToString( ) => $" { Name } ";
    }
}
