using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Core.Model
{
    public class Map : MonoBehaviour
    {
        public string CodeName { get; private set; }
        public string Description { get; private set; }
        public Plane Plane { get; private set; }


        internal void Initialize(MapInitData initData)
        {
            CodeName = initData.codeName;
            Description = initData.description;
            Plane = PlaneFactory.Instance.Create(initData.planeCodeName);
        }
    }
}
