using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMgr : MonoBehaviour
{
    //출근하면 서류를 빈 슬롯에 생성하는 기능

    private InventoryMgr inventoryMgr;

    //생성할 아이템 프리팹
    public GameObject ItemPrefab;

    //변경된 날짜를 감지하는 변수
    public int ItemDay = 0;
    private TimeLine timeLine;

    //해당 슬롯의 아이템 상태 확인
    public int ItemNum = 0; //0이 아니면 들어있음

    void Start()
    {
        inventoryMgr = GameObject.Find("GameMgr").GetComponent<InventoryMgr>();

        timeLine = GameObject.Find("GameMgr").GetComponent<TimeLine>();
        // 셋팅 초기화 & 시작시 아이템 생성
        ItemRenMake();
    }

    void Update()
    {
        // 날짜 변경되면 아이템 생성함수 실행
        if(ItemDay != timeLine.Days)
        {
            Debug.Log("발행처에 서류 추가");
            ItemRenMake();
        }
    }

    //아이템을 빈 슬롯에 넣는 함수 정의
    //담당 슬롯이 비어 있는지 확인
    //빈 슬롯의 좌표에 아이템을 랜덤으로 골라 생성

    void ItemRenMake()
    {
        ItemDay = timeLine.Days; //날짜 변경

        for (int i = 0; i < inventoryMgr.slots.Length; i++)
        {
            if (inventoryMgr.fullcheck[i] == false)
            {
                Debug.Log("서류가 생성됩니다.");
                switch (ItemNum)
                {
                    case 0:
                        // 슬롯을 채운다
                        inventoryMgr.fullcheck[i] = true;
                        Instantiate(ItemPrefab, inventoryMgr.slots[i].transform, false); break;
                    default:
                        break;
                }
            }
            else
            {
                Debug.Log("서류가 이미 있습니다.");
            }
        }


        

    }

    //참고중인 코드
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player") //충돌 플레이어
    //    {
    //        for(int i = 0; i < inventoryMgr.slots.Length; i++) //슬롯에 순차적으로
    //        {
    //            // 빈슬롯?
    //            if(inventoryMgr.fullcheck[i] == false)
    //            {
    //                // 슬롯을 채운다
    //                inventoryMgr.fullcheck[i] = true;
    //                Instantiate(ItemPrefab, inventoryMgr.slots[i].transform, false);
    //                //아이템을 생성, i번째 슬롯 좌표, ?? 
    //                Destroy(gameObject); //기존 개체 삭제
    //                break;
    //            }
    //        }
    //    }
    //}

    
}
