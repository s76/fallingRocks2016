using UnityEngine;
using System.Collections;
using Core.Managers;

namespace Core.Model
{
    public class PlaneFactory : Singleton<PlaneFactory>
    {
        public Plane Create(string planeCodeName)
        {
            var planeInitData = InitDataManager.Instance.planes.Find(x => x.codeName == planeCodeName);

            if (planeInitData != null) 
            {
                var path = PathManager.Planes + planeInitData.codeName;
                var p = Instantiate(Resources.Load<Plane>(path));
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

