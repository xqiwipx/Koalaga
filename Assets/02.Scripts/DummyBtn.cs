using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBtn : MonoBehaviour
{
    // 버튼 테스트용 더미 이벤트
    public GameObject Dummybtn;
    public EventMgr EventMgr;
    
    void Start()
    {
        EventMgr = GameObject.Find("GameMgr").GetComponent<EventMgr>();
        Dummybtn.SetActive(false);
    }

    void Update()
    {
        
    }

    public void DummyEvent()
    {
        EventMgr.EventWin.SetActive(true);
        Dummybtn.SetActive(true);
    }

    public void OnClickDummyBtn()
    {
        Dummybtn.SetActive(false);
        EventMgr.EventWin.SetActive(false);
    }
}
