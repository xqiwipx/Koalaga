using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenSlot : MonoBehaviour
{
    //변수 선언
    public ItemBuffer itemBuffer; //아이템 리스트
    public Transform slotRoot; //슬롯 틀?

    public BookCart board; //서류 카트

    private List<SlotC> slots; //슬롯 리스트

    public ItemProperty Sitem; //꺼낸 아이템
    public ItemProperty Pitem; //넣을 아이템

    void Start()
    {
        //itemBuffer = GetComponent<ItemBuffer>();

        //슬롯 리스트 정의
        slots = new List<SlotC>();

        //대상슬롯은 i번째 슬롯의 컨포넌트 
        var slot = slotRoot.GetChild(0).GetComponent<SlotC>();

        slot.SetItem(itemBuffer.items[0]);

        //슬롯 리스트에 해당 슬롯을 보낸다
        slots.Add(slot);

        //선택아이템을 사용중표시
        board.onSlotClick = PickItem;

        Pitem = itemBuffer.items[0]; //넣을 아이템 초기화
    }

    void Update()
    {

    }

    //아이템 구매 함수 정의(해당 아이템 정보)
    void PickItem(ItemProperty item)
    { //손에 들고 있는 사용중인 아이템
        //Debug.Log(item.name + " 값을 받아왔다.");

        var HSlot = slotRoot.GetChild(0).GetComponent<SlotC>();
        slots.Add(HSlot);

        HSlot.SetItem(item);


        //Debug.Log(HSlot.item.name + "값이 들어갔다");
        
    }

    public void OnClickSlot(SlotC slot)
    {
        if(slot == null || slot.item.name == "Quest_O")
        {
            //Debug.Log(slot.item.name + " 여기서 처리?");
            board.onSlotClick(itemBuffer.items[0]);

            Sitem = itemBuffer.items[0];

        } else
        {
            board.onSlotClick(slot.item);

            Sitem = slot.item; //슬롯 선택
        }

        slot.SetItem(Pitem); //들고있던 아이템 넣기

        //Debug.Log(slot.item.name + " 들어있음");

        Pitem = Sitem; //슬롯에 있던 아이템 들기
    }
}
