using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(demo))]
public class demoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        demo script = (demo)target;

        if (GUILayout.Button("Reset") == true)
        {
            script.Reset();
        }

        GUI.backgroundColor = Color.yellow;
        if (GUILayout.Button("near far") == true)
        {
            script.NearFar();
        }
        if (GUILayout.Button("points") == true)
        {
            script.NearFarPoints();
        }

        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("left right") == true)
        {
            script.LeftRight();
        }
        if (GUILayout.Button("points") == true)
        {
            script.LeftRightPoints();
        }

        GUI.backgroundColor = Color.gray;
        if (GUILayout.Button("bottom top") == true)
        {
            script.BottomTopDesc();
        }
        if (GUILayout.Button("points") == true)
        {
            script.BottomTopPoints();
        }
    }
}
