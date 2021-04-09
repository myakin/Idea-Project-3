using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class CompositionObjectMover : MonoBehaviour {
        public MoveSpeedSettings moveSpeedSettings;
        private float moveSpeed;

        private void Start() {
            moveSpeed = moveSpeedSettings.speed;
        }

        private void Update() {
            if (!GameManager.instance.player.GetComponent<PlayerController>().isDead) {
                transform.position += -transform.right * (moveSpeed * Time.deltaTime);
            }
            
            if (Input.GetKeyDown(KeyCode.O)) {
                moveSpeedSettings.IncreaseSpeed();
                moveSpeed = moveSpeedSettings.speed;
            }
        }
    }
}
