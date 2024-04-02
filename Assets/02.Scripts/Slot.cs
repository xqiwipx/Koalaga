using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [HideInInspector]
    public ItemProperty item;

    public Image image; // using UnityEngine.UI
    public Button SellBtn;

    private void Awake()
    {
        SetSellBtnInteractable(false);
    }

    //아이템 없는지 파악하여 판매방지용 함수추가
    void SetSellBtnInteractable(bool b)
    {
        if(SellBtn != null)
        {
            SellBtn.interactable = b;
        }
    }

    public void SetItem(ItemProperty item)
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;
            SetSellBtnInteractable(false);
            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;

            gameObject.name = item.name;
            image.sprite = item.sprite;
            SetSellBtnInteractable(true);
        }
    }

    public void OnClickSellBtn()
    {
        SetItem(null);
    }
}
