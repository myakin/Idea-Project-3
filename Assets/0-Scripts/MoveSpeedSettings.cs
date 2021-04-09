using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeedSettings000000", menuName = "ScriptableObjects/Move Speed Settings", order = 1)]
public class MoveSpeedSettings : ScriptableObject {
    public float speed;

    public void IncreaseSpeed() {
        speed += 0.5f;
    }



}
