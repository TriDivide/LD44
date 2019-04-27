using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Component player;

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    private Rigidbody playerRigidbody;

    // Use this for initialization
    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();

    }

    public void Move(Vector3 movementVelocity) {
        velocity = movementVelocity;
    }

    public void Rotate(Vector3 rotationVelocity) {
        rotation = rotationVelocity;
    }

    private void FixedUpdate() {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement() {
        if (velocity != Vector3.zero) {
            print("Moving to position");
            playerRigidbody.MovePosition(playerRigidbody.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation() {
        print("rotating player");
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.Euler(rotation));
        
    }
}
