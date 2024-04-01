using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLine : MonoBehaviour
{
    //저장된 파일 불로오는 기능
    public int Days = 1; //근무일수
    public Text Today; //근무일 표시

    public int LastDay = 3; //최종 근무일 설정 
    int LastSave = 1; //근무일지 마지막 작성일

    public GameObject BlindWin; //블라인드

    public Interaction Interaction; //로비버그 처리용

    public EventMgr EventMgr;

    void Start()
    {
        BlindWin.SetActive(false);
        Today.text = Days + "일";
        Interaction = GameObject.Find("GameMgr").GetComponent<Interaction>(); //상호작용 호출
        EventMgr = GameObject.Find("GameMgr").GetComponent <EventMgr>();
    }

    void Update()
    {
        
    }

    public void NewStart()
    {
        Debug.Log("처음부터 출근");
        //날짜 초기화
        Days = 1;
        Today.text = Days + "일";
        StartCoroutine(BlindEF());
    }
    public void QuickLoad()
    {
        Debug.Log("세이브 당일 출근");
        //바로 출근 연결
        Days = LastSave; //저장된 근무날짜
        Today.text = Days + "일";
        StartCoroutine(BlindEF());
    }

    public void Save() //세이브 관련
    {
        LastSave = Days; //근무 당일 세이브
        NextDay();
    }

    public void NextDay()
    {
        Days++; //다음날 설정
        Today.text = Days + "일";
        StartCoroutine(BlindEF());
    }

    IEnumerator BlindEF()
    {
        EventMgr.isEventOn = true;

        BlindWin.SetActive(true); //로딩화면 연출
        yield return new WaitForSecondsRealtime(1);
        BlindWin.SetActive(false);
                
        if (Days > LastDay)
        {
            Interaction.isLobby = false; //로비 강제나가기
            //근무 마지막날이 지났다
            Debug.Log("에필로그 호출!!");
            EventMgr.EpilogOn();
        }
        else
        {
            EventMgr.isEventOff = true; //이벤트창 끄기
            Interaction.isLobby = true; //출근하면 로비로
        }

        

    }
}