using Google2u;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InitDataManager))]
public class InitDataManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InitDataManager initManager = (InitDataManager)target;
        if (GUILayout.Button("Update"))
        {
            UpdateData(initManager);
        }
    }

    public void UpdateData(InitDataManager initManager)
    {
        UpdatePlanes(initManager);
        UpdateRocks(initManager);
    }

    private void UpdateRocks(InitDataManager initManager)
    {
        var list = initManager.rocks = new List<RockInitData>();
        foreach (var r in RocksInitDataRaw.Instance.Rows)
        {
            var d = new RockInitData();
            {
                d.codeName = r._CodeName;
                d.fallTime = r._FallTime;
                d.skillsName = r._SkillNames;
            }
            list.Add(d);
        }
    }

    private void UpdatePlanes(InitDataManager initManager)
    {
        var list = initManager.planes = new List<PlaneInitData>();
        foreach (var r in PlanesInitDataRaw.Instance.Rows)
        {
            var p = new PlaneInitData();
            {
                p.codeName = r._CodeName;
                p.rocks = new List<PlaneInitData.RockAmountInfo>();
                {
                    var c = r._Rocks.Count;
                    for(int i = 0; i < c; i ++ )
                    {
                        var rockInfo = r._Rocks[i];

                        var parts = rockInfo.Split('*');
                        var _rockCodeName = parts[0];
                        var _amount = int.Parse(parts[1]);
                        p.rocks.Add(new PlaneInitData.RockAmountInfo() { rockCodeName = _rockCodeName, amount = _amount });

                    }
                }
               
                p.sizeX = Convert.ToInt32(r._Size.x);
                p.sizeZ = Convert.ToInt32(r._Size.y);
                p.rockSize = r._Size.z;
                p.randomRockDistribution = r._RandomDistribution;
            }
            list.Add(p);
        }
    }
}