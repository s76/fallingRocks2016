using UnityEngine;
using System.Collections;
using Core.Model;
using Core.Managers;
using s76ToolBox.GeneralUse.Extensions;

public class SkinFactory : Singleton<SkinFactory>
{
     public RockSkin CreateRockSkin(string skinName, IGeoEntity entity)
     { 
        var path = PathManager.RockSkins + skinName;
        var s = Instantiate(Resources.Load<RockSkin>(path));
        s.transform.SetParent(entity.Trans);
        s.transform.ResetLocals();
        s.Initialize(entity);
        return s;
    }
    public CharacterSkin CreateCharacterSkin(string skinName, IGeoEntity entity)
    {
        var path = PathManager.CharacterSkins + skinName;
        var s = Instantiate(Resources.Load<CharacterSkin>(path));
        s.transform.SetParent(entity.Trans);
        s.transform.ResetLocals();
        s.Initialize(entity);
        return s;
    }
}