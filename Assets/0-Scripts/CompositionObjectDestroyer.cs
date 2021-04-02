using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class CompositionObjectDestroyer : MonoBehaviour {
        public Transform destroyPositionDummy;
        private float destroyX;
        
        private void Update() {
            CheckForDestroying();
        }

        public void SetDestructionPointX(float aPositionX) {
            destroyX = aPositionX;
        }

        private void CheckForDestroying() {
            if (destroyPositionDummy.position.x<destroyX) {
                Destroy(gameObject);
            }
        }
    }
}