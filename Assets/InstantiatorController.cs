using UnityEngine;
using System.Collections;

public class InstantiatorController : MonoBehaviour
{
    public GameObject prefab;
    // Use this for initialization
    void Start()
    {
        Instantiate(prefab);
    }
}