using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GuildMaster : MonoBehaviour
{
    //아이템 생성용 상점
    public ItemBuffer itemBuffer; //아이템 리스트
    public Transform slotRoot; //슬롯틀?

    private List<SlotC> slots; //슬롯 리스트 선언

    void Start()
    {
        slots = new List<SlotC>(); //슬롯들 리스트 정의

        EmptySlot();
    }

    void Update()
    {
        //다음날(타임라인 확인) 되면 EmptySlot() 실행
    }

    //슬롯의 모든 내용을 비운다.
    public void EmptySlot()
    {
        //슬롯카운트 만큼 반복
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            //대상슬롯은 i번째 슬롯의 컨포넌트 
            var slot = slotRoot.GetChild(i).GetComponent<SlotC>();

            //슬롯 아이템을 비운다.
            slot.SetItem(null);

            //슬롯 리스트에 보낸다.
            slots.Add(slot);
        }
    }

}

