using UnityEngine;
using System.Collections;
using Core.Model;

public class SkillFactory : Singleton<SkillFactory>{
    public Skill sample;
    public Skill Create (string skillName)
    {
        var s = Instantiate(sample);
        return s;
    }
}
