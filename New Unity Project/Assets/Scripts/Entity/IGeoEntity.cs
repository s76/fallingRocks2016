using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Core.Model
{
    public interface IGeoEntity
    {
        Transform Trans { get; }
        Vector3 Position { get; set; }
        Vector3 LocalPosition { get; set; }
        void SetGeoIndex(int level, int planeIndexX, int planeIndexZ);
        void SetPlane(Plane plane);
    }
}
