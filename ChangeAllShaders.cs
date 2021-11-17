using UnityEditor;
using UnityEngine;

public class ChangeAllShaders : EditorWindow
{
    Shader sh;
    Shader sh2;

    [MenuItem("Tools/Change All Shaders")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ChangeAllShaders));
    }
    
    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        sh = (Shader)EditorGUILayout.ObjectField(sh, typeof(Shader), true);
        sh2 = (Shader)EditorGUILayout.ObjectField(sh, typeof(Shader), true);
        if(GUILayout.Button("Change Shaders!"))
        {
            Renderer[] SceneObjects = UnityEngine.Object.FindObjectsOfType<Renderer>();
            foreach(Renderer sceneObject in SceneObjects)
            {
                if(sceneObject != null && Renderer.sharedMaterial.shader == sh)
                {
                    sceneObject.sharedMaterial.shader = sh2;
                }
            }
        }
    }
}