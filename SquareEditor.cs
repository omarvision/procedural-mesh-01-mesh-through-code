
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Square))]
public class SquareEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.backgroundColor = Color.yellow;
        Square script = (Square)target;
        if (GUILayout.Button("Reset") == true)
        {
            script.ResetObjects();
        }
        if (GUILayout.Button("Create Mesh Square") == true)
        {
            script.CreateMeshSquare();
        }
        if (GUILayout.Button("Toggle Points") == true)
        {
            script.TogglePoints();
        }
    }
}
