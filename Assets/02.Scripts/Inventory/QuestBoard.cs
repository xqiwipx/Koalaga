using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoard : MonoBehaviour
{
    //아이템 생성용 상점
    public ItemBuffer itemBuffer; //아이템 리스트
    public Transform slotRoot; //슬롯틀?
    public BookCart bookCart;

    private List<SlotC> slots; //슬롯 리스트 선언

    public bool isMQ = false; //길드마스터 기능 아이템

    //코인관련
    public CoinMgr coinMgr;

    void Start()
    {
        coinMgr = GameObject.Find("GameMgr").GetComponent<CoinMgr>();

        bookCart = GameObject.Find("ItemBuffer").GetComponent<BookCart>();

        slots = new List<SlotC>(); //슬롯들 리스트 정의

        // 서류 발급처 초기화
        //슬롯카운트 만큼 반복
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<SlotC>();

            slot.SetItem(itemBuffer.items[0]);
            slots.Add(slot);
        }

    }

    void Update()
    {

    }

    public void QuestUpdate()
    {
        //슬롯카운트 만큼 반복
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            //대상슬롯은 i번째 슬롯의 컨포넌트 
            var slot = slotRoot.GetChild(i).GetComponent<SlotC>();

            int j = Random.Range(0, 3);
            //int QL_END = Random.Range(0, 5);

            //Debug.Log(slot.item.name + " 발견");

            switch (slot.item.name)
            {
                case "Empty": //빈칸
                    slot.SetItem(itemBuffer.items[6]);
                    coinMgr.PriCoin(1); //기본 급료
                    break;

                case "Quest_B": //중급 퀘스트
                    if(j < 1)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                        coinMgr.PriCoin(5);
                    }
                    else if(j > 1)
                    {
                        slot.SetItem(itemBuffer.items[5]);
                        coinMgr.PriCoin(2);
                    }
                    else
                    {
                        coinMgr.PriCoin(1);
                    }
                    break;

                case "Quest_C": //하급 퀘스트
                    if (j < 1)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                        coinMgr.PriCoin(3);
                    }
                    else if (j > 1)
                    {
                        slot.SetItem(itemBuffer.items[1]);
                        coinMgr.PriCoin(1);
                    }
                    else
                    {
                        coinMgr.PriCoin(1);
                    }
                    break;

                case "Quest_L": //반복 퀘스트
                    // j값에 따라서 랜덤 수수료
                    if (j > 1)
                    {
                        slot.SetItem(itemBuffer.items[0]); //반복 퀘스트 마감
                        coinMgr.PriCoin(7);
                    }
                    coinMgr.PriCoin(Random.Range(0, j * 5)); //수수료 랜덤
                    break;

                case "Quest_M": //지정 퀘스트 남으면 벌금
                    if (isMQ == true)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                        coinMgr.PriCoin(10);
                    }
                    else if (j > 1)
                    {
                        slot.SetItem(itemBuffer.items[5]); //벌금
                        coinMgr.FiCoin(10);
                    }
                    else
                    {
                        coinMgr.FiCoin(10);
                    }
                    break;

                case "Quest_N": //취급 불가
                    if (isMQ == true)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                        coinMgr.PriCoin(3);
                    }
                    else
                    {
                        //벌금
                        coinMgr.FiCoin(5);
                    }
                    break;

                case "Quest_O": //오래 빈자리
                    if (isMQ != true)
                    {
                        //벌금
                        coinMgr.FiCoin(2);
                    }
                    else
                    {
                        // 벌금면제
                    }
                        
                    break;


            }

        }
    }

    public void GetDown()
    {
        StartCoroutine("WiteGetDown");
    }

    IEnumerator WiteGetDown()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var QuestSlot = slots.Find(t =>
            {
                return t.item != itemBuffer.items[0] && t.item != itemBuffer.items[6];
            });

            var cartSlot = bookCart.slots.Find(t =>
            {
                return t.item == itemBuffer.items[0];
            });
            if (cartSlot != null && QuestSlot != null)
            {
                cartSlot.SetItem(QuestSlot.item);
                QuestSlot.SetItem(itemBuffer.items[0]);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        StopCoroutine("WiteGetDown");
    }

    public void QuestNotice()
    {
        StartCoroutine("WiteQuestNotice");
    }

    IEnumerator WiteQuestNotice()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var cartSlot = bookCart.slots.Find(t =>
            {
                return t.item == itemBuffer.items[1] || t.item == itemBuffer.items[2] || t.item == itemBuffer.items[3];
            });

            var QuestSlot = slots.Find(t =>
            {
                return t.item == itemBuffer.items[0] || t.item == itemBuffer.items[6];
            });
            if (cartSlot != null && QuestSlot != null)
            {
                QuestSlot.SetItem(cartSlot.item);
                cartSlot.SetItem(itemBuffer.items[0]);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        StopCoroutine("WiteQuestNotice");
    }


    public void FixBoard()
    {
        StartCoroutine("WiteFixBoard");
    }

    IEnumerator WiteFixBoard()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var QuestSlot = slots.Find(t =>
            {
                return t.item != itemBuffer.items[0] && t.item != itemBuffer.items[1] && t.item != itemBuffer.items[2] && t.item != itemBuffer.items[3] || t.item == itemBuffer.items[4] || t.item == itemBuffer.items[5] || t.item == itemBuffer.items[6];
            });

            var cartSlot = bookCart.slots.Find(t =>
            {
                return t.item == itemBuffer.items[0];
            });
            if (cartSlot != null && QuestSlot != null)
            {
                if (QuestSlot.item != itemBuffer.items[6])
                {
                    cartSlot.SetItem(QuestSlot.item);
                }
                QuestSlot.SetItem(itemBuffer.items[0]);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        StopCoroutine("WiteFixBoard");
    }


}

