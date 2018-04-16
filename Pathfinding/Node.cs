using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Pathfinding
{
    public class Node
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        private int cost;
        public int Cost
        {
            get
            {
                return cost;
            }
        }

        private List<Node> neighbours;
        public List<Node> Neighbours
        {
            get
            {
                return neighbours;
            }
        }

        private static List<Sprite> sprites;

        public Node(int cost, Vector2 position, string name = default(string))
        {
            sprites = new List<Sprite>();
            this.name = name;
            neighbours = new List<Node>();
            this.cost = cost;
            this.position = position;
        }

        public void AddNeighbour(Node node)
        {
            neighbours.Add(node);
            Sprite s = new Sprite(0.5f, 0.5f);
            s.position = node.position;
            sprites.Add(s);
        }

        public static void ShowPath()
        {
            if (sprites != null)

            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].DrawSolidColor(0f, 0f, 1f, .5f);
            }
        }
    }
}
