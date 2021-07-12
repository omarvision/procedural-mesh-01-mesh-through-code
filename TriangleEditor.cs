
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Triangle))]
public class MeshTriangleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.backgroundColor = Color.yellow;
        Triangle script = (Triangle)target;
        if (GUILayout.Button("Reset") == true)
        {
            script.ResetObjects();
        }
        if (GUILayout.Button("Create Mesh Triangle") == true)
        {
            script.CreateMeshTriangle();
        }
    }
}
