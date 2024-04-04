using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InvenSlot : MonoBehaviour
{
    //변수 선언
    public Transform rootSlot; //슬롯 틀?

    //public ViceMaster board1; //발행처
    //public QuestBoard board; //퀘스트보드
    public BookCart board; //서류 카트
    //public GuildMaster board3; //상급 부서

    private List<SlotC> slots; //슬롯 리스트

    public ItemProperty Sitem; //꺼낸 아이템
    public ItemProperty Pitem; //넣을 아이템

    void Start()
    {

        //슬롯 리스트 정의
        slots = new List<SlotC>();

        var slot = rootSlot.GetChild(0).GetComponent<SlotC>();
        slots.Add(slot);

        slot.SetItem(null);

        //선택아이템을 사용중표시
        board.onSlotClick = PickItem;

        Pitem = null; //넣을 아이템 초기화
    }

    void Update()
    {

    }

    //아이템 구매 함수 정의(해당 아이템 정보)
    void PickItem(ItemProperty item)
    {
        //Debug.Log(item.name + " 값을 받아왔다.");

        var emptySlot = rootSlot.GetChild(0).GetComponent<SlotC>();
        slots.Add(emptySlot);

        emptySlot.SetItem(item);

    }

    public void OnClickSlot(SlotC slot)
    {
        //클릭하면 아이템 스왑
        board.onSlotClick(slot.item);

        Sitem = slot.item;

        slot.SetItem(Pitem);

        Pitem = Sitem;
    }
}
