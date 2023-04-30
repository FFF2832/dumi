using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class characterMove : MonoBehaviour
{
    public float speed = 0.01f;
	
	Vector2 lastClickedPos;
	
	bool moving;
	private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim; 
    private Animator animskill;
	 private Vector2 target;
	private enum MovementState{ idle ,running};
     //private Inventory inventory;
    //[SerializeField] private UI_Inventory uiInventory;
     public GameObject myBag; 
     public GameObject password; 
     bool isOpen;  
    public item thisItem;
  
    public Inventory playerInventory;
   
    public itemOnworld itemOnworldInstance;
  
	 private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        coll=GetComponent<BoxCollider2D>();
        sprite=GetComponent<SpriteRenderer>();
        anim =GetComponent<Animator>();
        animskill =GetComponent<Animator>();
		target=transform.position;
        myBag.SetActive(false);
        password.SetActive(false);
        //itemOnworldInstance = FindObjectOfType<itemOnworld>();
        
    }

	private void Update()
	{
    

   
        if (Input.GetMouseButtonDown(0))
    {
        // 取得在鏡頭中的滑鼠位置
        Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 只保留 X 軸座標，不要上下移動
        lastClickedPos = new Vector2(clickPos.x, transform.position.y);

        moving = true;
    }
    else if (moving && (Vector2)transform.position != lastClickedPos)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
    }
        else if (lastClickedPos.y>transform.position.y)
		{
			moving = false;
		}
    else
    {
        moving = false;
    }

		UpdateAnimationState();
        check2DObjectClicked();
        
	}
	private void UpdateAnimationState()
    {
        MovementState state;
        if((transform.position.x<lastClickedPos.x)&& moving){
                state=MovementState.running;
                sprite.flipX=false;
                
        }
        else if((transform.position.x>lastClickedPos.x)&&moving){
            state=MovementState.running;
            sprite.flipX=true;
            
        }
        else if(rb.velocity.x==lastClickedPos.x){
            state=MovementState.idle;
             moving = false;
        }
        else  {
            state=MovementState.idle;
            moving = false;
        }
        //用來判斷是否在天空
    //     if(rb.velocity.y> .01f)
    //     {
    //         state=MovementState.jumping;
    //     }
    //     else if(rb.velocity.y< -.1f)
    //     {
    //         state=MovementState.falling;
    //     }
    //    if(Input.GetKey(KeyCode.Q) ){
    //         state=MovementState.skill;
          
    //     }
        anim.SetInteger("state",(int)state);
    }

private void OnCollisionEnter(Collision other)
{
    if(other.gameObject.tag=="npc"){
        Debug.Log("132");
    }
}
 void OpenMybag(){
    if(Input.GetMouseButtonDown(0)){

        isOpen= !isOpen;
        myBag.SetActive(isOpen);
         if(isOpen)moving=false;

        
        
    }
    

}
 void OpenPasswordUI(){
    if(Input.GetMouseButtonDown(0)){
        isOpen= true;
        password.SetActive(isOpen);
    }
}
 void check2DObjectClicked()
{
    if (Input.GetMouseButtonDown(0))
    {
        Debug.Log("Mouse is pressed down");
        Camera cam = Camera.main;

        //Raycast depends on camera projection mode
        Vector2 origin = Vector2.zero;
        Vector2 dir = Vector2.zero;

        if (cam.orthographic)
        {
            origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            origin = ray.origin;
            dir = ray.direction;
        }

        RaycastHit2D hit = Physics2D.Raycast(origin, dir);

        //Check if we hit anything
        if (hit)
        {
            
            if(hit.collider.name=="Bagicon"){
             
                Debug.Log("We hit " + hit.collider.name);
                moving=false;
                OpenMybag();
            }

            if(hit.collider.name=="Password"){
             
                Debug.Log("We hit " + hit.collider.name);
                moving=false;
                this.enabled = false;
                 OpenPasswordUI();
            }
            if(hit.collider.name=="樹枝本人"){
             
                Debug.Log("We hit " + hit.collider.name);
                itemOnworldInstance.AddNewItem();
                Destroy(hit.collider);
                Debug.Log("touch");
            }
             if(hit.collider.name=="Password"){
             
                Debug.Log("We hit " + hit.collider.name);
               if(CheckInput.ChangeScene){
                    CheckInput.ChangeTonight();
                 }
                
            }
            if (hit.collider.CompareTag("UI"))
            {
               this.enabled = false;
                moving = false;
            }
            else
            {
            // 點擊到非 UI 物件，將 moving 設定為 false
            
            }       
             

        }
    } 
    
}


}