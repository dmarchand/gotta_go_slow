using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyRampUpManager : MonoBehaviour 
{
    private DifficultyManager DifficultyManager;
    private SpeedControlManager SpeedControlManager;
    private bool ReactorMeltingDown;

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
        ReactorMeltingDown = false;
        StopAllCoroutines();
        StartCoroutine(RampDifficulty());
    }

    private void Update() {
        if(ReactorMeltingDown && SpeedControlManager.CurrentGameSpeed <= DifficultyManager.CurrentLevel.MaxSpeedBeforeDeath) {
            StopAllCoroutines();
            StartCoroutine(RampDifficulty());

            ReactorMeltingDown = false;
            Debug.Log("Reactor cooled");
        }
    }

    private IEnumerator RampDifficulty() {
        yield return new WaitForSeconds(DifficultyManager.CurrentLevel.SpeedIncrementDelay);
        SpeedControlManager.CurrentGameSpeed += DifficultyManager.CurrentLevel.SpeedIncrementValue;

        if (SpeedControlManager.CurrentGameSpeed >= DifficultyManager.CurrentLevel.MaxSpeedBeforeDeath) {
            StartCoroutine(StartDeathClock());
        } else {
            StartCoroutine(RampDifficulty());
        }
    }

    private IEnumerator StartDeathClock() {
        ReactorMeltingDown = true;
        yield return new WaitForSeconds(DifficultyManager.CurrentLevel.TimeUntilReactorMeltdown);

        if(ReactorMeltingDown) {
            // Game over!
            Debug.Log("GAME OVER!");
        }
    }
}
