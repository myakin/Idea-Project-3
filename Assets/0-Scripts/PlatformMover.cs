using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {
    public float moveSpeed = 0.1f;
    public Transform outOfViewPosDummy, movePosDummy;
   
    void Update() {
        transform.position += Vector3.left * moveSpeed;
        if (transform.position.x < outOfViewPosDummy.position.x) {
            transform.position = movePosDummy.position;
        }
    }
}
