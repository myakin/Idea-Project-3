using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class PlatformMover : MonoBehaviour {
        public float moveSpeed = 0.1f;
        public Transform outOfViewPosDummy, movePosDummy;
        void Update()
        {
            if (GameManager.instance.player.GetComponent<PlayerController>().isDead==false) {
                transform.position += Vector3.left * moveSpeed;
            }        
            if (transform.position.x < outOfViewPosDummy.position.x){
                    transform.position = movePosDummy.position;
            }
        }
    }
}