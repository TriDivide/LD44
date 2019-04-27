using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float mouseSpeed = 3f;

    private PlayerMotor motor;

	// Use this for initialization
	void Start () {
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        // Standard movement with keyboard
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMovement;
        Vector3 moveVertical = transform.forward * zMovement;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        // Turning
        float rotation = Input.GetAxisRaw("Mouse X");
        Vector3 rotateVector = new Vector3(0f, rotation, 0f) * mouseSpeed;

        motor.Rotate(rotateVector);

        if (Input.GetKeyDown("space")) {
            PlayerModel.Instance.UpdateHealth(-1);
        }
    }

    void OnTriggerEnter(Collider other) {
        print("collided with object: " + other.gameObject.tag);
        if (other.gameObject.tag == "CollectableOne") {
            Destroy(other.gameObject);
        }
    }
}
