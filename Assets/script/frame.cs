using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frame : MonoBehaviour
{
    private int now_matter;
    public GameObject ladle;
    private Image image;
    [SerializeField]
    private Sprite metalcolor;
    [SerializeField]
    private Sprite flourcolor;

    // Start is called before the first frame update
    void Start()
    {
       ladle = GameObject.Find("ladle");
       
       image =GetComponent<Image>();
       image.sprite = metalcolor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void get_Put()
    {
        now_matter = ladle.GetComponent<ladle>().now_matter;
        Debug.Log(now_matter);
        if (now_matter == 0) { image.sprite = metalcolor; }
        else if (now_matter == 1) { image.sprite = flourcolor; }
    }
}
