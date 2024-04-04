using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    //상호작용 관련
    public Text WhereTxt; //장소 표시
    public GameObject InteractionWin; //상호작용BG
    public Text InterTxt; //상호작용창 이름
    public Text InterTxt2; //상호작용창 설명

    public bool isLobby = false;

    public GameObject Savewin; //세이브 창

    void Start()
    {
        isLobby = false; //
        WhereTxt.text = "길드 출근";
        Savewin.SetActive(false); //세이브옵션 숨기기
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isLobby != false)
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
                            //Debug.Log(hit.collider.name + "에 맞았다!!");
                            break;
                    }

                }


            }
        }
    }

    //상호작용 창 on/off 로비 상태
    public void InteractionOn()
    {
        Debug.Log("상호작용 활성화");
        InteractionWin.SetActive(true); //상호작용 켜기
        isLobby = false;
    }
    public void LobbyIn()
    {
        Debug.Log("상호작용 종료 후 Lobby로 나왔다.");
        WhereTxt.text = "길드 로비";
        
        isLobby = true;

        SaveOut(); //세이브 옵션 끄기
        InteractionWin.SetActive(false); //상호작용 끄기
    }
    public void LobbyOut()
    {
        isLobby = false;
    }

    //서류카트 상호작용
    public void CartIn()
    {
        Debug.Log("Cart에 입장");
        WhereTxt.text = "서류 카트";
        InteractionOn();
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "서류 운반용 길드지급품!";
    }

    //서류발급 장소
    public void ViceIn()
    {
        Debug.Log("Vice에 입장");
        WhereTxt.text = "서류 발행";
        InteractionOn();
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "모든 서류가 발행되는 곳!";
    }

    //퀘스트 보드 직원
    public void BoardIn()
    {
        Debug.Log("Board에 입장");
        WhereTxt.text = "[게시판]";
        InteractionOn();
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "주요업무 : 퀘스트보드 정리!";
    }

    //길드 마스터
    public void MasterIn()
    {
        Debug.Log("Master에 입장");
        WhereTxt.text = "상위 부서";
        InteractionOn();
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "남은 서류는 모두 이곳으로!";
    }

    //세이브 포인트
    public void SaveIn()
    {
        Debug.Log("Save에 입장");
        WhereTxt.text = "퇴근해?";
        InteractionOn();
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "퇴근전, 근무일지는 써야지!!";

        Savewin.SetActive(true); //세이브 버튼 활성화
    }
    public void SaveOut()
    {
        Savewin.SetActive(false);
    }
}
