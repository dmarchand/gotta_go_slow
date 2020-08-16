using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxTextController : MonoBehaviour
{
    private DifficultyManager DifficultyManager;
    private Text CurrentText;

    private void Awake() {
        DifficultyManager = GameObject.Find("GameStateManager").GetComponent<DifficultyManager>();

        if (DifficultyManager == null) {
            throw new MissingComponentException("Can't find DifficultyManager!");
        }

        CurrentText = GetComponent<Text>();

        if (CurrentText == null) {
            throw new MissingComponentException("Can't find CurrentText!");
        }
    }

    void Update() {
        CurrentText.text = "MAX: " + DifficultyManager.CurrentLevel.MaxSpeedBeforeDeath;
    }
}
