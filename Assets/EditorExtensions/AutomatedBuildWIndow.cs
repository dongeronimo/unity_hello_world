using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
public class AutomatedBuildWIndow : EditorWindow
{
    //List<SceneAsset> m_SceneAssets = new List<SceneAsset>();

    // Add menu item named "Example Window" to the Window menu
    [MenuItem("Geronimo/Automated Builds")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(AutomatedBuildWIndow));
    }
    void OnGUI()
    {
        List<string> scenesPaths = GetScenePaths();
        ShowScenesList(scenesPaths);

        /*
        List<string> sceneNames = new List<string>();
        Scene[] Scenes = new Scene[SceneManager.sceneCount];
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scenes[i] = SceneManager.GetSceneAt(i);
            sceneNames.Add(Scenes[i].path);
            //Debug.Log(Scenes[i].name);
        }*/
    }
    private void ShowScenesList(List<string> scenes)
    {
        GUILayout.Label("Scenes in Build", EditorStyles.boldLabel);
        scenes.ForEach((string obj) => GUILayout.Label(obj));
    }
    private List<string> GetScenePaths()
    {
        return UnityEditor.EditorBuildSettings.scenes.Select((EditorBuildSettingsScene arg) => arg.path).ToList();
    }
    /*
    void OnGUI()
    {
        GUILayout.Label("Scenes to include in build:", EditorStyles.boldLabel);
        for (int i = 0; i < m_SceneAssets.Count; ++i)
        {
            m_SceneAssets[i] = (SceneAsset)EditorGUILayout.ObjectField(m_SceneAssets[i], typeof(SceneAsset), false);
        }
        if (GUILayout.Button("Add"))
        {
            m_SceneAssets.Add(null);
        }

        GUILayout.Space(8);

        if (GUILayout.Button("Apply To Build Settings"))
        {
            SetEditorBuildSettingsScenes();
        }
    }

    public void SetEditorBuildSettingsScenes()
    {
        // Find valid Scene paths and make a list of EditorBuildSettingsScene
        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        foreach (var sceneAsset in m_SceneAssets)
        {
            string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            if (!string.IsNullOrEmpty(scenePath))
                editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
        }

        // Set the Build Settings window Scene list
        EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
    }
    */
}
