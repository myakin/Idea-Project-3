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

        
        public void LoadMainUI(PlayerEvents aPlayerEventsObject) {
            AddressablesManager.instance.LoadAddressableSceneAdditive(
                "MainUI",
                delegate {
                    // aPlayerEventsObject.ExecuteEventSubscribers();
                    UIManager.instance.SetScore(0);
                }
            );
        }

        public void UnloadMainUI() {
            AddressablesManager.instance.UnloadAddressableScene("MainUI");
        }

        
        public void GenerateSceneCompositionObject() {
            indexToGenerate = Random.Range(0, numberOfCompositionPrefabs[currentLevel]);
            AddressablesManager.instance.SpawnObject("SceneCompositionObject_Level1_Variation"+indexToGenerate, new Vector3 ( 0, -200, 0), Quaternion.identity, null, 
                delegate (GameObject obj)
                {
                    if (!obj.GetComponent<CompositionObjectGenerator>())
                    {
                        obj.AddComponent<CompositionObjectGenerator>();
                        obj.GetComponent<CompositionObjectGenerator>().genrationPointDummy = obj.transform.Find("GenerationPositionDummy");
                    }
                    obj.GetComponent<CompositionObjectGenerator>().PositionCompositionObject(generationPositionDummy.position);

                    if (!obj.GetComponent<CompositionObjectDestroyer>())
                    {
                        obj.AddComponent<CompositionObjectDestroyer>();
                        obj.GetComponent<CompositionObjectDestroyer>().destroyPositionDummy = obj.transform.Find("DestroyPositionDummy");
                    }
                    obj.GetComponent<CompositionObjectDestroyer>().SetDestructionPointX(destructionPositionDummy.position.x);

                    if (!obj.GetComponent<CompositionObjectNextCompositionObjectGenerationCriteria>())
                    {
                        obj.AddComponent<CompositionObjectNextCompositionObjectGenerationCriteria>();
                        obj.GetComponent<CompositionObjectNextCompositionObjectGenerationCriteria>().nextgenerationPositionDummy = obj.transform.Find("NextGenerationDummy");
                    }
                    obj.GetComponent<CompositionObjectNextCompositionObjectGenerationCriteria>().SetGameManager(this);
                }    
            );

            
            
        }

    }
}
