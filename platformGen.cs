using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] platform;
    public Transform player;
    private float spawnP=0.0f;
    private float platformLen = 200f;
    private List<GameObject> activePlatform;
    void Start()
    {
    	activePlatform = new List<GameObject>();
    	spawn();
    	spawn();
    }

    // Update is called once per frame
    void Update()
    {
       if(player.position.z>((spawnP-platformLen)+10))
       {
       	spawn();
       	delete();
       } 
    }

    void spawn(int index = -1)
    {
    	GameObject go;
    	go = Instantiate (platform[0]) as GameObject;
    	go.transform.position = Vector3.forward * spawnP;
    	spawnP += 200;
    	activePlatform.Add(go);
    }
    void delete()
    {
    	Destroy(activePlatform[0]);
    	activePlatform.RemoveAt(0);
    }
}
