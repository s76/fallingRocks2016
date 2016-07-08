using UnityEditor;
using UnityEngine;
using s76ToolBox.GeneralUse.Mono;

[CustomEditor(typeof(ParticleSystemPlaybackSpeed))]
public class ParticleSystemPlaybackSpeedEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ParticleSystemPlaybackSpeed initManager = (ParticleSystemPlaybackSpeed)target;
        if (GUILayout.Button("Update reference"))
        {
            initManager.UpdateReference();
        }
        if (GUILayout.Button("Set speed"))
        {
            initManager.SetSpeed();
        }
        if (GUILayout.Button("Set scale"))
        {
            initManager.SetScale();
        }
    }
}