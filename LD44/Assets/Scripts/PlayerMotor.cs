using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Component player;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    private Rigidbody rb;

    // Use this for initialization
    void Start() {
        rb = player.GetComponent<Rigidbody>();
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
        if (rb != null && velocity != Vector3.zero) {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation() {
        if (rb != null) {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        }
    }
}
