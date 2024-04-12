using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildMaster : MonoBehaviour
{
    //아이템 생성용 상점
    public ItemBuffer itemBuffer; //아이템 리스트
    public Transform slotRoot; //슬롯틀?
    public BookCart bookCart;

    private List<SlotC> slots; //슬롯 리스트 선언

    void Start()
    {
        bookCart = GameObject.Find("ItemBuffer").GetComponent<BookCart>();

        slots = new List<SlotC>(); //슬롯들 리스트 정의

        for (int i = 0; i < slotRoot.childCount; i++)
        {
            //대상슬롯은 i번째 슬롯의 컨포넌트 
            var slot = slotRoot.GetChild(i).GetComponent<SlotC>();

            //슬롯 아이템을 비운다.
            slot.SetItem(itemBuffer.items[0]);

            //슬롯 리스트에 보낸다.
            slots.Add(slot);
        }

    }

    void Update()
    {

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
            slot.SetItem(itemBuffer.items[0]);

        }
    }

    public void SendAll()
    {
        StartCoroutine("WiteSendAll");

    }

    IEnumerator WiteSendAll()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var cartSlot = bookCart.slots.Find(t =>
            {
                return t.item != itemBuffer.items[0];
            });

            var GmaSlot = slots.Find(t =>
            {
                return t.item == itemBuffer.items[0];
            });
            if (cartSlot != null && GmaSlot != null)
            {
                GmaSlot.SetItem(cartSlot.item);
                cartSlot.SetItem(itemBuffer.items[0]);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        StopCoroutine("WiteSendAll");
    }



    public void Delivery()
    {
        StartCoroutine("WiteDelivery");

        
    }

    IEnumerator WiteDelivery()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var cartSlot = bookCart.slots.Find(t =>
            {
                return t.item == itemBuffer.items[4] || t.item == itemBuffer.items[5];
            });

            var GmaSlot = slots.Find(t =>
            {
                return t.item == itemBuffer.items[0];
            });
            if (cartSlot != null && GmaSlot != null)
            {
                GmaSlot.SetItem(cartSlot.item);
                cartSlot.SetItem(itemBuffer.items[0]);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        StopCoroutine("WiteDelivery");
    }


}

