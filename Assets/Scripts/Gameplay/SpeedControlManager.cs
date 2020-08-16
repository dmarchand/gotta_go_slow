using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControlManager : MonoBehaviour
{
    public float BaseGameSpeed;
    public float BaseCollisionSpeedReduction;

    [HideInInspector]
    public float CurrentGameSpeed;
    [HideInInspector]
    public float CurrentCollisionSpeedReduction;

    public float ComputedGameSpeed {
        get {
            return Mathf.Max(DifficultyManager.CurrentLevel.MinimumGameSpeed, CurrentGameSpeed);
        }
    }

    private DifficultyManager DifficultyManager;

    private void Awake() {
        DifficultyManager = GetComponent<DifficultyManager>();

        if(DifficultyManager == null) {
            throw new MissingComponentException("No DifficultyManager found");
        }
    }
}
