using UnityEngine;
using System.Collections;
using Core.Managers;

namespace Core.Model
{
    public class RockFactory : Singleton<RockFactory>
    {
        public Rock Create(string rockCodeName )
        {
            var data = InitDataManager.Instance.rocks.Find(x => x.codeName == rockCodeName);
            if( data != null )
            {
                var path = PathManager.Rocks + data.codeName;
                var rock = Instantiate(Resources.Load<Rock>(path));
                rock.Initialize(data);
                   
                return rock;
            } else
            {
                Debug.LogError("InitData not found for " + rockCodeName);
            }
            return null;
        }
    }

}
