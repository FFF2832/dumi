using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    Animator anim;

    public float speed;
    Vector2 movement;
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
      //public GameObject uiInventory;   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        inventory  =new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {
        Movement();
        SwitchAnim();
    }

    void Movement()//移动
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

    }

    void SwitchAnim()//切换动画
    {
        if (movement != Vector2.zero)//保证Horizontal归0时，保留movment的值来切换idle动画的blend tree
        {
            anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
        }
        anim.SetFloat("speed", movement.magnitude);//magnitude 也可以用 sqrMagnitude 具体可以参考Api 默认返回值永远>=0
    }
}
