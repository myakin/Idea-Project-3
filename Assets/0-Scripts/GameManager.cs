using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class GameManager : MonoBehaviour {
        public static GameManager instance;

        private void Awake() {
            if (instance==null) {
                instance = this;
                DontDestroyOnLoad(gameObject);
            } else {
                if (instance!=this) {
                    Destroy(gameObject);
                }
            }
        }

        [Header("Editor References")]
        public GameObject player;
        public Transform generationPositionDummy;
        public Transform destructionPositionDummy;

        [Header("Game Settings")]
        public int[] numberOfCompositionPrefabs;

        private int indexToGenerate;
        private int currentLevel;

        private void Start() {
            GenerateSceneCompositionObject();
        }

        
        public void GenerateSceneCompositionObject() {
            indexToGenerate = Random.Range(0, numberOfCompositionPrefabs[currentLevel]);
            GameObject obj = Instantiate(Resources.Load("SceneCompositionObject_Level1_Variation"+indexToGenerate) as GameObject);

            if (!obj.GetComponent<CompositionObjectGenerator>()) {
                obj.AddComponent<CompositionObjectGenerator>();
                obj.GetComponent<CompositionObjectGenerator>().genrationPointDummy = obj.transform.Find("GenerationPositionDummy");
            }
            obj.GetComponent<CompositionObjectGenerator>().PositionCompositionObject(generationPositionDummy.position);

            if (!obj.GetComponent<CompositionObjectDestroyer>()) {
                obj.AddComponent<CompositionObjectDestroyer>();
                obj.GetComponent<CompositionObjectDestroyer>().destroyPositionDummy = obj.transform.Find("DestroyPositionDummy");
            }
            obj.GetComponent<CompositionObjectDestroyer>().SetDestructionPointX(destructionPositionDummy.position.x);

            if (!obj.GetComponent<CompositionObjectNextCompositionObjectGenerationCriteria>()) {
                obj.AddComponent<CompositionObjectNextCompositionObjectGenerationCriteria>();
                obj.GetComponent<CompositionObjectNextCompositionObjectGenerationCriteria>().nextgenerationPositionDummy = obj.transform.Find("NextGenerationDummy");
            }
            obj.GetComponent<CompositionObjectNextCompositionObjectGenerationCriteria>().SetGameManager(this);
            
        }

    }
}
