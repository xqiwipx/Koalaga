using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    //퇴근하면 슬롯의 아이템이 제거 됨
    public int i;
    private InventoryMgr inventoryMgr;

    void Start()
    {
        inventoryMgr = GameObject.Find("GameMgr").GetComponent<InventoryMgr>();
    }

    void Update()
    {
        if(transform.childCount <= 0)
        {
            inventoryMgr.fullcheck[i] = false;
        }
    }

    public void RemeveItem()
    {
        for(int idx = 0; idx < transform.childCount; idx++)
        {
            Destroy(transform.GetChild(idx).gameObject);
        }
    }
}
