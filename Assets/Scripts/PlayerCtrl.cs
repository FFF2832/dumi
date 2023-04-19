using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
     Vector3 v3;
    float speed = 2f;
    public GameObject myBagUI;
    private bool isPlay;
    

    void Update()
    {
        //控制角色移動
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        v3 = new Vector3(x, 0, y);
        transform.Translate(v3*speed*Time.deltaTime);

        //控制UI顯示或隱藏
        if(Input.GetKeyDown(KeyCode.B))
        {
            isPlay = !isPlay;
            myBagUI.SetActive(isPlay);
        }
    }
}
