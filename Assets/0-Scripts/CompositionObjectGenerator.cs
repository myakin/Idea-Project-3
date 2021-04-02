using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdeaProject3 {
    public class CompositionObjectGenerator : MonoBehaviour {
        public Transform genrationPointDummy;

        public void PositionCompositionObject(Vector3 aPosition) {
            genrationPointDummy.SetParent(null);
            transform.SetParent(genrationPointDummy);

            genrationPointDummy.position = aPosition;

            transform.SetParent(null);
            genrationPointDummy.SetParent(transform);
        }
    }
}

