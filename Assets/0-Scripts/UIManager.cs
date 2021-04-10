using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    private void Awake() {
        instance = this;
    }
    

    public PlayerEvents playerEvents;
    public TextMeshProUGUI scoreTMP;
    public Image progressbar;

    public void SetScore(int aScore) {
        scoreTMP.text = aScore.ToString();
    }

    public void IncreaseScore() {
        scoreTMP.text = (playerEvents.score + playerEvents.scoreIncrementAmount).ToString();
    }

    public void SetProgress(float rate) {
        progressbar.fillAmount = rate;
    }
    
}
