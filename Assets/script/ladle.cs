using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladle : MonoBehaviour
{
    [SerializeField]
    public int now_matter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pat_click()
    {
        now_matter = 0;
    }
    public void Flour_click()
    {
        now_matter = 1;
    }
}
