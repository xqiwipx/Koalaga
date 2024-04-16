using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookCart : MonoBehaviour
{
    //아이템 생성용 상점
    public ItemBuffer itemBuffer; //아이템 리스트
    public Transform slotRoot; //슬롯틀?

    public List<SlotC> slots; //슬롯 리스트 선언

    //외부로 넘겨주는 함수?
    public System.Action<ItemProperty> onSlotClick;

    //코인 관련
    public CoinMgr coinMgr;
    public QuestBoard questBoard;

    public GameObject itemset; //효과음
    public GameObject itemnull; //효과음

    void Start()
    {
        coinMgr = GameObject.Find("GameMgr").GetComponent<CoinMgr>();

        questBoard = GameObject.Find("ItemBuffer").GetComponent<QuestBoard>();

        slots = new List<SlotC>(); //슬롯들 리스트 정의

        int slotCnt = slotRoot.childCount; //슬롯카운트는 슬롯틀 안의 자식숫자로 정의

        //슬롯카운트 만큼 반복
        for (int i = 0; i < slotCnt ; i++)
        {
            //대상슬롯은 i번째 슬롯의 컨포넌트 
            var slot = slotRoot.GetChild(i).GetComponent<SlotC>();

            slot.SetItem(itemBuffer.items[0]);

            slots.Add(slot);
        }

    }

    void Update()
    {

    }

    public void CartUpdate()
    {
        StartCoroutine("WiteCartUpdate");
    }

    IEnumerator WiteCartUpdate()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            yield return new WaitForSecondsRealtime(0.1f);

            //대상슬롯은 i번째 슬롯의 컨포넌트 
            var slot = slotRoot.GetChild(i).GetComponent<SlotC>();

            int j = Random.Range(0, 3);

            switch (slot.item.name)
            {
                case "Empty": //빈칸
                    if (questBoard.isMQ != true && j < 1)
                    {
                        slot.SetItem(itemBuffer.items[5]);
                        Instantiate(itemset);
                    }

                    break;

                case "Quest_B": //중급 퀘스트

                    break;

                case "Quest_C": //하급 퀘스트

                    break;

                case "Quest_L": //반복 퀘스트

                    break;

                case "Quest_M": //지정 퀘스트 남으면 벌금
                    if (questBoard.isMQ != true && j < 1)
                    {
                        slot.SetItem(itemBuffer.items[5]);
                        Instantiate(itemset);
                        coinMgr.FiCoin(10);
                    }

                    break;

                case "Quest_N": //취급 불가
                    if (questBoard.isMQ != true && j < 1)
                    {
                        //slot.SetItem(itemBuffer.items[6]);
                        coinMgr.FiCoin(5);
                    }
                    break;

                case "Quest_O": //오래 빈자리

                    break;


            }

        }
        StopCoroutine("WiteCartUpdate");
    }

}

