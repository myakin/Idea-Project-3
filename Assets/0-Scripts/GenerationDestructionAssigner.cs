using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class GenerationDestructionAssigner : MonoBehaviour
    {
        public bool isDestructionDummy;

        private void Start() {
            if (!isDestructionDummy) {
                GameManager.instance.generationPositionDummy = transform;
            } else {
                GameManager.instance.destructionPositionDummy = transform;
            }
        }  
    }
}
