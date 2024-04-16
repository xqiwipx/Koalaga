using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject effect;
    public float destroyTime = 1;

    void Start()
    {
        Destroy(effect, destroyTime);
    }

    void Update()
    {
        
    }
}
