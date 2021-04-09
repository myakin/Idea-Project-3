using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class PlatformMover : MonoBehaviour {
        public MoveSpeedSettings moveSpeedSettings;
        public Transform outOfViewPosDummy, movePosDummy;
        private float moveSpeed;

        private void Start() {
            moveSpeed = moveSpeedSettings.speed;
        }

        void Update()
        {
            if (GameManager.instance.player.GetComponent<PlayerController>().isDead==false) {
                transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
            }        
            if (transform.position.x < outOfViewPosDummy.position.x){
                    transform.position = movePosDummy.position;
            }
        }
    }
}