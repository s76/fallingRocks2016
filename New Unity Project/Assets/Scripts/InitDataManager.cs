using UnityEngine;
using System.Collections;
using System;
using Google2u;
using System.Collections.Generic;

public class InitDataManager : Singleton<InitDataManager>
{
    public List<PlaneInitData> planes;
    public List<RockInitData> rocks;
  
}

[Serializable]
public class RockInitData
{
    public string codeName;
    public float fallTime;
    public List<string> skillsName;
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
}
