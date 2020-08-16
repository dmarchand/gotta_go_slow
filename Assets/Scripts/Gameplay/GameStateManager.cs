using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public SpeedControlManager SpeedControlManager;
    public PlayerStatsManager PlayerStatsManager;
    public DifficultyManager DifficultyManager;

    private void Awake() {
        if(SpeedControlManager == null) {
            throw new MissingComponentException("No SpeedControlManager assigned!");
        }

        if(PlayerStatsManager == null) {
            throw new MissingComponentException("No PlayerStatsManager assigned!");
        }

        if(DifficultyManager == null) {
            throw new MissingComponentException("No DifficultyManager assigned!");
        }
    }

    private void Start() {
        StartNewGame(); // Temporary
    }

    public void StartNewGame() {
        var firstLevel = DifficultyManager.Difficulties[0];
        SpeedControlManager.CurrentGameSpeed = firstLevel.BaseGameSpeed;
        SpeedControlManager.CurrentCollisionSpeedReduction = firstLevel.CollisionSpeedMultiplier;
    }
}
