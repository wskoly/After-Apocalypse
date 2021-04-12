using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollide : MonoBehaviour
{
    public kolyMovement movement;
    public GameObject koly;
    private Collider kolyCollide;
    public GameObject[] zombie;
    Animator animator;
    private List<Animator> zombieAnim;
    private int flag=0;
    public Text Midtext;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.tag == "zombies")
        {
            flag=1;
            GetComponent<kolyMovement>().enabled = false;
            //Debug.Log("Game Over");
        }
    }
	/*void OnCollisionEnter(Collision hit)
	{
		if(hit.collider.tag == "obstacles")
		{
           // movement.cl.enabled = false;
			Debug.Log("Game Over");
		}
	}*/
    // Start is called before the first frame update
    void Start()
    {
        kolyCollide=koly.GetComponent<Collider>();
        zombieAnim = new List<Animator>();
        animator = gameObject.GetComponent<Animator>();
        for(int i = 0; i < zombie.Length; i++)
        {
            zombieAnim.Add(zombie[i].GetComponent<Animator>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(flag>0)
        {
            animator.SetBool("isDead", true);
            Midtext.text="‡Lj LZg";
            for(int i=0; i<zombie.Length; i++)
            {
              zombieAnim[i].SetBool("move", false);
            }
            kolyCollide.enabled=false;
            movement.restart.SetActive(true);
        }
    }
}
