using UnityEngine;
using System.Collections;
using System;
using Google2u;
using System.Collections.Generic;

public class InitDataManager : Singleton<InitDataManager>
{
    [Header("World")]
    public List<MapInitData> maps;
    public List<PlaneInitData> planes;
    [Header("Entities")]
    public List<CharacterInitData> characters;
    public List<RockInitData> rocks;
    [Header("Skills")]
    public List<SkillInitData> skills;

}
[Serializable]
public class PlaneInitData
{
    [Serializable]
    public class RockAmountInfo
    {
        public string rockCodeName;
        public int amount;
    }
    public string codeName;
    public int sizeX, sizeZ;
    public float rockSize;
    public List<RockAmountInfo> rocks;
    public bool randomRockDistribution;
    public int rockFallHeight;
}
[Serializable]
public class MapInitData
{
    public string codeName;
    public string planeCodeName;
    public string description;
}

[Serializable]
public class CharacterInitData
{
    public string codeName;
    public string skinName;
    [Header("Statistics")]
    public string characterName;
    public int maxHealth;
    public int maxStamina;
    public float staminaRegenSpeed;
    [Header("Movement")]
    public float runSpeed;
    public float turnAngleSpeed;
    public float turnMoveSpeed;
    [Header("Skills")]
    public float castTimeMultiplier;
    public List<string> skillsName;
}

[Serializable]
public class RockInitData
{
    public string codeName;
    public string skinName;
    public float appearTime;
    public float fallTime;
    public float disappearTime;
    public List<string> skillsName;
}

[Serializable]
public class SkillInitData
{
    [Serializable]
    public class SkillInput
    {
        [HideInInspector]
        public string InputName;
        [HideInInspector]
        public InputType inputType;
        public string value;
        public SkillInput(InputType t, string v )
        {
            InputName = t.ToString();
            value = v;
            inputType = t;
        }
    }
    public enum InputType { Damage, SkillDuration, AreaOfEffect }
    public string codeName;
    public string description;
    public List<SkillInput> inputs;
}