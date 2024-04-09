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

    void Start()
    {
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
                    break;

                case "Quest_B": //중급 퀘스트
                    if(j < 1)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                    }
                    else if(j > 1)
                    {
                        slot.SetItem(itemBuffer.items[5]);
                    }
                    break;

                case "Quest_C": //하급 퀘스트
                    if (j < 1)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                    }
                    else if (j > 1)
                    {
                        slot.SetItem(itemBuffer.items[1]);
                    }
                    break;

                case "Quest_L": //반복 퀘스트
                    // j값에 따라서 랜덤 수수료
                    if (j > 1)
                    {
                        slot.SetItem(itemBuffer.items[0]); //반복 퀘스트 마감
                    }
                    break;

                case "Quest_M": //지정 퀘스트 남으면 벌금
                    if (isMQ == true)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                    }
                    else if (j > 1)
                    {
                        slot.SetItem(itemBuffer.items[5]); //벌금
                    }
                    break;

                case "Quest_N": //취급 불가
                    if (isMQ == true)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                    }
                    else
                    {
                        //벌금
                    }
                    break;

                case "Quest_O": //오래 빈자리
                    if (isMQ == true)
                    {
                        //벌금면제
                    }
                    else
                    {
                        // 벌금
                    }
                        
                    break;


            }

        }
    }

    public void GetDown()
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

        }

    }

    public void QuestNotice()
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

        }

    }

}

