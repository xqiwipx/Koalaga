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


    void Start()
    {
        //priCoin = fiCoin = 0;
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
        MyCoinTxt.text = "소지금 : +C " + myCoin;
        LiCoinTxt.text = "생활비 : -C " + liCoin;
        priCoinTxt.text = "수수료 : +C " + priCoin;
        fiCoinTxt.text = "수습비 : -C " + fiCoin;

        totalCoin = myCoin - liCoin + priCoin - fiCoin;
        totalCoinTxt.text = "총합결과 :  C " + totalCoin;
    }
}
