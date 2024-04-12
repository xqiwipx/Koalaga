using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViceMaster : MonoBehaviour
{
    //아이템 생성용 상점
    public ItemBuffer itemBuffer; //아이템 리스트
    public Transform slotRoot; //슬롯틀?
    public BookCart bookCart; //서류카트

    private List<SlotC> slots; //슬롯 리스트 선언

    void Start()
    {
        bookCart = GameObject.Find("ItemBuffer").GetComponent<BookCart>();

        slots = new List<SlotC>(); //슬롯들 리스트 정의

        // 서류 발급처 초기화
        //슬롯카운트 만큼 반복
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            //대상슬롯은 i번째 슬롯의 컨포넌트 
            var slot = slotRoot.GetChild(i).GetComponent<SlotC>();

            //int j = Random.Range(0, itemBuffer.items.Count);
            int j = Random.Range(1, 6);
            //랜덤으로 아이템을 넣는다
            slot.SetItem(itemBuffer.items[j]);

            //슬롯 리스트에 해당 슬롯을 보낸다
            slots.Add(slot);
        }

    }

    void Update()
    {

    }

    public void NowItem()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var emptySlot = slots.Find(t =>
            {
                return t.item == null || t.item.name == string.Empty || t.item == itemBuffer.items[0];
            });

            if (emptySlot != null)
            {
                int j = Random.Range(1, 6);
                emptySlot.SetItem(itemBuffer.items[j]);
            }
        }
    }

    public void GetAll()
    {
        StartCoroutine("WaitGetAll");
    }

    IEnumerator WaitGetAll()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var itemSlot = slots.Find(t =>
            {
                return t.item != itemBuffer.items[0];
            });

            var cartSlot = bookCart.slots.Find(t =>
            {
                return t.item == itemBuffer.items[0];
            });
            if (cartSlot != null && itemSlot != null)
            {
                cartSlot.SetItem(itemSlot.item);
                itemSlot.SetItem(itemBuffer.items[0]);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        StopCoroutine("WaitGetAll");
    }

    public void QuestGet()
    {
        StartCoroutine("WiteQuestGet");
    }

    IEnumerator WiteQuestGet()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var itemSlot = slots.Find(t =>
            {
                return t.item == itemBuffer.items[1] || t.item == itemBuffer.items[2] || t.item == itemBuffer.items[3];
            });

            var cartSlot = bookCart.slots.Find(t =>
            {
                return t.item == itemBuffer.items[0] || t.item == itemBuffer.items[6];
            });
            if (itemSlot != null && cartSlot != null)
            {
                cartSlot.SetItem(itemSlot.item);
                itemSlot.SetItem(itemBuffer.items[0]);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        StopCoroutine("WiteQuestGet");
    }

}

