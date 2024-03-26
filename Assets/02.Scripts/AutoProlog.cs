using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoProlog : MonoBehaviour
{
    //시작화면에서 대시시간 지나면 자동프롤로그가 나옴

    public GameObject Autoprolog;
    public GameObject EventImg0;
    public GameObject EventImg1;
    public GameObject EventImg2;
    public GameObject EventImg3;

    public float WaitProlog = 60;
    public float WaitPrologimg = 5;

    void Start()
    {

        EventImg0.SetActive(true);
        EventImg1.SetActive(true);
        EventImg2.SetActive(true);
        EventImg3.SetActive(true);
        Autoprolog.SetActive(false);
        
        StartCoroutine(loadProlog());
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator loadProlog()
    {
        //Debug.Log("대기전");
        yield return new WaitForSecondsRealtime(WaitProlog);
        //Debug.Log("대기후");
        Autoprolog.SetActive(true);
        yield return new WaitForSecondsRealtime(WaitPrologimg);
        EventImg0.SetActive(false);
        yield return new WaitForSecondsRealtime(WaitPrologimg);
        EventImg1.SetActive(false);
        yield return new WaitForSecondsRealtime(WaitPrologimg);
        EventImg2.SetActive(false);
        yield return new WaitForSecondsRealtime(WaitPrologimg);
        EventImg3.SetActive(false);
        //yield return new WaitForSecondsRealtime(WaitPrologimg);
        SceneManager.LoadScene(0);

    }

}
