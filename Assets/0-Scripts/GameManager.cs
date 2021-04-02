using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class GameManager : MonoBehaviour {
        [Header("Editor References")]
        public Transform generationPositionDummy;
        public Transform destructionPositionDummy;

        [Header("Prefab to Generate (will be removed later)")]
        public GameObject[] prefabs;
        private int indexToGenerate;

        
        public void GenerateSceneCompositionObject() {
            indexToGenerate = Random.Range(0, prefabs.Length);
            GameObject obj = Instantiate(prefabs[indexToGenerate]);

            obj.GetComponent<CompositionObjectGenerator>().PositionCompositionObject(generationPositionDummy.position);
            obj.GetComponent<CompositionObjectDestroyer>().SetDestructionPointX(destructionPositionDummy.position.x);
            obj.GetComponent<CompositionObjectNextCompositionObjectGenerationCriteria>().SetGameManager(this);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.O)) {
                GenerateSceneCompositionObject();
            }
        }

    }
}
