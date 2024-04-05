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
    public int InterWin; //상호작용 창 설정

    public GameObject Savewin; //세이브 창
    public GameObject InventoryWin; //인벤토리 창
    public GameObject ViceWin; //발행처 창
    public GameObject GBWin; //퀘스트보드
    public GameObject MasterWin; //상급부서

    void Start()
    {
        WhereTxt.text = "길드 출근";
        InterWinMgr(0); //화면 창 정리
    }

    void Update()
    {
        //상호 작용 NPC 클릭
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

    public void InterWinMgr(int InterWin)
    { //상호작용 상태를 스위치화
        switch (InterWin)
        {
            case 0: //로비 초기화
                Savewin.SetActive(false); //세이브옵션 숨기기
                ViceWin.SetActive(false); //발행처 끄기
                InventoryWin.SetActive(false); //인벤토리 끄기
                InteractionWin.SetActive(false); //상호작용 끄기
                isLobby = false;
                break;

            case 1: //로비로 나오기
                Savewin.SetActive(false);

                ViceWin.SetActive(false);
                InventoryWin.SetActive(false);
                InteractionWin.SetActive(false);
                isLobby = true;

                break;

            case 2: //퇴근(세이브)
                isLobby = false;
                InteractionWin.SetActive(true);
                InventoryWin.SetActive(false);
                Savewin.SetActive(true); //세이브 버튼 활성화

                break;

            case 3: //서류 카트만 보기
                isLobby = false;
                InteractionWin.SetActive(true); //카트
                InventoryWin.SetActive(true); //인벤토리
                ViceWin.SetActive(false); //발행처
                GBWin.SetActive(false); //퀘스트보드
                MasterWin.SetActive(false); //상급부서

                Savewin.SetActive(false);
                break;

            case 4: //서류 발행처
                isLobby = false;
                InteractionWin.SetActive(true);
                InventoryWin.SetActive(true); //인벤토리
                ViceWin.SetActive(true); //발행처
                GBWin.SetActive(false);
                MasterWin.SetActive(false);

                Savewin.SetActive(false);
                break;

            case 5: //퀘스트 게시판
                isLobby = false;
                InteractionWin.SetActive(true);
                InventoryWin.SetActive(true); //인벤토리
                ViceWin.SetActive(false); //발행처
                GBWin.SetActive(true); //퀘스트보드
                MasterWin.SetActive(false); //상급부서

                Savewin.SetActive(false);
                break;

            case 6: //상급 부서
                isLobby = false;
                InteractionWin.SetActive(true);
                InventoryWin.SetActive(true); //인벤토리
                ViceWin.SetActive(false); //발행처
                GBWin.SetActive(false); //퀘스트보드
                MasterWin.SetActive(true); //상급부서

                Savewin.SetActive(false);
                break;

            case 7: //정산 하려면 모두 열어야 함
                InteractionWin.SetActive(true); //카트
                InventoryWin.SetActive(true); //인벤토리
                ViceWin.SetActive(true); //발행처
                GBWin.SetActive(true); //퀘스트보드
                MasterWin.SetActive(true); //상급부서

                break;

            case 8: //??

                break;
        }
    }

    //상호작용 창 on/off 로비 상태
    public void LobbyIn()
    {
        Debug.Log("상호작용 종료 후 Lobby로 나왔다.");
        WhereTxt.text = "길드 로비";
        
        InterWinMgr(1); //로비로 등장
    }
    public void LobbyOut()
    { //길드로비 초기화 클릭오류 방지
        InterWinMgr(0); //초기화
    }

    //서류카트 상호작용
    public void CartIn()
    {
        Debug.Log("Cart에 입장");
        WhereTxt.text = "서류 카트";
        InterWinMgr(3);
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "서류 운반용 길드지급품!";
        
    }

    //서류발급 장소
    public void ViceIn()
    {
        Debug.Log("Vice에 입장");
        WhereTxt.text = "서류 발행";
        InterWinMgr(4);
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "모든 서류가 발행되는 곳!";
        
    }

    //퀘스트 보드 직원
    public void BoardIn()
    {
        Debug.Log("Board에 입장");
        WhereTxt.text = "[게시판]";
        InterWinMgr(5);
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "주요업무 : 퀘스트보드 정리!";
    }

    //길드 마스터
    public void MasterIn()
    {
        Debug.Log("Master에 입장");
        WhereTxt.text = "상위 부서";
        InterWinMgr(6);
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "남은 서류는 모두 이곳으로!";
    }

    //세이브 포인트
    public void SaveIn()
    {
        Debug.Log("Save에 입장");
        WhereTxt.text = "퇴근해?";
        InterWinMgr(2);
        InterTxt.text = WhereTxt.text;
        InterTxt2.text = "퇴근전, 근무일지는 써야지!!";
        
    }
}
