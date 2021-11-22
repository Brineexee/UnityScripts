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
        sh2 = (Shader)EditorGUILayout.ObjectField(sh2, typeof(Shader), true);
        if(GUILayout.Button("Change Shaders!"))
        {
            GameObject[] SceneObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            
            foreach(GameObject sceneObject in SceneObjects)
            {
                Renderer rend = sceneObject.GetComponent<Renderer>();
                MeshRenderer msRend = sceneObject.GetComponent<MeshRenderer>();
                SkinnedMeshRenderer msRend2 = sceneObject.GetComponent<SkinnedMeshRenderer>();
                if(msRend2 != null && msRend2.sharedMaterial.shader == sh)
                {
                    for(int i = 0; i < msRend2.sharedMaterials.Length; i++)
                    {
                        msRend2.sharedMaterials[i].shader = sh2;
                    }
                    msRend2.sharedMaterial.shader = sh2;
                }
                if(msRend != null && msRend.sharedMaterial.shader == sh)
                {
                    for(int i = 0; i < msRend.sharedMaterials.Length; i++)
                    {
                        msRend.sharedMaterials[i].shader = sh2;
                    }
                    msRend.sharedMaterial.shader = sh2;
                }
                if(rend != null && rend.sharedMaterial.shader == sh)
                {
                    for(int i = 0; i < rend.materials.Length; i++)
                    {
                        rend.materials[i].shader = sh2;
                    }
                    rend.sharedMaterial.shader = sh2;
                }
            }
        }
    }
}
