using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMgr : MonoBehaviour
{
    //코인 정산 관련 
    public int myCoin = 18; //잔여 코인
    public int liCoin = 1; //기본 생활비
    public int priCoin; //상금 prizes,fines
    public int fiCoin; //벌금
    public int totalCoin; //총합

    public Text CoinTxt; //잔여 코인 보여줌
    public Text MyCoinTxt; //정산 코인 보여줌
    public Text LiCoinTxt; //연산 보여주기용
    public Text priCoinTxt;
    public Text fiCoinTxt;
    public Text totalCoinTxt;

    //코인 아이템 샵
    public Text shopItem1;
    public Text shopItem2;
    public Text shopItem3;
    public Text shopItem4;

    public bool useItem1;
    public bool useItem2;
    public bool useItem3;
    public bool useItem4;

    public int priceItem1 = 1;
    public int priceItem2 = 1;
    public int priceItem3 = 1;
    public int priceItem4 = 1;

    void Start()
    {
        useItem1 = useItem2 = useItem3 = useItem4 = false;

        shopItem1.text = "운반인 고용 C " + priceItem1;
        shopItem2.text = "서류 사용권 C " + priceItem2;
        shopItem3.text = "복권에 당첨 C " + priceItem3;
        shopItem4.text = "자동 시스템 C " + priceItem4;

        totalCoin = myCoin;
        TodayMyCoin();
    }

    void Update()
    {
        
    }

    public void TodayMyCoin()
    {
        priCoin = fiCoin = 0;
        myCoin = totalCoin;
        CoinTxt.text = "C " + myCoin;
        
    }

    public void TodayTotal()
    {
        MyCoinTxt.text = "소지금 :   C " + myCoin;
        LiCoinTxt.text = "생활비 : -C " + liCoin;
        priCoinTxt.text = "수수료 : +C " + priCoin;
        fiCoinTxt.text = "수습비 : -C " + fiCoin;

        totalCoin = myCoin - liCoin + priCoin - fiCoin;
        totalCoinTxt.text = "총합산 :   C " + totalCoin;
    }

    //수수료 증가
    public void PriCoin(int coin)
    {
        for(int i = 0; i < coin; i++)
        {
            priCoin++;
        }
    }

    //수습비 증가
    public void FiCoin(int coin)
    {
        for (int i = 0; i < coin; i++)
        {
            fiCoin++;
        }
    }

    //아이템 샵 함수
    public void ShopItem1()
    {
        if (useItem1 == true)
        {
            shopItem1.text = "이미 운반상인 고용";
        }
        else if(useItem1 != true && myCoin < priceItem1)
        {
            shopItem1.text = "운반인 고용 C " + priceItem1;
        }else if (useItem1 != true && myCoin > priceItem1)
        {
            shopItem1.text = "보따리 운반상인 고용";
            myCoin -= priceItem1; 
            CoinTxt.text = "C " + myCoin;
            useItem1 = true;
        }
    }

    public void ShopItem2()
    {
        if (useItem2 == true)
        {
            shopItem2.text = "길드마스터의 허가있음";
        }
        else if (useItem2 != true && myCoin < priceItem2)
        {
            shopItem2.text = "서류 사용권 C " + priceItem2;
        }
        else if (useItem2 != true && myCoin > priceItem2)
        {
            shopItem2.text = "길드마스터의 허가구매";
            myCoin -= priceItem2;
            CoinTxt.text = "C " + myCoin;
            useItem2 = true;
        }
    }

    public void ShopItem3()
    {
        if (useItem3 == true)
        {
            shopItem3.text = "당첨금을 이미 가져감";
        }
        else if (useItem3 != true && myCoin < priceItem3)
        {
            shopItem3.text = "복권에 당첨 C " + priceItem3;
        }
        else if (useItem3 != true && myCoin > priceItem3)
        {
            shopItem3.text = "쇼미더머니 복권당첨";
            myCoin -= priceItem3;
            CoinTxt.text = "C " + myCoin;
            useItem3 = true;
        }
    }

    public void ShopItem4()
    {
        if (useItem4 == true)
        {
            shopItem4.text = "자동 시스템 사용가능";
        }
        else if (useItem4 != true && myCoin < priceItem4)
        {
            shopItem4.text = "자동 시스템 C " + priceItem4;
        }
        else if (useItem4 != true && myCoin > priceItem4)
        {
            shopItem4.text = "리미트리스 해금완료";
            myCoin -= priceItem4;
            CoinTxt.text = "C " + myCoin;
            useItem4 = true;
        }
    }
}
