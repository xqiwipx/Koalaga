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


    //외부 호출
    public GameObject BlindWin; //블라인드
    public GameObject WorkData; //근무평가표

    public Interaction interaction; //상호작용 처리용
    public GuildMaster guildMaster;
    public ViceMaster viceMaster;
    public QuestBoard questBoard;
    public BookCart bookCart;
    public InvenSlot invenSlot;

    public CoinMgr coinMgr;

    public EventMgr EventMgr;

    void Start()
    {
        //interaction.InterWinMgr(7);

        BlindWin.SetActive(false);
        Today.text = Days + "일";

        coinMgr = GameObject.Find("GameMgr").GetComponent<CoinMgr>();

        bookCart = GameObject.Find("ItemBuffer").GetComponent<BookCart>();

        invenSlot = GameObject.Find("ItemBuffer").GetComponent<InvenSlot>();

        questBoard = GameObject.Find("ItemBuffer").GetComponent<QuestBoard>();

        interaction = GameObject.Find("GameMgr").GetComponent<Interaction>(); //상호작용 호출
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

        BlindWin.SetActive(true); //로딩중 정산 내용 예정

        if (Days == 1 || Days == LastSave)
        {
            WorkData.SetActive(false);
        }
        else
        {
            //인벤토리 정산관련 함수
            Calculate();
        }

        yield return new WaitForSecondsRealtime(1);
                
        if (Days > LastDay || coinMgr.totalCoin < 0)
        {
            yield return new WaitForSecondsRealtime(3);
            BlindWin.SetActive(false); //대기시간 후 끄기
            interaction.LobbyOut(); //로비 강제나가기
            //근무 마지막날이 지났다
            Debug.Log("에필로그 또는 게임오버 호출!!");
            Days = 1;
            EventMgr.EpilogOn();
        }
        else if (Days == 1 || Days == LastSave)
        {
            BlindOff();
            Go2Work(); //출근 함수
        }else
        {

        }
    }

    //정산관련 작업 함수
    public void Calculate()
    {
        interaction.InterWinMgr(7); //정산을 위한 활성화
        
        guildMaster.EmptySlot();
        viceMaster.NowItem();
        questBoard.QuestUpdate();
        bookCart.CartUpdate();
        invenSlot.UseSlotUpdate();


        WorkData.SetActive(true); //근무 평가표
        coinMgr.TodayTotal();

    }

    //출근하기
    public void Go2Work()
    {
        interaction.LobbyIn(); //출근하면 로비로
        coinMgr.TodayMyCoin(); //정산코인 갱신
    }

    //블라인드 근무 평가표 끄기
    public void BlindOff()
    {
        BlindWin.SetActive(false);
        EventMgr.isEventOff = true; //이벤트창 끄기

    }

}