#if (UNITY_EDITOR) 
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;
/// <summary>
/// Referências:
/// Fazer uma janela do editor da Unity: https://www.youtube.com/watch?v=491TSNwXTIg
/// Pegar a lista de cenas : https://answers.unity.com/questions/33263/how-to-get-names-of-all-available-levels.html
/// 
/// </summary>
public class AutomatedBuildWIndow : EditorWindow
{
    private string WebglBuildPath = "build-webgl";
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
        ShowWebGLBuildPathEditor();
        ShowWebGLBuildButton();
    }
    private void ShowWebGLBuildButton()
    {
        if(GUILayout.Button("Webgl Build"))
        {
            //BuildWebGlExecutable();
            //TODO: Copiar o default.conf pra raiz da build
            CopyDefaultConfTemplate();
            //TODO: Copiar o Dockerfile pra raiz da build
            CopyDockerfile();
            //TODO: Copiar o heroku.yml pra raiz da build
            CopyHerokuYml();
            //TODO: Copiar o nginx.conf pra raiz da build
            CopyNginxConf();
            //TODO: Rodar os comandos pra gerar a imagem
            //TODO: Rodar os comandos pra por a imagem no heroku

        }
    }
    private void CopyNginxConf()
    {
        CopyFiles("./Assets/EditorExtensions/webgl-automated-build/nginx.conf",
            "./build-webgl/nginx.conf");
    }
    private void CopyHerokuYml()
    {
        CopyFiles("./Assets/EditorExtensions/webgl-automated-build/heroku.yml",
            "./build-webgl/heroku.yml");
    }
    private void CopyDockerfile()
    {
        CopyFiles("./Assets/EditorExtensions/webgl-automated-build/Dockerfile",
            "./build-webgl/Dockerfile");
    }
    private void CopyDefaultConfTemplate()
    {
        CopyFiles("./Assets/EditorExtensions/webgl-automated-build/default.conf.template",
            "./build-webgl/default.conf.template");
    }
    private void CopyFiles(string src, string dest)
    {
        VerifyIfFileExists(src);
        File.Copy(src, dest, true);
        VerifyIfFileExists(dest);
    }
    private void VerifyIfFileExists(string filePath)
    {
        if (File.Exists(filePath) == false)
        {
            Debug.LogError("File not found " + filePath);
        }
    }
    private void BuildWebGlExecutable() {
        BuildPipeline.BuildPlayer(GetScenes(), WebglBuildPath,
        BuildTarget.WebGL,
        BuildOptions.None);
    }
    private void ShowWebGLBuildPathEditor()
    {
        WebglBuildPath = EditorGUILayout.TextField("WebGL build path", WebglBuildPath);
    }
    private void ShowScenesList(List<string> scenes)
    {
        GUILayout.Label("Scenes in Build", EditorStyles.boldLabel);
        scenes.ForEach((string obj) => GUILayout.Label(obj));
    }
    private EditorBuildSettingsScene[] GetScenes()
    {
        return UnityEditor.EditorBuildSettings.scenes;
    }
    private List<string> GetScenePaths()
    {
        return GetScenes().Select((EditorBuildSettingsScene arg) => arg.path).ToList();
    }

}
#endif