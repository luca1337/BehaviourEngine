using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BehaviourEngine
{
    public class SceneManager
    {
        //INTERNAL IMPLEMENTATIONS
        //USER CANNOT ACCESS THESE FUNCTIONS

        //INTERNAL DICTIONARY TO HOLD ALL THE SCENES 
        internal static Dictionary<SceneType, Scene> scenes = new Dictionary<SceneType, Scene>(); 

        internal static void InternalCreateScene(SceneType type, out Scene value)
        {
            try
            {
                value = new Scene();
                scenes.Add(type, value);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        internal static Scene InternalGetScene(SceneType type)
        {
            try
            {
                return scenes[type];
            }
            catch
            {
                throw new KeyNotFoundException();
            }
        }
        internal static Scene[] InternalGetAllScene()
        {
            Scene[] result = scenes.Select(x => x.Value).ToArray();
            return result;
        }
        //END OF INTERNAL IMPLEMENTATION

        //PUBLIC IMPLEMENTATION

        //[Obsolete("this method is not implemented yet.", true)]
        public static Scene CreateScene(SceneType type)
        {
            InternalCreateScene(type, out Scene res);
            return res;
        }

        public static Scene[] GetAllScenes()
        {
            return SceneManager.InternalGetAllScene();
        }

        public static Scene GetScene(SceneType type)
        {
            return SceneManager.InternalGetScene(type);
        }

        public override string ToString() => $"{scenes.Keys}";
    }
}
