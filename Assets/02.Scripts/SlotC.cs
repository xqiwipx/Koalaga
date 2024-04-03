using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotC : MonoBehaviour
{
    [HideInInspector]
    // 해당 아이템 선언?
    public ItemProperty item;

    //using UnityEngine.UI
    public Image image; // 변하는 이미지 선언
    //public Button SellBtn; // 판매버튼 선언

    //private void Awake()
    //{
    //    //해당 함수를 비활성화 한다?
    //    SetSellBtnInteractable(false);
    //}

    ////아이템 없는지 파악하여 판매방지용 함수추가
    ////해당 함수에 불변수 b값을 적용
    //void SetSellBtnInteractable(bool b)
    //{
    //    //판매버튼이 널값이 아니면
    //    if(SellBtn != null)
    //    {
    //        //판매버튼 활성화 여부에 b값을 넣는다
    //        SellBtn.interactable = b;
    //    }
    //    //아이템이 있을때만 판매버튼을 사용할 수 있다
    //}

    //아이템 장착 함수 정의 (아이템 정보)
    public void SetItem(ItemProperty item)
    {
        //현재 아이템에 아이템 정보를 넣는다
        this.item = item;

        //아이템값이 널인가?
        if (item == null)
        {
            //이미지 사용을 비활성화
            image.enabled = false;
            //판매버튼 비활성화 설정
            //SetSellBtnInteractable(false);
            //아이템이 없으면 "Empty" 넣는다
            gameObject.name = "Empty";
        }
        else //아이템값이 있으면
        {
            //이미지 사용을 활성화
            image.enabled = true; 

            //해당 개제 이름에 아이템 이름을 넣는다
            gameObject.name = item.name;
            //이미지에 아이템 이미지를 넣는다
            image.sprite = item.sprite;
            //판매버튼을 활성화 설정
            //SetSellBtnInteractable(true);
        }
    }

    //판매버튼 함수를 정의한다
    public void OnClickSellBtn()
    {
        //아이템 넣는 함수에 널값을 넣는다
        SetItem(null);
    }
}
