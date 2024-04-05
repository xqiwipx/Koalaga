using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    //상호작용 초안용 상점 인벤토리
    public ItemBuffer itemBuffer;
    public Transform slotRoot;

    private List<Slot> slots;

    public System.Action<ItemProperty> onSlotClick;

    void Start()
    {
        //itemBuffer = GameObject.Find("ItemBuffer").GetComponent<ItemBuffer>();

        slots = new List<Slot>();

        int slotCnt = slotRoot.childCount;

        for (int i = 0; i < slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if (i < itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);
            }else
            {
                //아이템 없으면? using UnityEngine.UI;
                slot.GetComponent<Button>().interactable = false;
            }

            slots.Add(slot);
        }

    }

    void Update()
    {
        
    }

    public void OnClickSlot(Slot slot)
    {
        //Debug.Log(slot.name + " 클릭 확인!");
        if(onSlotClick != null)
        {
            onSlotClick(slot.item);
            
        }

    }
}
