using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using BehaviourEngine.Interfaces;
using OpenTK;

namespace BehaviourEngine
{
    public class GameObject
    {
        public uint Layer = LayerManager.DefaultLayer;
        public Transform            Transform       { get; }
        public string               Name            { get; }
        public static Scene         currentScene    { get; set; }
        public bool IsDeployed       { get; private set; }
        public List<Component>      Components
        {
            get
            {
                return components;
            }

        }

        public GameObject(string name = default(string))
        {
            this.Name           = name;
            this.components     = new List<Component>();
            this.Transform      = new Transform();
            this.Active         = true;
            this.AddComponent(this.Transform);
        }

        public bool Active;

        private List<Component> components;

        public T AddComponent<T>(T Component) where T : Component
        {
            Component.SetOwner(this);
            this.components.Add(Component);

            if (this.IsDeployed) Engine.Add(Component);

            return Component;
        }

        public T GetComponent<T>() where T : Component
        {
            return components.OfType<T>().FirstOrDefault();
        }

        public Component[] GetAllComponents()
        {
            Component[] array = new Component[components.Count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = components[i];
            }
            return array;
        }

        public static void UpdateScene()
        {
            currentScene.Update();
        }

        public static GameObject Spawn(GameObject gameObject)
        {
            return gameObject.Spawn();
        }

        public static GameObject Spawn(GameObject gameObject, Vector2 position)
        {
            gameObject.Transform.Position = position;

            return GameObject.Spawn(gameObject);
        }

        public static GameObject Spawn(GameObject gameObject, Vector2 position, float eulerRotation)
        {
            gameObject.Transform.Position = position;
            gameObject.Transform.EulerRotation = eulerRotation;

            return GameObject.Spawn(gameObject);
        }

        public GameObject Clone()
        {
            return (GameObject)this.MemberwiseClone();
        }

        private GameObject Spawn()
        {
            this.IsDeployed = true;

            for (int i = 0; i < components.Count; i++)
            {
                Engine.Add(components[i]);
            }
            return this;
        }

        public override string ToString( ) => $" { Name } ";
    }
}
