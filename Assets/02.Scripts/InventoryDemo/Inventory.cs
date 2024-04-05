using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform rootSlot;
    public Store store;

    private List<Slot> slots;

    void Start()
    {
        slots = new List<Slot>();

        int slotCnt = rootSlot.childCount;

        for (int i = 0; i < slotCnt; i++)
        {
            var slot = rootSlot.GetChild(i).GetComponent<Slot>();

            slots.Add(slot);
        }
        store.onSlotClick += BuyItem;
    }

    void Update()
    {
        
    }

    void BuyItem(ItemProperty item)
    {
        //Debug.Log(item.name + " 값을 받아왔다.");
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.name == string.Empty;
        });

        if (emptySlot != null)
        {
            emptySlot.SetItem(item);
        }
    }
}
