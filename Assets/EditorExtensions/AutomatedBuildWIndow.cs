#if (UNITY_EDITOR) 
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;
using System.Diagnostics;
/// <summary>
/// Referências:
/// Fazer uma janela do editor da Unity: https://www.youtube.com/watch?v=491TSNwXTIg
/// Pegar a lista de cenas : https://answers.unity.com/questions/33263/how-to-get-names-of-all-available-levels.html
/// 
/// </summary>
public class AutomatedBuildWIndow : EditorWindow
{
    private string WebglBuildPath = "build-webgl";
    private string SudoPassword = "";
    // Add menu item named "Example Window" to the Window menu
    [MenuItem("Geronimo/Automated Builds")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(AutomatedBuildWIndow));
    }
    void OnGUI()
    {
        ShowRootPasswordEditor();
        List<string> scenesPaths = GetScenePaths();
        ShowScenesList(scenesPaths);
        ShowWebGLBuildPathEditor();
        ShowWebGLBuildButton();
    }
    private void RunRootLinuxCommand(string commandString)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            Arguments = string.Format("-c \"sudo -S {0}\"", commandString),  //string.Format("-c \"sudo pwd \"", "pwd"),//"./build-webgl/deployToHeroku.sh")
        };
        using (var p = Process.Start(psi))
        {
            if (p != null)
            {
                StreamWriter myStreamWriter = p.StandardInput;
                myStreamWriter.WriteLine(SudoPassword);
                var strError = p.StandardError.ReadToEnd();
                var strOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                UnityEngine.Debug.LogError("error = " + strError);
                UnityEngine.Debug.Log("output = " + strOutput);
            }
        }
    }
    private void ShowWebGLBuildButton()
    {
        if(GUILayout.Button("Webgl Build"))
        {
            //BuildWebGlExecutable();
            //CopyDefaultConfTemplate();
            //CopyDockerfile();
            //CopyHerokuYml();
            //CopyNginxConf();
            //CopyShellCommand();
            //TODO: Rodar os comandos pra gerar a imagem
            RunRootLinuxCommand("./build-webgl/deployToHeroku.sh");
            //RunRootLinuxCommand("pwd");
            /*
            var psi = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = "-c \"sudo -S pwd\"", //string.Format("-c \"sudo pwd \"", "pwd"),//"./build-webgl/deployToHeroku.sh")
            };
            using (var p = Process.Start(psi))
            {
                if (p != null)
                {
                    StreamWriter myStreamWriter = p.StandardInput;
                    myStreamWriter.WriteLine("Babilonia2");
                    var strError = p.StandardError.ReadToEnd();
                    var strOutput = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    UnityEngine.Debug.LogError("error = " + strError);
                    UnityEngine.Debug.Log("output = " + strOutput);
                }
            }
            */

            /*
             * O SHELLSCRIPT QUE EU USAVA NO EMSCRIPTEN.
             * cd deploy
             * sudo heroku container:login
             * sudo heroku container:push web -a hello-emscripten-sdl
             * sudo heroku container:release web -a hello-emscripten-sdl          
            */
            /*
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = "/bin/bash";//output /home/luciano/Documents/Hello Unity
            p.StartInfo.Arguments = "-c \"cd build-webgl && sudo heroku container:login && sudo heroku container:push web -a hello-emscripten-sdl && sudo heroku container:push web -a hello-emscripten-sdl\"";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            UnityEngine.Debug.Log("output " + output);
            UnityEngine.Debug.LogError("error " + error);
            */
            //TODO: Rodar os comandos pra por a imagem no heroku

        }
    }
    private void CopyShellCommand()
    {
        CopyFiles("./Assets/EditorExtensions/webgl-automated-build/deployToHeroku.sh",
            "./build-webgl/deployToHeroku.sh");
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
            UnityEngine.Debug.LogError("File not found " + filePath);
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
    private void ShowRootPasswordEditor()
    {
        SudoPassword = EditorGUILayout.TextField("sudo password", SudoPassword);
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