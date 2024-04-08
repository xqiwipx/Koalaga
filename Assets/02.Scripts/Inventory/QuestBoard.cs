using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class QuestBoard : MonoBehaviour
{
    //아이템 생성용 상점
    public ItemBuffer itemBuffer; //아이템 리스트
    public Transform slotRoot; //슬롯틀?

    private List<SlotC> slots; //슬롯 리스트 선언

    public bool isMQ = false; //문서 권한

    void Start()
    {

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
                    break;

                case "Quest_M": //지정 퀘스트 남으면 벌금
                    if (j < 1 && isMQ == true)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                    }
                    else if (j > 1)
                    {
                        slot.SetItem(itemBuffer.items[5]); //벌금
                    }
                    break;

                case "Quest_N": //취급 불가
                    if (j < 1 && isMQ == true)
                    {
                        slot.SetItem(itemBuffer.items[0]);
                    }
                    else
                    {
                        //벌금
                    }
                    break;

                case "Quest_O": //오래 빈자리
                    // 벌금
                    break;


            }

        }
    }

}

