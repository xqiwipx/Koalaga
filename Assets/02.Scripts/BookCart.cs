using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class BookCart : MonoBehaviour
{
    //아이템 생성용 상점
    public ItemBuffer itemBuffer; //아이템 리스트
    public Transform slotRoot; //슬롯틀?

    private List<SlotC> slots; //슬롯 리스트 선언

    //외부로 넘겨주는 함수?
    public System.Action<ItemProperty> onSlotClick;

    void Start()
    {

        slots = new List<SlotC>(); //슬롯들 리스트 정의

        int slotCnt = slotRoot.childCount; //슬롯카운트는 슬롯틀 안의 자식숫자로 정의

        //슬롯카운트 만큼 반복
        for (int i = 0; i < slotCnt ; i++)
        {
            //대상슬롯은 i번째 슬롯의 컨포넌트 
            var slot = slotRoot.GetChild(i).GetComponent<SlotC>();

            slot.SetItem(null);

            //i가 아이템카운트를 넘지 않으면
            //if (i < itemBuffer.items.Count)
            //{
            //    //대상슬롯에 i번째 아이템을 넣는다
            //    slot.SetItem(itemBuffer.items[i]);
            //}
            //else
            //{
            //    slot.SetItem(null);
            //}

            //슬롯 리스트에 해당 슬롯을 보낸다
            slots.Add(slot);
        }

    }

    void Update()
    {

    }


    
}

