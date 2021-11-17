using System;
using System.Net;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DownloadAndLoad : MonoBehaviour
{
    public string FileName = String.Empty;
    public string url = String.Empty;
    WebClient client = new WebClient();
    protected int x = 0;

    void Start()
    {
        client.DownloadFileAsync(new Uri(url), "Assets/Resources/" + FileName + ".fbx");
    }

    // Update is called once per frame
    void Update()
    {
        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
    }

    void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        x += 1;
        if(x == 1){
        Debug.Log("Download of " + FileName + " completed!");
        #if UNITY_EDITOR
        AssetDatabase.Refresh(); //Refresh Database
        #endif
        UnityEngine.Object prefabToSave = Resources.Load(FileName);
        GameObject gameObjectLoaded = (GameObject) Instantiate(prefabToSave, new Vector3(0, 0, 0), Quaternion.identity);
        client.Dispose();
        }
    }
}
