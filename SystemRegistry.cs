using System.Collections.Generic;
using EngineBuilder;

namespace BehaviourEngine
{
    public abstract class SystemRegistry<T> : ISystem
        where T : class, IEntity
    {
        protected List<T> items = new List<T>();
        private Queue<T> waitForAddItems = new Queue<T>();
        private Queue<T> waitForRemoveItems = new Queue<T>();

        public T[] DebugItems()
        {
            T[] array = new T[items.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = items[i];
            }
            return array;
        }

        public virtual void Add(IEntity entity)
        {
            if (entity is T item)
            {
                waitForAddItems.Enqueue(item);
            }
        }
        public virtual void Remove(IEntity entity)
        {
            if (entity is T item)
            {
                waitForRemoveItems.Enqueue(item);
            }
        }
        private void DeferredAddOrRemoveItems()
        {
            //actually add objects to the system
            int count;
            if (waitForAddItems.Count > 0)
            {
                count = waitForAddItems.Count;
                for (int i = 0; i < count; i++)
                {
                    items.Add(waitForAddItems.Dequeue());
                }
            }

            if (waitForRemoveItems.Count > 0)
            {
                count = waitForRemoveItems.Count;
                for (int i = 0; i < count; i++)
                {
                    items.Remove(waitForRemoveItems.Dequeue());
                }
            }
        }

        public virtual int UpdateOffset { get; set; }
        public virtual void Update()
        {
            DeferredAddOrRemoveItems();
        }
    }
}
