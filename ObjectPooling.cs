using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class Pool<T> where T : class
    {
        private static Queue<T>          instances;
        private static Func<T>           allocator;

        private static Queue<GameObject> objects;
        private static Func<GameObject>  objectsAllocator;
        private static Queue<Component>  behaviours;

        public static void Register(Func<T> allocator, int preallocations = 0)
        {
            //      if (instances != null)
            //          throw new Exception("Pool already registered");
            if (instances == null)
            {
                if (allocator == null)
                    throw new NullReferenceException("Func<T> allocator can't be null");
                
                instances = new Queue<T>(preallocations);
                for (int i = 0; i < preallocations; i++)
                    instances.Enqueue(allocator.Invoke());
                
                Pool<T>.allocator = allocator;
            }
        }

        public static T GetInstance(Action<T> onGet = null)
        {
            if (instances == null)
                throw new Exception("Pool is not registered");

            var toReturn = instances.Count == 0 ? allocator.Invoke() : instances.Dequeue();
            onGet?.Invoke(toReturn);
            return toReturn;
        }

        public static void RecycleInstance(T toRecycle, Action<T> onRecycle = null)
        {
            if (instances == null)
                throw new Exception("Pool is not registered");

            onRecycle?.Invoke(toRecycle);
            instances.Enqueue(toRecycle);
        }

        //GameObject Pool
        public static void RegisterObject(Func<GameObject> allocator, int preallocations = 0) 
        {
            //      if (instances != null)
            //          throw new Exception("Pool already registered");
            if (objects == null)
            {
                if (allocator == null)
                    throw new NullReferenceException("Allocator can't be null");

                objects = new Queue<GameObject>(preallocations);

                for (int i = 0; i < preallocations; i++)
                {
                    GameObject prealloc = allocator.Invoke();
                    objects.Enqueue(prealloc);
                    for (int j = 0; j < prealloc.Components.Count; j++)
                    {
                        if (behaviours == null)
                            behaviours = new Queue<Component>();

                        behaviours.Enqueue(prealloc.Components[j]);
                    }
                }

                Pool<GameObject>.allocator = allocator;
            }
        }

        public static GameObject GetObjectInstance(Action<GameObject> onGet = null)
        {
            if (instances == null)
                throw new Exception("Pool is not registered");

            GameObject toReturn = objects.Count == 0 ? objectsAllocator.Invoke() : objects.Dequeue();
            onGet?.Invoke(toReturn);
            for (int i = 0; i < toReturn.Components.Count; i++)
            {
                toReturn.Components[i].Enabled = true;
            }

            return toReturn;
        }

        public static void RecycleObjectInstance(GameObject toRecycle, Action<GameObject> onRecycle = null)
        {
            if (objects == null)
                throw new Exception("Pool is not registered");

            onRecycle?.Invoke(toRecycle);
            for (int i = 0; i < toRecycle.Components.Count; i++)
            {
                toRecycle.Components[i].Enabled = false;
            }
            objects.Enqueue(toRecycle);
        }
    }
}
