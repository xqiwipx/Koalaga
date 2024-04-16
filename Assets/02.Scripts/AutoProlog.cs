using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoProlog : MonoBehaviour
{
    //시작화면에서 대시시간 지나면 자동프롤로그가 나옴
    // 자동프롤로그가 종료되면 씬 초기화됨

    public GameObject Autoprolog;
    public GameObject EventImg0;
    public GameObject EventImg1;
    public GameObject EventImg2;
    public GameObject EventImg3;

    public float WaitProlog = 60;
    public float WaitPrologimg = 5;

    public bool AutoKey = true;

    public Text TopText;

    //public GameMgr GameMgr;
    public EventMgr eventMgr; //이벤트창 제어
    public GameMgr gameMgr;

    void Start()
    {
        StopCoroutine("loadProlog");
        StartCoroutine("AutoTopText");

        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();

        eventMgr = GameObject.Find("GameMgr").GetComponent<EventMgr>();

        if (AutoKey)
        {
            eventMgr.isEventOn = true;
            PrologSeting();
        }
        else
        {
            Autoprolog.SetActive(false);
            eventMgr.isEventOff = true;
        }

    }

    void Update()
    {
                
        if (Input.GetMouseButtonUp(0) && AutoKey == true)
        {
            StopCoroutine("loadProlog");
            //SceneManager.LoadScene(0);
            eventMgr.isEventOff = true;
            gameMgr.OnClickTitle();
        }
    }

    public void PrologSeting()
    {
        StopCoroutine("loadProlog");
        EventImg0.SetActive(true);
        EventImg1.SetActive(true);
        EventImg2.SetActive(true);
        EventImg3.SetActive(true);
        Autoprolog.SetActive(false);

        if (AutoKey)
        {
            StartCoroutine("loadProlog");
        }
        else
        {
            StopCoroutine("loadProlog");
        }
        
    }

    IEnumerator loadProlog()
    {      
        if (AutoKey)
        {
            //Debug.Log("대기전");
            yield return new WaitForSecondsRealtime(WaitProlog);
            //Debug.Log("대기후");
            Autoprolog.SetActive(true);
            yield return new WaitForSecondsRealtime(WaitPrologimg);
            EventImg0.SetActive(false);
            yield return new WaitForSecondsRealtime(WaitPrologimg);
            EventImg1.SetActive(false);
            yield return new WaitForSecondsRealtime(WaitPrologimg);
            EventImg2.SetActive(false);
            yield return new WaitForSecondsRealtime(WaitPrologimg);
            EventImg3.SetActive(false);
            Autoprolog.SetActive(false);
            eventMgr.isEventOff = true;

            gameMgr.OnClickTitle();
            StopCoroutine("loadProlog");
        }
        else
        {
            Autoprolog.SetActive(false);
            eventMgr.isEventOff = true;

            gameMgr.MenuWin();
            StopCoroutine("loadProlog");
        }

    }

    IEnumerator AutoTopText()
    {
        while (true)
        {
            int j = Random.Range(0, 4);
            switch (j)
            {
                case 0:
                    if (AutoKey)
                    {
                        TopText.text = "자동 프롤로그를 멈추려면 화면을 클릭하거나 시작하기를 눌러주세요.";
                    }
                    else
                    {
                        TopText.text = "코인샵에서 아이템구매! 근무환경에서 구매아이템을 ON/OFF 합니다";
                    }
                    
                    break;
                case 1:
                    TopText.text = "상호작용 NPC나 장소버튼의 지도를 선택하면 이동할 수 있습니다.";
                    break;
                case 2:
                    TopText.text = "서류를 클릭하면 사용중 서류 또는 빈칸과 바꿔서 옮길 수 있어요.";
                    break;
                case 3:
                    TopText.text = "게시판에는 퀘스트만 공지하세요. 남은 서류는 상급부서에 맡겨요.";
                    break;
            }
            yield return new WaitForSecondsRealtime(WaitPrologimg);
        }
    }
}
