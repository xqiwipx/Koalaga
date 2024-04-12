using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class OptionItem : MonoBehaviour
{

    //아이템 사용문구
    public Text CoinItem1Txt;
    public Text CoinItem2Txt;
    public Text CoinItem3Txt;
    public Text CoinItem4Txt;
    public Text AutoPlayTxt;

    //아이템 적용 조건
    public bool IsItem1;
    public bool IsItem2;
    public bool IsItem3;
    public bool IsItem4;

    //아이템1
    public GameObject CoinItem1_1;
    public GameObject CoinItem1_2;
    public GameObject CoinItem1_3;

    //아이템2
    public QuestBoard questBoard;

    //아이템3
    public CoinMgr coinMgr; //코인샵 연동

    //아이템4
    public GameObject autoPlayBtn;
    public bool isAutoPlay;
    public ViceMaster viceMaster;
    public GuildMaster guildMaster;
    public Interaction interaction;
    public GameMgr gameMgr;
    public TimeLine timeLine;

    //시간 딜레이
    public float st = 0.5f;
    public float mt = 2.5f;
    public float lt = 5;

    void Start()
    {
        viceMaster = GameObject.Find("ItemBuffer").GetComponent<ViceMaster>();

        guildMaster = GameObject.Find("ItemBuffer").GetComponent<GuildMaster>();

        interaction = GameObject.Find("GameMgr").GetComponent<Interaction>();

        coinMgr = GameObject.Find("GameMgr").GetComponent<CoinMgr>();

        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();

        timeLine = GameObject.Find("GameMgr").GetComponent<TimeLine>();

        questBoard = GameObject.Find("ItemBuffer").GetComponent<QuestBoard>();

        IsItem1 = IsItem2 = IsItem3 = IsItem4 = true;
        CoinItem1();
        CoinItem2();
        CoinItem3();
        CoinItem4();

        isAutoPlay = false;
    }

    void Update()
    {
        
    }

    //원클릭 서류이동
    public void CoinItem1()
    {
        IsItem1 = !IsItem1;

        if (IsItem1 && coinMgr.useItem1)
        {
            CoinItem1_1.SetActive(true);
            CoinItem1_2.SetActive(true);
            CoinItem1_3.SetActive(true);

            CoinItem1Txt.text = "보따리장수 고용완료";
        }
        else
        {
            CoinItem1_1.SetActive(false);
            CoinItem1_2.SetActive(false);
            CoinItem1_3.SetActive(false);

            CoinItem1Txt.text = "보따리장수 고용필요";
            IsItem1 = false;
        }
    }

    //퀘스트보드 관리자 벌금
    public void CoinItem2()
    {
        IsItem2 = !IsItem2;

        if (IsItem2 && coinMgr.useItem2)
        {
            questBoard.isMQ = true; //벌금이 면제됨

            CoinItem2Txt.text = "길드마스터 허가확인";
        }
        else
        {
            questBoard.isMQ = false; //벌금 있음

            CoinItem2Txt.text = "길드마스터 허가필요";
            IsItem2 = false;
        }
    }

    //코인 관련
    public void CoinItem3()
    {
        IsItem3 = !IsItem3;

        if (IsItem3 && coinMgr.useItem3)
        {
            CoinItem3Txt.text = "쇼미더머니 복권당첨";
            StartCoroutine("MoneyGet");
        }
        else
        {
            CoinItem3Txt.text = "쇼미더머니 해금필요";
            IsItem3 = false;
        }
    }

    //방치 플레이모드
    public void CoinItem4()
    {
        IsItem4 = !IsItem4;

        if (IsItem4 && IsItem1 && IsItem2 && IsItem3 && coinMgr.useItem4)
        {
            CoinItem4Txt.text = "리미트리스 한계돌파";
            autoPlayBtn.SetActive(true);
        }
        else
        {
            CoinItem4Txt.text = "리미트리스 해금필요";
            autoPlayBtn.SetActive(false);
            IsItem4 = false;
        }
    }

    IEnumerator MoneyGet()
    {
        if (IsItem3 && coinMgr.useItem3)
        {
            coinMgr.totalCoin = 999;
            coinMgr.TodayMyCoin();
            yield return new WaitForSecondsRealtime(lt);
            MoneyGet();
        }
        else
        {
            StopCoroutine("MoneyGet");
        }
        
    }

    public void AutoPlayBtn()
    {
        isAutoPlay = !isAutoPlay;
        if (isAutoPlay == true)
        {
            AutoPlayTxt.text = "자동 사용중";

            //코루틴 시작
            StartCoroutine("AutoPlay");
        }
        else
        {
            AutoPlayTxt.text = "자동 정지중";
            //중지문구
            StopCoroutine("AutoPlay");
        }
    }

    IEnumerator AutoPlay()
    {
        while (isAutoPlay)
        {
            interaction.LobbyOut();
            gameMgr.MapOn(); //맵켜기
            yield return new WaitForSecondsRealtime(st);

            gameMgr.MapOff();
            interaction.ViceIn(); //발행처
            viceMaster.QuestGet(); //퀘스트만 받기
            yield return new WaitForSecondsRealtime(mt);

            gameMgr.MapOn(); //맵
            yield return new WaitForSecondsRealtime(st);

            gameMgr.MapOff();
            interaction.BoardIn(); //퀘스트보드
            questBoard.FixBoard(); //유지보수
            yield return new WaitForSecondsRealtime(mt);

            questBoard.QuestNotice(); //퀘스트 공지
            yield return new WaitForSecondsRealtime(mt);

            gameMgr.MapOn(); //맵
            yield return new WaitForSecondsRealtime(st);

            gameMgr.MapOff();
            interaction.MasterIn(); //상위 부서
            guildMaster.Delivery(); //서류 전달
            yield return new WaitForSecondsRealtime(mt);

            gameMgr.MapOn(); //맵
            yield return new WaitForSecondsRealtime(st);

            gameMgr.MapOff();
            interaction.ViceIn(); //발행처
            viceMaster.GetAll(); //모두 받기
            yield return new WaitForSecondsRealtime(mt);

            gameMgr.MapOn(); //맵
            yield return new WaitForSecondsRealtime(st);

            gameMgr.MapOff();
            interaction.BoardIn(); //퀘스트보드
            questBoard.QuestNotice(); //퀘스트 공지
            yield return new WaitForSecondsRealtime(mt);

            gameMgr.MapOn(); //맵
            yield return new WaitForSecondsRealtime(st);

            gameMgr.MapOff();
            interaction.MasterIn(); //상위 부서
            guildMaster.SendAll(); //남은 서류 처리
            yield return new WaitForSecondsRealtime(mt);

            gameMgr.MapOn(); //맵
            yield return new WaitForSecondsRealtime(st);

            gameMgr.MapOff();
            interaction.SaveIn(); //퇴근하기
            yield return new WaitForSecondsRealtime(st);

            timeLine.Save();//근무일지 작성
            yield return new WaitForSecondsRealtime(st);

            timeLine.BlindOff();
            timeLine.Go2Work();//출근
            yield return new WaitForSecondsRealtime(st);
        }
        
    }
}
