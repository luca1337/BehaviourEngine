using System;
using System.Collections.Generic;
using Aiv.Fast2D;
using Aiv.Fast2D.Utils.Input;
using BehaviourEngine.Interfaces;

namespace BehaviourEngine
{
    public static class Engine
    {
        public static event Action ApplicationShutDown;
        private static BehaviorEngine engine;
        static Engine()
        {
            engine = new BehaviorEngine();
            engine.ApplicationShutDown += OnApplicationShutDown;
        }

        private static void OnApplicationShutDown()
        {
            ApplicationShutDown?.Invoke();
        }

        public static void Init(Window window)
        {
            engine.Init(window);
        }

        public static void Run()
        {
            engine.Run();
        }
        internal static void Add(Component component)
        {
            engine.Add(component);
        }
        internal static void Remove(Component component)
        {
            engine.Remove(component);
        }
    }
}
