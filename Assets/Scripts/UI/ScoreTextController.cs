using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
    private PlayerStatsManager PlayerStatsManager;
    private Text CurrentText;

    private void Awake() {
        PlayerStatsManager = GameObject.Find("GameStateManager").GetComponent<PlayerStatsManager>();

        if (PlayerStatsManager == null) {
            throw new MissingComponentException("Can't find PlayerStatsManager!");
        }

        CurrentText = GetComponent<Text>();

        if (CurrentText == null) {
            throw new MissingComponentException("Can't find CurrentText!");
        }
    }

    void Update() {
        CurrentText.text = "Score: " + PlayerStatsManager.Score;
    }
}
