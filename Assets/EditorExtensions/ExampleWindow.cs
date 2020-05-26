#if (UNITY_EDITOR) 
using UnityEngine;
using UnityEditor;
/// <summary>
/// Baseado em https://www.youtube.com/watch?v=491TSNwXTIg
/// </summary>
public class ExampleWindow : EditorWindow
{
    [MenuItem("Geronimo/Example")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Example");
    }
    void OnGUI()
    {
        GUILayout.Label("Hello World");
        if (GUILayout.Button("Press me"))
        {

        }
    }
}
#endif