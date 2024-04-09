using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionItem : MonoBehaviour
{
    //아이템 사용문구
    public Text CoinItem1Txt;
    public Text CoinItem2Txt;
    public Text CoinItem3Txt;
    public Text CoinItem4Txt;

    //아이템 적용 조건
    public bool IsItem1 = true;
    public bool IsItem2 = true;
    public bool IsItem3 = true;
    public bool IsItem4 = true;

    //아이템1
    public GameObject CoinItem1_1;
    public GameObject CoinItem1_2;
    public GameObject CoinItem1_3;

    //아이템2
    public QuestBoard questBoard;

    void Start()
    {
        questBoard = GameObject.Find("ItemBuffer").GetComponent<QuestBoard>();

        CoinItem1();
        CoinItem2();
        CoinItem3();
        CoinItem4();
    }

    void Update()
    {
        
    }

    //원클릭 서류이동
    public void CoinItem1()
    {
        IsItem1 = !IsItem1;

        if (IsItem1)
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
        }
    }

    //퀘스트보드 관리자 벌금
    public void CoinItem2()
    {
        IsItem2 = !IsItem2;

        if (IsItem2)
        {
            questBoard.isMQ = true; //벌금이 면제됨

            CoinItem2Txt.text = "길드마스터 허가확인";
        }
        else
        {
            questBoard.isMQ = false; //벌금 있음

            CoinItem2Txt.text = "길드마스터 허가필요";
        }
    }

    //코인 관련
    public void CoinItem3()
    {
        IsItem3 = !IsItem3;

        if (IsItem3)
        {
            CoinItem3Txt.text = "쇼미더머니 복권당첨";
        }
        else
        {
            CoinItem3Txt.text = "쇼미더머니 해금필요";
        }
    }

    //방치 플레이모드
    public void CoinItem4()
    {
        IsItem4 = !IsItem4;

        if (IsItem4 && IsItem1 && IsItem2 && IsItem3)
        {
            CoinItem4Txt.text = "리미트리스 한계돌파";
        }
        else
        {
            CoinItem4Txt.text = "리미트리스 해금필요";
        }
    }


}
