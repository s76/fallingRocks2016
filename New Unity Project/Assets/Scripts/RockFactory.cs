using UnityEngine;
using System.Collections;

namespace Core.Model
{
    public class RockFactory : Singleton<RockFactory>
    {
        public Rock[] samples;
        public GameObject[] skins;
        public Rock Create(string rockCodeName )
        {
            var data = InitDataManager.Instance.rocks.Find(x => x.codeName == rockCodeName);
            if( data != null )
            {
                foreach( var r in samples)
                {
                    if(r.name == data.codeName)
                    {
                        var rock = Instantiate(r);
                        rock.Initialize(data);
                        foreach (var s in skins)
                        {
                            if (s.name == rock.CodeName + "_Skin")
                            {
                                var skin = Instantiate(s);
                                skin.transform.SetParent(rock.transform);
                                skin.transform.localPosition = Vector3.zero;
                            }
                        }
                        return rock;
                    }
                }
            } else
            {
                Debug.LogError("InitData not found for " + rockCodeName);
            }
            return null;
        }
    }

}
