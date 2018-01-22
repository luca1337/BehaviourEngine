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
        public static Scene        currentScene    { get; set; }
        public List<Behaviour> Behaviours
        {
            get
            {
                return behaviours;
            }

        }

        public GameObject( int RenderOffset, string sceneName, string name )
        {
            this.RenderOffset   = RenderOffset;
            this.Name           = name;
            behaviours          = new List<Behaviour>();
            Transform           = new Transform(this);
            Active              = true;
            behaviours.Add(Transform);
            SceneManager.GetScene(sceneName).AssignToScene(this);
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

        public static void UpdateScene()
        {
            currentScene.Update();
        }

        public override string ToString( ) => $" { Name } ";
    }
}
