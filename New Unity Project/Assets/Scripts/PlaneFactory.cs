using UnityEngine;
using System.Collections;

namespace Core.Model
{
    public class PlaneFactory : Singleton<PlaneFactory>
    {
        public Plane sample;
        public Plane Create(string planeCodeName)
        {
            var planeInitData = InitDataManager.Instance.planes.Find(x => x.codeName == planeCodeName);

            if (planeInitData != null) 
            {
                var p = Instantiate(sample);
                p.name = planeInitData.codeName;
                p.Initialize(planeInitData);
                return p;
            }
            else
            {
                Debug.LogError("InitData not found for " + planeCodeName);
            }
            return null;
        }
    }
}

