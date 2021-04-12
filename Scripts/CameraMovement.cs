using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
	public Transform koly;
    public Transform light;
	public Vector3 distance;
    public Vector3 lightDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = koly.position + distance;
        light.transform.position = koly.position+lightDistance;
    }
    public void gameRestart()
        {
            SceneManager.LoadScene(0);
        }
}
