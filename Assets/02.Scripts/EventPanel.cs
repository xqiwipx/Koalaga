using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventPanel : MonoBehaviour
{
    //기승전결을 보여주고 다음 씬을 호출

    public GameObject EventImg0;
    public GameObject EventImg1;
    public GameObject EventImg2;
    public GameObject EventImg3;

    int ImgNum = 4;
    void Start()
    {
        EventImg0.SetActive(true);
        EventImg1.SetActive(true);
        EventImg2.SetActive(true);
        EventImg3.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ImgEvent();
        }
    }

    public void ImgEvent()
    {
        switch (ImgNum)
        {
            case 0:
                NextScene();
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
        ImgNum--;

    }

    public void NextScene()
    {
        //이 곳에 이어질 씬을 넣는다.
        SceneManager.LoadScene(1);
    }

}
