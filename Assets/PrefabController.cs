using UnityEngine;
using System;
using System.Collections;

public class PrefabController : MonoBehaviour
{
    public GameObject prefab;

    public string prefabName = "MyPrefab";

    // Use this for initialization
    void Start()
    {
        prefab = (GameObject)Resources.Load(prefabName);
        Debug.Log(prefab);
    }
}
