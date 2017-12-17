﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Interfaces
{
    public interface IPhysical
    {
        Box2D BoxCollider { get; set; }
        void OnIntersect(IPhysical other);
    }
}
