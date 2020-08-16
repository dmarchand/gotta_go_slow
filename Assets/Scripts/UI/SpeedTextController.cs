using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTextController : MonoBehaviour
{
    private SpeedControlManager SpeedControlManager;
    private Text CurrentText;

    private void Awake() {
        SpeedControlManager = GameObject.Find("GameStateManager").GetComponent<SpeedControlManager>();

        if(SpeedControlManager == null) {
            throw new MissingComponentException("Can't find SpeedControlManager!");
        }

        CurrentText = GetComponent<Text>();

        if (CurrentText == null) {
            throw new MissingComponentException("Can't find CurrentText!");
        }
    }

    void Update() {
        CurrentText.text = "Speed: " + SpeedControlManager.CurrentGameSpeed;
    }
}
