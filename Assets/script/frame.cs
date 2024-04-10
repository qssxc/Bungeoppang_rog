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
    private int bake; //�󸶳� ���������� Ȯ�ο�
    private bool now_bake = false; //Ʋ�� ���Ḧ �Ѱ� ��������� ��
    private bool patok = false;  //�а��縸 �ξ����� ��
    private bool reverse = false; //�ؾ ������������ ��
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
        //��Ŭ����
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
        //��Ŭ��
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
