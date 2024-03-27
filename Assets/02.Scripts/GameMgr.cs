using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    // 타이틀 메뉴 및 게임윈도우 관리

    public GameObject TitleWin;

    public GameObject Menubtn;
    public GameObject memuWin;

    public GameObject StartMenu;
    public GameObject Prolog;

    public GameObject ContinueMenu;
    public GameObject TimeLineWin;
    public GameObject OptionWin;
    public GameObject MapWin;



    void Start() //타이틀씬은 여기서 편집한다.
    {
        if (SceneManager.GetActiveScene().name == "00_Main")
        {
            //타이틀창 시작하기 빼고 다 끄기
            
            TitleWin.SetActive(true);
            Menubtn.SetActive(true);
            memuWin.SetActive(false);
            StartMenu.SetActive(false);
            Prolog.SetActive(false);
            ContinueMenu.SetActive(false);
            TimeLineWin.SetActive(false);
            OptionWin.SetActive(false);
            MapWin.SetActive(false);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame(); //ESC 종료 호출
        }

    }

    public void MenuWin()
    {
        Menubtn.SetActive(false);
        memuWin.SetActive(true);
        StartMenu.SetActive(false);
        ContinueMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit(); //종료
    }

    public void OnClickStartBtn()
    {
        //SceneManager.LoadScene(1); //첫 출근
        TitleWin.SetActive(false);
        PrologOff();
    }

    public void PrologOff()
    {
        Prolog.SetActive(false);
    }

    public void OnClickTitle()
    {
        //TitleWin.SetActive(true);
        SceneManager.LoadScene(0); //타이틀

    }

    public void Startmenu() //시작하기 메뉴
    {
        StartMenu.SetActive(true);
        memuWin.SetActive(false);
    }

    public void OnClickPrologBtn() //프롤로그
    {
        Prolog.SetActive(true);
    }

    public void OnClickContinueBtn() //이어하기 메뉴
    {
        ContinueMenu.SetActive(true);
        memuWin.SetActive(false);
    }

    //근무일지
    public void TimeLineOff()
    {
        TimeLineWin.SetActive(false);
    }

    public void TimeLineOn()
    {
        TimeLineWin.SetActive(true);
    }

    //근무환경
    public void OptionWinOff()
    {
        OptionWin.SetActive(false);
    }

    public void OptionWinOn()
    {
        OptionWin.SetActive(true);
    }

    //길드 약도
    public void MapOn()
    {
        Debug.Log("맵 활성화");
        MapWin.SetActive(true);
    }
    public void MapOff()
    {
        Debug.Log("맵 종료");
        MapWin.SetActive(false);
    }

}
