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
    public GameObject AutoProlog;

    public GameObject ContinueMenu;
    public GameObject TimeLineWin;
    public GameObject OptionWin;
    public GameObject CoinShopWin; //코인샵
    public GameObject MapWin;
    public GameObject InteractionWin;
    public GameObject SaveWin;


    public AutoProlog autoProlog;

    public EventMgr eventMgr;

    void Start() //타이틀씬은 여기서 편집한다.
    {
        if (SceneManager.GetActiveScene().name == "00_Main")
        {
            //타이틀창 시작하기 빼고 다 끄기
            OnClickTitle();
        }

        autoProlog = GameObject.Find("TopDum").GetComponent<AutoProlog>(); //오토프롤로그

        eventMgr = GameObject.Find("GameMgr").GetComponent<EventMgr>();

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
        autoProlog.AutoKey = false; //오토프롤로그 해제
        Menubtn.SetActive(false);
        memuWin.SetActive(true);
        StartMenu.SetActive(false);
        ContinueMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("게임종료");
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif

        Application.Quit();
    }

    public void OnClickStartBtn()
    {
        //SceneManager.LoadScene(1); //첫 출근
        TitleWin.SetActive(false);
        PrologOff();
    }

    public void PrologOff()
    {
        eventMgr.EventWin.SetActive(false);
        Prolog.SetActive(false);
    }

    public void OnClickTitle()
    {
        TitleWin.SetActive(true);
        Menubtn.SetActive(true);
        memuWin.SetActive(false);
        StartMenu.SetActive(false);
        Prolog.SetActive(false);
        AutoProlog.SetActive(false);
        ContinueMenu.SetActive(false);
        TimeLineWin.SetActive(false);
        OptionWin.SetActive(false);
        CoinShopWin.SetActive(false);
        MapWin.SetActive(false);
        SaveWin.SetActive(false);
        InteractionWin.SetActive(false);
        //SceneManager.LoadScene(0); //씬 초기화

        //EventMgr.EventWin.SetActive(false);

    }

    public void Startmenu() //시작하기 메뉴
    {
        StartMenu.SetActive(true);
        memuWin.SetActive(false);
    }

    public void OnClickPrologBtn() //프롤로그
    {
        eventMgr.EventWin.SetActive(true); //이벤트창 활성화
        Prolog.SetActive(true);
    }

    public void OnClickContinueBtn() //이어하기 메뉴
    {
        ContinueMenu.SetActive(true);
        memuWin.SetActive(false);
    }

    public void TopWinOff()
    {
        TimeLineWin.SetActive(false);
        OptionWin.SetActive(false);
        CoinShopWin.SetActive(false);
        MapWin.SetActive(false);
    }

    //근무일지
    public void TimeLineOff()
    {
        TopWinOff();
    }

    public void TimeLineOn()
    {
        TopWinOff();
        TimeLineWin.SetActive(true);
    }

    //근무환경
    public void OptionWinOff()
    {
        TopWinOff();
    }

    public void OptionWinOn()
    {
        TopWinOff();
        OptionWin.SetActive(true);
    }

    //코인샵
    public void CoinShopWinOff()
    {
        TopWinOff();
    }

    public void CoinShopWinOn()
    {
        TopWinOff();
        CoinShopWin.SetActive(true);
    }

    //길드 약도
    public void MapOn()
    {
        TopWinOff();
        Debug.Log("맵 활성화");
        MapWin.SetActive(true);
    }
    public void MapOff()
    {
        Debug.Log("맵 종료");
        TopWinOff();
    }

}
