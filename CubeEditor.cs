using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.backgroundColor = Color.yellow;
        Cube script = (Cube)target;
        if (GUILayout.Button("Clear") == true)
        {
            script.Clear();
        }
        if (GUILayout.Button("Cube Mesh (shared vertices)") == true)
        {
            script.CreateMeshCube(new Vector3(0,0,0));
        }
        if (GUILayout.Button("Cube Mesh (shared sides)") == true)
        {
            script.CreateMeshCube2(new Vector3(0,0,0));
        }
    }
}
