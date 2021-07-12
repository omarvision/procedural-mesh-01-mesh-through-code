using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.backgroundColor = Color.yellow;
        Grid script = (Grid)target;
        if (GUILayout.Button("Create Mesh Grid") == true)
        {
            script.CreateMeshGrid();
        }
    }
}
