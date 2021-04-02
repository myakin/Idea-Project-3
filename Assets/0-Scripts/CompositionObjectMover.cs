using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class CompositionObjectMover : MonoBehaviour {
        public float moveSpeed = 0.01f;

        private void Update() {
            transform.position += -transform.right * moveSpeed;
        }

        
    }
}
