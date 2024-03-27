using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMgr : MonoBehaviour
{
    public GameObject Epilog;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EventOn()
    {
        Epilog.SetActive(true);
    }

    public void EventOff()
    {
        Epilog.SetActive(false);
    }



}
