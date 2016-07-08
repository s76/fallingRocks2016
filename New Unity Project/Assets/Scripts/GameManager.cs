using UnityEngine;
using System.Collections;
using Core.Model;

public class GameManager : Singleton<GameManager> {
    private Core.Model.Plane plane;

    void OnGUI ()
    {
        if (GUILayout.Button("Plane 3x3"))
        {
            plane = PlaneFactory.Instance.Create("CN_Plane01");
        }
        if (GUILayout.Button("Plane 4x4"))
        {
            plane = PlaneFactory.Instance.Create("CN_Plane02");
        }
        if(GUILayout.Button("CrushRock fall"))
        {
            plane.RockFall("CN_CrushRock", Random.Range(0, plane.SizeX), Random.Range(0, plane.SizeZ));
        }
        if (GUILayout.Button("FlameRock fall"))
        {
            plane.RockFall("CN_FlameRock",Random.Range(0, plane.SizeX), Random.Range(0, plane.SizeZ));
        }
    }
}
