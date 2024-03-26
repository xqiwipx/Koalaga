using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBtn : MonoBehaviour
{
    // 버튼 테스트용 더미 이벤트
    public GameObject Dummybtn;
    
    void Start()
    {
        Dummybtn.SetActive(false);
    }

    void Update()
    {
        
    }

    public void DummyEvent()
    {
        Dummybtn.SetActive(true);
    }

    public void OnClickDummyBtn()
    {
        Dummybtn.SetActive(false);
    }
}
