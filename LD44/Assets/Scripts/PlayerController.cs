using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float mouseSpeed = 3f;


	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        // Standard movement with keyboard
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMovement;
        Vector3 moveVertical = transform.forward * zMovement;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;


        // Turning
	}
}
