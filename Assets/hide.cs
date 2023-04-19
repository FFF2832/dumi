using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    public GameObject image;   //对话框
    // Start is called before the first frame update
    void Start()
    {
         image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
          image.SetActive(true);
    }
}
