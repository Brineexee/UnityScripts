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
            GameObject[] SceneObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            
            foreach(GameObject sceneObject in SceneObjects)
            {
                Renderer rend = sceneObject.GetComponent<Renderer>();
                if(rend != null && rend.sharedMaterial.shader == sh)
                {
                    rend.sharedMaterial.shader = sh2;
                }
            }
        }
    }
}
