using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyRampUpManager : MonoBehaviour 
{
    private DifficultyManager DifficultyManager;
    private SpeedControlManager SpeedControlManager;

    private void Awake() {
        DifficultyManager = GetComponent<DifficultyManager>();

        if (DifficultyManager == null) {
            throw new MissingComponentException("No DifficultyManager found");
        }

        SpeedControlManager = GetComponent<SpeedControlManager>();

        if (SpeedControlManager == null) {
            throw new MissingComponentException("No SpeedControlManager found");
        }
    }

    public void StartLevel() {

        StopAllCoroutines();
        StartCoroutine(RampDifficulty());
    }

    private IEnumerator RampDifficulty() {
        yield return new WaitForSeconds(DifficultyManager.CurrentLevel.SpeedIncrementDelay);
        SpeedControlManager.CurrentGameSpeed += DifficultyManager.CurrentLevel.SpeedIncrementValue;

        StartCoroutine(RampDifficulty());
    }
}
