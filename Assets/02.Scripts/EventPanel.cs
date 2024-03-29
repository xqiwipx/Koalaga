using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class EventPanel : MonoBehaviour
{
    //기승전결을 보여주고 다음 씬을 호출

    public GameObject EventImg0;
    public GameObject EventImg1;
    public GameObject EventImg2;
    public GameObject EventImg3;

    public int ImgNum = 5;
    public int ImgNum2;

    public EventMgr EventMgr;
    void Start()
    {
        EventMgr = GameObject.Find("GameMgr").GetComponent<EventMgr>();

        ImgNum2 = ImgNum;

        EventSeting();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ImgEvent();
        }
    }

    public void EventSeting()
    {
        EventMgr.isEventOn = true;

        EventImg0.SetActive(true);
        EventImg1.SetActive(true);
        EventImg2.SetActive(true);
        EventImg3.SetActive(true);
    }

    public void ImgEvent()
    {
        ImgNum--;
        switch (ImgNum)
        {
            case 0:
                EventSeting();
                ImgNum = ImgNum2;
                break;

            case 1:
                EventImg3.SetActive(false);
                break;

            case 2:
                EventImg2.SetActive(false);
                break;

            case 3:
                EventImg1.SetActive(false);
                break;

            case 4:
                EventImg0.SetActive(false);
                break;
        }
        

    }

   

}
