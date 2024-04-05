using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoard : MonoBehaviour
{
    //아이템 생성용 상점
    public ItemBuffer itemBuffer; //아이템 리스트
    public Transform slotRoot; //슬롯틀?

    private List<SlotC> slots; //슬롯 리스트 선언

    void Start()
    {

        slots = new List<SlotC>(); //슬롯들 리스트 정의

        //int slotCnt = slotRoot.childCount; //슬롯카운트는 슬롯틀 안의 자식숫자로 정의

        //슬롯카운트 만큼 반복
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            //대상슬롯은 i번째 슬롯의 컨포넌트 
            var slot = slotRoot.GetChild(i).GetComponent<SlotC>();

            slot.SetItem(null);

            slots.Add(slot);
        }

    }

    void Update()
    {

    }

    public void ReQuest()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {

        }
    }

}

