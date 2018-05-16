using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using Aiv.Fast2D.Utils.TextureHelper;

namespace BehaviourEngine
{
    public static class FlyWeight
    {
        private static readonly Dictionary<string, Texture> textures;

        static FlyWeight()
        {
            textures = new Dictionary<string, Texture>();
        }

        public static Texture Add(string toAdd, string fileName)
        {
            if ( !textures.ContainsKey( toAdd ) )
                textures[ toAdd ] = TextureHelper.LoadDecompressedTexture( fileName );
            return textures[toAdd];
        }

        public static Texture Get(string toGet)
        {
            return textures.ContainsKey(toGet) ? textures[toGet] : null;
        }

        public static void GenerateFromFile(string filename)
        {
            TextureHelper.GenerateDecompressedTextureFromFile(filename, "outputd", "dat");
        }
    }
}
