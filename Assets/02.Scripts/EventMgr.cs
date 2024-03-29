using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMgr : MonoBehaviour
{
    public GameObject Epilog;

    public bool isEventOn = false;
    public bool isEventOff = false;

    public GameObject EventWin;

    void Start()
    {

    }

    void Update()
    {
        if(isEventOn == true)
        {
            isEventOn = !isEventOn;
            EventOn();
        }
        if(isEventOff == true)
        {
            isEventOff = !isEventOff;
            EventOff();
        }
    }

    public void EventOn()
    {
        EventWin.SetActive(true);
    }
    public void EventOff()
    {
        EventWin.SetActive(false);
    }

    public void EpilogOn()
    {
        isEventOn = true; //이벤트창 활성화
        Epilog.SetActive(true);
    }

    public void EpilogOff()
    {
        Epilog.SetActive(false);
        isEventOff = true;
    }



}
