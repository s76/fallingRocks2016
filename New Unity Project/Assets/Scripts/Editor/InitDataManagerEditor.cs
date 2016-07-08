using Google2u;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using s76ToolBox.GeneralUse.Extensions;
using Core.Model;

[CustomEditor(typeof(InitDataManager))]
public class InitDataManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InitDataManager initManager = (InitDataManager)target;
        if (initManager)
        {
            if (GUILayout.Button("Update"))
            {
                UpdateData(initManager);
            }
            if (GUILayout.Button("Create empty prefabs"))
            {
                CreateEmptyPrefab(initManager);
            }
        }
        DrawDefaultInspector();
    }

    private void CreateEmptyPrefab(InitDataManager initManager)
    {
        foreach (var e in initManager.rocks)
        {
            GameObject g = new GameObject(e.codeName);
            g.AddComponent<Rock>();

            GameObject g2 = new GameObject(e.skinName);
            g2.AddComponent<RockSkin>();
        }

        foreach (var e in initManager.characters)
        {
            GameObject g = new GameObject(e.codeName);
            g.AddComponent<Character>();

            GameObject g2 = new GameObject(e.skinName);
            g2.AddComponent<CharacterSkin>();
        }

        foreach (var e in initManager.maps)
        {
            GameObject g = new GameObject(e.codeName);
            g.AddComponent<Map>();
        }

        foreach (var e in initManager.planes)
        {
            GameObject g = new GameObject(e.codeName);
            g.AddComponent<Core.Model.Plane>();
        }

        foreach (var e in initManager.skills)
        {
            GameObject g = new GameObject(e.codeName);
        }
    }

    public void UpdateData(InitDataManager initManager)
    {
        UpdateMaps(initManager);
        UpdatePlanes(initManager);
        UpdateCharacters(initManager);
        UpdateRocks(initManager);
        UpdateSkills(initManager);
    }

    private void UpdateCharacters(InitDataManager initManager)
    {
        var list = initManager.characters = new List<CharacterInitData>();
        foreach (var r in CharactersInitDataRaw.Instance.Rows)
        {
            var d = new CharacterInitData();
            {
                d.codeName = r._CodeName;
                d.skillsName = r._SkillNames;
                d.skinName = r._SkinName;
                d.characterName = r._CharacterName;
                d.castTimeMultiplier = r._CastTimeMultiplier;
                d.maxHealth = r._MaxHealth;
                d.maxStamina = r._MaxStamina;
                d.staminaRegenSpeed = r._StaminaRegenSpeed;
                d.turnAngleSpeed = r._TurnAngleSpeed;
                d.turnMoveSpeed = r._TurnMoveSpeed;
                d.runSpeed = r._RunSpeed;
            }
            list.Add(d);
        }
    }

    private void UpdateSkills(InitDataManager initManager)
    {
        var list = initManager.skills = new List<SkillInitData>();
        foreach (var r in SkillsInitDataRaw.Instance.Rows)
        {
            var s = new SkillInitData();
            {
                s.codeName = r._CodeName;
                s.description = r._Description;
                s.inputs = new List<SkillInitData.SkillInput>();
                {
                    foreach ( var rawInput in r._SkillInput)
                    {
                        var parts = rawInput.Split('#');
                        var type = parts[0].ParseEnum<SkillInitData.InputType>();
                        var value = parts[1];
                        s.inputs.Add(new SkillInitData.SkillInput(type, value));
                    }
                }
            }
            list.Add(s);
        }
    }

    private void UpdateMaps(InitDataManager initManager)
    {
        var list = initManager.maps = new List<MapInitData>();
        foreach (var r in MapsInitDataRaw.Instance.Rows)
        {
            var m = new MapInitData();
            {
                m.codeName = r._CodeName;
                m.planeCodeName = r._PlaneCodeName;
                m.description = r._Description;
            }
            list.Add(m);
        }
    }

    private void UpdateRocks(InitDataManager initManager)
    {
        var list = initManager.rocks = new List<RockInitData>();
        foreach (var r in RocksInitDataRaw.Instance.Rows)
        {
            var d = new RockInitData();
            {
                d.codeName = r._CodeName;
                d.skillsName = r._SkillNames;
                d.appearTime = r._AppearTime;
                d.fallTime = r._FallTime;
                d.disappearTime = r._DisappearTime;
                d.skinName = r._SkinName;
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
                    if ( c == 1 )
                    {
                        var parts = r._Rocks[0].Split('*');
                        p.rocks.Add(new PlaneInitData.RockAmountInfo() { rockCodeName = parts[0], amount = -1 });
                    } else
                    {
                        for (int i = 0; i < c; i++)
                        {
                            var rockInfo = r._Rocks[i];

                            var parts = rockInfo.Split('*');
                            if (parts.Length == 2)
                            {
                                var _rockCodeName = parts[0];
                                var _amount = int.Parse(parts[1]);
                                p.rocks.Add(new PlaneInitData.RockAmountInfo() { rockCodeName = _rockCodeName, amount = _amount });
                            }
                        }
                    }
                }
               
                p.sizeX = Convert.ToInt32(r._PlaneSize.x);
                p.sizeZ = Convert.ToInt32(r._PlaneSize.y);
                p.rockFallHeight = r._RockFallHeight;
                p.rockSize = r._RockSize;
                p.randomRockDistribution = r._RandomDistribution;
            }
            list.Add(p);
        }
    }
}