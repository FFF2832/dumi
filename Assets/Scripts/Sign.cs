using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject icon;
   
    public string signText;
     private bool isPlayerInSign;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerInSign=false;
        icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInSign){
            icon.SetActive(true);
                
        }
        else  icon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        icon.SetActive(true);
        isPlayerInSign=true;
        Debug.Log("133");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        icon.SetActive(false);
        isPlayerInSign=false;
    }
}
