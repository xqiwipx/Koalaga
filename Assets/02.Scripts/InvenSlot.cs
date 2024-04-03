using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenSlot : MonoBehaviour
{
    //변수 선언
    public Transform rootSlot; //슬롯 틀?
    public QuestBoard store; //스토어

    private List<Slot> slots; //슬롯 리스트

    void Start()
    {
        //슬롯 리스트 정의
        slots = new List<Slot>();

        //슬롯 카운트에 슬롯 틀의 자식들 숫자를 대입
        int slotCnt = rootSlot.childCount;

        //슬롯 카운트만큼 반복
        for (int i = 0; i < slotCnt; i++)
        {
            //슬롯에 i번째 자식의 슬롯 콤포넌트를 넣는다
            var slot = rootSlot.GetChild(i).GetComponent<Slot>();

            //해당 슬롯 리스트에 보내기
            slots.Add(slot);
        }
        // 스토어의 클릭된 슬롯과 아이템구매 함수 실행
        store.onSlotClick += BuyItem;
    }

    void Update()
    {

    }

    //아이템 구매 함수 정의(해당 아이템 정보)
    void BuyItem(ItemProperty item)
    {
        //Debug.Log(item.name + " 값을 받아왔다.");
        //선택 슬롯에 슬롯 리스트에서 찾은값을 넣는다
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;
        }); //받아온 아이템이 널값이거나 받아온 아이템의 이름값

        //선택슬롯값이 널값이 아니면 
        if (emptySlot != null)
        {
            //선택 슬롯에 해당아이템을 넣는함수 실행
            emptySlot.SetItem(item);
        }
    }
}
