using UnityEngine;
using UnityEditor;

public class Vector3FindTool : EditorWindow
{
    private Transform vectorObject;
    private bool isSpawned;

    [MenuItem("Tools/Find Vector3")]
    public static void ShowWindow()
    {
        GetWindow<Vector3FindTool>("Find Vector3 from Transform");
    }

    private void OnGUI()
    {
        GUILayout.Label("Vector3 Tool", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Spawn Vector Object"))
        {
            ResetVectorObject();
        }

        if (vectorObject != null)
        {
            if (GUILayout.Button("Destroy Vector Object"))
            {
                DestroyImmediate(vectorObject.gameObject);
                vectorObject = null;
                isSpawned = false;
            }

            if (GUILayout.Button("Copy Vectors"))
            {
                Vector3 pos = vectorObject.position;
                GUIUtility.systemCopyBuffer = $"X: {pos.x} Y: {pos.y} Z: {pos.z}";
            }
        }

        EditorGUILayout.EndHorizontal();

        if (vectorObject != null)
        {
            vectorObject.position = EditorGUILayout.Vector3Field("Position", vectorObject.position);
        }
    }

    private void ResetVectorObject()
    {
        if (isSpawned && vectorObject != null)
        {
            DestroyImmediate(vectorObject.gameObject);
        }

        GameObject newObj = new GameObject("Vector3Search");
        vectorObject = newObj.transform;
        isSpawned = true;
    }
}
