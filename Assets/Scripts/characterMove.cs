using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private enum MovementState{ idle ,running}
	 private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        coll=GetComponent<BoxCollider2D>();
        sprite=GetComponent<SpriteRenderer>();
        anim =GetComponent<Animator>();
        animskill =GetComponent<Animator>();
		target=transform.position;
    }

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
            //取得在鏡頭中的滑鼠位置
			lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			moving = true;
		}
	    else if (lastClickedPos.y>transform.position.y)
		{
			moving = false;
		}
        
	    else if (moving && (Vector2)transform.position != lastClickedPos)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
		}
        else if (transform.position.y== lastClickedPos.y)
		{
			moving = false;
		}
	    else
		{
			moving = false;
		}
		UpdateAnimationState();
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
//    public static List<characterMove> moveableObjects = new List<characterMove>();
//     public float speed=5f;
//     private Vector2 target;
//     private bool selected;
//     private bool moving;
//     private void Start()
//     {
//         moveableObjects.Add(this);
//         target=transform.position;
//     }

//     void Update()
//     {

//         if(Input.GetMouseButtonDown(1)&&selected){
//             target=Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             //target.z=transform.position.z;
//             moving = true;
//         }
//         transform.position=Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
//     }
   
//     private void OnMouseDown()
//     {
//         selected=true;
//         gameObject.GetComponent<SpriteRenderer>().color=Color.green;
//         foreach(characterMove obj in moveableObjects){
//             if(obj!=this){
//                 obj.selected=false;
//                 obj.gameObject.GetComponent<SpriteRenderer>().color=Color.white;
//             }
//         }
//     }
    

//     public  static GameObject player;//主角
// private CharacterController controller;//行走控制器

// private bool IsMoving = false;//表示鼠标是否按下

// private Vector3 printPosition = Vector3.zero;
// private float speed = 4;//人物行走速度
// private enum MovementState{ idle ,running}
// private Animation Anima;//控制人物动画
//  private Animator anim; 
// // Start is called before the first frame update
// [SerializeField]
// private GameObject[] PlayerPrint;//移动标识
// void Start()
// {
//     anim =GetComponent<Animator>();
//     controller = this.GetComponent<CharacterController>();
//     Anima = player.gameObject.GetComponent<Animation>();
//     printPosition = player.transform.position;//设置移动标识的初始位置
// }
 
// // Update is called once per frame
// void Update()
// {
//     //鼠标点击目的地
//     GetRay();
//     //人物动作控制
//     AnimaControl();
// }


// void GetRay()
// {
//     if (Input.GetMouseButtonDown(0))
//     {

//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit hit;
//         bool iscollider = Physics.Raycast(ray, out hit);

//         if (iscollider)
//         {
           
//             if (hit.collider.tag == "floor")
//             {
//                 IsMoving = true;
//                 ShowClickEffect(hit.point);//实例化出来点击的效果
//                 LookAtTarget(hit.point);//让主角朝向目标位置
//                 Debug.Log("234");
//             }
//         }
//     }
// }
// //实例化出来点击的效果
// void ShowClickEffect(Vector3 hitPoint)
// {
//     hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
//     Instantiate(PlayerPrint[0], hitPoint, Quaternion.identity);
// }
// //让主角朝向目标位置
// void LookAtTarget(Vector3 hit)
// {
//     printPosition = new Vector3(hit.x, transform.position.y, hit.z);
//     this.transform.LookAt(printPosition);
// }
// void AnimaControl()
// {
//     MovementState state;
//     state=MovementState.running;
//     if (IsMoving)
//     {
//         float distance = Vector3.Distance(printPosition, player.transform.position);
//         if (distance >= 0.1f)
//         {
            
//             LookAtTarget(printPosition);
//             //Anima.Play(AnimaName.walking);
//             state=MovementState.running;
//             Debug.Log("distance的距离" + distance);
//             controller.SimpleMove(transform.forward * speed);
//         }
//         else
//         {
           
//             //Anima.Play(AnimaName.idle);
//             IsMoving = false;
//         }
//     }
//     else
//     {
//        // Anima.Play(AnimaName.idle);
//     }
// }

}
