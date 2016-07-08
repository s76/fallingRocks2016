using UnityEngine;
using System.Collections;
using Core.Model;
using Core.Managers;

public class SkillFactory : Singleton<SkillFactory>{
    public Skill Create (string skillCodeName, IGeoEntity owner)
    {
        var initData = InitDataManager.Instance.skills.Find(x => x.codeName == skillCodeName);
        var path = PathManager.Skills + initData.codeName;
        var s = Instantiate(Resources.Load<Skill>(path));
        s.Initialize(initData, owner);
        s.transform.SetParent(owner.Trans);
        return s;
    }
}
