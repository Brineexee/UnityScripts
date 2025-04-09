using UnityEditor;
using UnityEngine;

public class ChangeAllShaders : EditorWindow
{
    private Shader shaderToFind;
    private Shader shaderReplacement;

    [MenuItem("Tools/Change All Shaders")]
    public static void ShowWindow()
    {
        GetWindow<ChangeAllShaders>("Change All Shaders");
    }

    private void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        shaderToFind = (Shader)EditorGUILayout.ObjectField("Shader To Find:", shaderToFind, typeof(Shader), false);
        shaderReplacement = (Shader)EditorGUILayout.ObjectField("Shader Replacement:", shaderReplacement, typeof(Shader), false);

        if (GUILayout.Button("Change Shaders!"))
        {
            if (shaderToFind == null || shaderReplacement == null) return;

            Renderer[] renderers = Object.FindObjectsOfType<Renderer>();
            int changedCount = 0;

            foreach (Renderer renderer in renderers)
            {
                bool updated = false;
                Material[] materials = renderer.sharedMaterials;

                for (int i = 0; i < materials.Length; i++)
                {
                    Material mat = materials[i];
                    if (mat != null && mat.shader == shaderToFind)
                    {
                        mat.shader = shaderReplacement;
                        updated = true;
                        changedCount++;
                    }
                }

                if (updated)
                {
                    EditorUtility.SetDirty(renderer);
                }
            }
            Debug.Log($"Changed shaders in {changedCount} material/s in {renderers.Length} renderers.");
        }
    }
}
