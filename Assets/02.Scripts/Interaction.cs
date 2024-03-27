using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    //상호작용 관련
    public Text WhereTxt; //장소 표시

    void Start()
    {
        WhereTxt.text = "길드 출근";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.name + "에 맞았다!!");
                if (hit.collider != null)
                {
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Player":
                            CartIn();
                            break;

                        case "ViceMaster":
                            ViceIn();
                            break;

                        case "QuestBoard":
                            BoardIn();
                            break;

                        case "GuildMaster":
                            MasterIn();
                            break;

                        case "SavePoint":
                            SaveIn();
                            break;

                        default:
                            Debug.Log(hit.collider.name + "에 맞았다!!");
                            break;
                    }
                }


            }
        }
    }

    //서류카트 상호작용
    public void CartIn()
    {
        Debug.Log("Cart에 입장");
        WhereTxt.text = "서류 카트";
    }

    //서류발급 장소
    public void ViceIn()
    {
        Debug.Log("Vice에 입장");
        WhereTxt.text = "서류 발행";
    }

    //퀘스트 보드 직원
    public void BoardIn()
    {
        Debug.Log("Board에 입장");
        WhereTxt.text = "[게시판]";
    }

    //길드 마스터
    public void MasterIn()
    {
        Debug.Log("Master에 입장");
        WhereTxt.text = "상위 부서";
    }

    //세이브 포인트
    public void SaveIn()
    {
        Debug.Log("Save에 입장");
        WhereTxt.text = "퇴근해?";
    }

    //상호작용 해제
    public void LobbyIn()
    {
        Debug.Log("Lobby로 나왔다.");
        WhereTxt.text = "길드 로비";
    }


}
