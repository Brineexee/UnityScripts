using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Vector3FindTool : UnityEditor.EditorWindow
{
    Transform target;
    Vector3 targetPos;
    bool Spawned = false;

    [MenuItem("Tools/FindVector3")]
    static void Init()
    {
        Vector3FindTool window = (Vector3FindTool)EditorWindow.GetWindow(typeof(Vector3FindTool), true, "Find Vector3 from Transform");
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Spawn Vector Object")){
            switch(Spawned){
                case true:
                DestroyImmediate(target.gameObject);
                target = new GameObject("Vector3Search").transform;
                break;
                case false:
                target = new GameObject("Vector3Search").transform;
                Spawned = true;
                break;
            }
        }
        if(target != null){
        if(GUILayout.Button("Destroy Vector Object")){
            DestroyImmediate(target.gameObject);
            Spawned = false;
        }
        if(GUILayout.Button("Copy Vectors")){
            GUIUtility.systemCopyBuffer = "X: " + target.position.x + " Y: " + target.position.y + " Z: " + target.position.z;
        }
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        if(target != null){
        target.position = EditorGUILayout.Vector3Field("Position:", target.position);
        }
        EditorGUILayout.EndHorizontal();
    }
}
