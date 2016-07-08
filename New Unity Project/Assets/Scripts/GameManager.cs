using UnityEngine;
using System.Collections;
using Core.Model;

public class GameManager : Singleton<GameManager> {
    private Core.Model.Plane plane;

    Character character;

    void Update  ()
    {
        if (character)
        {
            float dirX = 0, dirZ = 0;
            if (Input.GetKey(KeyCode.A))
            {
                dirX--;
            }
            if (Input.GetKey(KeyCode.D))
            {
                dirX++;
            }
            if (Input.GetKey(KeyCode.W))
            {
                dirZ++;
            }
            if (Input.GetKey(KeyCode.S))
            {
                dirZ--;
            }
            character.Move(dirX, dirZ, Time.deltaTime);
        }
    }
    void OnGUI ()
    {
        if (GUILayout.Button("CN_Plane01"))
        {
            plane = PlaneFactory.Instance.Create("CN_Plane01");
        }
        if (GUILayout.Button("Spawn david"))
        {
            plane.SpawnCharacter("CN_David",1,0,0);
        }
        if (GUILayout.Button("Assign character to control"))
        {
            character = FindObjectOfType<Character>();
        }
        if (GUILayout.Button("CrushRock fall"))
        {
            plane.RockFall("CN_CrushRock", Random.Range(0, plane.SizeX), Random.Range(0, plane.SizeZ));
        }
        if (GUILayout.Button("FlameRock fall"))
        {
            plane.RockFall("CN_FlameRock",Random.Range(0, plane.SizeX), Random.Range(0, plane.SizeZ));
        }
    }
}
