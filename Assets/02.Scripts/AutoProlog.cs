using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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

    //public GameMgr GameMgr;
    public EventMgr EventMgr; //이벤트창 제어

    void Start()
    {
        //GameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();

        EventMgr = GameObject.Find("GameMgr").GetComponent<EventMgr>();

        if (AutoKey)
        {
            EventMgr.isEventOn = true;
            PrologSeting();
        }

    }

    void Update()
    {
                
        if (Input.GetMouseButtonUp(0) && AutoKey == true)
        {
            SceneManager.LoadScene(0);
            EventMgr.isEventOff = true;
        }
    }

    public void PrologSeting()
    {
        EventImg0.SetActive(true);
        EventImg1.SetActive(true);
        EventImg2.SetActive(true);
        EventImg3.SetActive(true);
        Autoprolog.SetActive(false);

        StartCoroutine(loadProlog());
    }

    IEnumerator loadProlog()
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

        if (AutoKey)
        {
            SceneManager.LoadScene(0);
        }

        EventMgr.isEventOff = true;

    }


}
