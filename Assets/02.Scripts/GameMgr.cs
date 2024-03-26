using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public GameObject Menubtn;
    public GameObject memuWin;

    public GameObject StartMenu;
    public GameObject Prolog;

    public GameObject ContinueMenu;
    //public GameObject Continue;

    //public GameObject DummyBtn;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "00_Title")
        {
            //타이틀씬 시작하기 빼고 다 끄기
            Menubtn.SetActive(true);
            memuWin.SetActive(false);
            StartMenu.SetActive(false);
            Prolog.SetActive(false);
            ContinueMenu.SetActive(false);

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
        SceneManager.LoadScene(1); //첫 출근
    }

    public void OnClickTitle()
    {
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

}
