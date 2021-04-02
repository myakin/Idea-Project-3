using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class CompositionObjectNextCompositionObjectGenerationCriteria : MonoBehaviour {
        public Transform nextgenerationPositionDummy;
        public float positionXForNextGeneration;
        private GameManager gameManager;
        private bool isNextObjectRequest;

        private void Update() {
            if (!isNextObjectRequest && nextgenerationPositionDummy.position.x < positionXForNextGeneration) {
                isNextObjectRequest = true;
                gameManager.GenerateSceneCompositionObject();
            }
        }

        public void SetGameManager(GameManager aGameManager) {
            gameManager = aGameManager;
        }
    }
}
