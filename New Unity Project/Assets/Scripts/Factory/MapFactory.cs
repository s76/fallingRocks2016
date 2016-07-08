using Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Core.Model
{
    public class MapFactory : Singleton<MapFactory>
    {
        public Map Create(string mapCodeName )
        {
            var initData = InitDataManager.Instance.maps.Find(x => x.codeName == mapCodeName);
            var path = PathManager.Maps + initData.codeName;
            var m = Instantiate(Resources.Load<Map>(path));
            m.Initialize(initData);
            return m;
        }
    }
}
