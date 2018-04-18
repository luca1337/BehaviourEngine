using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public enum RenderLayer
    {
        // 0 => means will be rendered as the last one so first one to be seen
        // 1 => means the layer will be deeper and will be rendered as first
        Gui_00 = 0,
        Gui_01 = 1,
        Collider = 2,
        Weapon = 3,
        AI = 4,
        Player = 8,
        Tile = 16,
        Powerup = 32
    }
}
