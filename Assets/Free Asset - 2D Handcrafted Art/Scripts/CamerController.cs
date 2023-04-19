using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour {
    public float speed;
    public float clampLeft;
    public float clampRight;
    public GameObject obj;
    private float cameraX;
    private float cameraY;
    // Use this for initialization
    void Start () {
        
        cameraX = transform.position.x;
		cameraY = transform.position.y-5;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < clampRight)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > clampLeft)
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(cameraX);
        }
    }
}
// using UnityEngine;
// using System.Collections;

// public class CamerController : MonoBehaviour
// {
//       public Transform target;
//     public float smoothing;

//     public Vector2 minPosition;
//     public Vector2 maxPosition;

//     // Start is called before the first frame update
//     void Start()
//     {
//         //GameController.camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
//     }

//     void LateUpdate()
//     {
//         if(target != null)
//         {
//             if(transform.position != target.position)
//             {
//                 Vector3 targetPos = target.position;
//                 targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
//                 targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
//                 transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
//             }
//         }
//     }

//     public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
//     {
//         minPosition = minPos;
//         maxPosition = maxPos;
//     }
          
// }
