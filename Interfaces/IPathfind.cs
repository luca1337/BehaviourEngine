using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Interfaces
{
    public interface IPathfind
    {
        List<Node> CurrentPath { get; set; }
        void ComputePath<T>(T path, int x, int y) where T : IMap;
        bool Computed { get; }
    }
}
