using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kolyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public CharacterController cl;
    public Transform zombie;
    Vector3 direction = new Vector3(0,0,1);//direction towards koly is moving
    Vector3 velocity;
    [SerializeField]//to see values in inspector
    private float speed = 0.0f;
    [SerializeField]
    private float gravity = 1.0f;
    [SerializeField]
    private float jump = 10f;
    private int score = 0;
    float timer=0;
    public Text text;
    public GameObject restart;
    //public GameObject[] ignore;
    void Start()
    {
      cl = GetComponent<CharacterController>();
      animator = GetComponent<Animator>();  
      animator.SetBool("isDead", false); 
      restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		velocity.z = direction.z*speed;
		float moveX = Input.GetAxis("Horizontal");
    	velocity.x=moveX*5;
        /*
         	Debug.Log("space is pressed");
         	direction.y+=4f;
         }*/
         if(velocity.y==0)
           {
           	animator.SetBool("isJump", false);
         	if(Input.GetKeyDown(KeyCode.Space))
         		{
         			animator.SetBool("isJump", true);
         			velocity.y = jump;
         			//Debug.Log("jump");		
                }
           }
         else
         {
         	velocity.y -= gravity;
         }
        cl.Move(velocity * Time.deltaTime);
        zombie.Translate(Vector3.forward*velocity.z*Time.deltaTime);
       // Debug.Log(velocity);
        timer+=Time.deltaTime;
        score=(int)timer*10;
        text.text="‡¯‹vit "+score;
        speed+=(0.05f*Time.deltaTime);
    }
}
