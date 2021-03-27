using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float antiGravityForceMagnitude = 10;

    private new Rigidbody2D rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            rigidbody.AddForce(Vector3.up * antiGravityForceMagnitude, ForceMode2D.Impulse);
        }
    }


}
