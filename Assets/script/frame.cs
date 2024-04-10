using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class frame : MonoBehaviour ,IPointerDownHandler
{
    private int now_matter;
    public GameObject ladle;
    public GameObject Imagemanager;
    private Image image;
    private Sprite metalcolor;
    private Sprite flourcolor;
    private Sprite patcolor;
    private Sprite r_flourcolor;
    private int bake; //얼마나 구워졌는지 확인용
    private bool now_bake = false; //틀에 쟤료를 붇고 건지기까지 참
    private bool patok = false;  //밀가루만 부었을떄 참
    private bool reverse = false; //붕어빵 뒤집어을떄만 참
    // Start is called before the first frame update
    void Awake()
    {
       ladle = GameObject.Find("ladle");
       Imagemanager = GameObject.Find("Imagemanager");
        flourcolor = Imagemanager.GetComponent<Imagemanager>().flourcolor;
        metalcolor = Imagemanager.GetComponent<Imagemanager>().metalcolor;
        patcolor = Imagemanager.GetComponent<Imagemanager>().patcolor;
        r_flourcolor = Imagemanager.GetComponent<Imagemanager>().r_flourcolor;
        image =GetComponent<Image>();
       image.sprite = metalcolor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator baking()
    {
        if (now_bake == true)
        {
            bake += 1;
            yield return new WaitForSeconds(.5f);
            StartCoroutine(baking());
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //좌클릭시
        if (Input.GetMouseButtonDown(0))
        {
            now_matter = ladle.GetComponent<ladle>().now_matter;
            //Debug.Log(now_matter);
            if (now_bake == false)
            {
                if (now_matter == 1)
                {
                    image.sprite = flourcolor;
                    now_bake = true;
                    patok = true;
                    bake = 0;
                    StartCoroutine(baking());
                }
                
            }
            if (patok == true && now_matter == 2)
            {
                image.sprite = patcolor;
                patok = false;
            }
        }
        //우클릭
        else if (Input.GetMouseButtonDown(1))
        {
            if (bake > 0 && bake <= 3)
            {
                Debug.Log("bad");
            }
            else if (bake > 3 && bake <= 6)
            {
                Debug.Log("good");
            }
            else if (bake > 6 && bake <= 9)
            {
                Debug.Log("bad");
            }
            else
            {
                Debug.Log("miss");
            }
            if (now_bake == true && reverse == false)
            {
                reverse = true;
                image.sprite = r_flourcolor;
                bake = 0;
            }
            else if(reverse == true)
            { 
                reverse = false;
                now_bake = false;
                image.sprite = metalcolor;
            }           
        }
    }
}
