using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public SpeedControlManager SpeedControlManager;
    public PlayerStatsManager PlayerStatsManager;
    public DifficultyManager DifficultyManager;
    public EntitySpawnManager EntitySpawnManager;
    public DifficultyRampUpManager DifficultyRampUpManager;

    [HideInInspector]
    public int CurrentStage = 1;

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

        if(EntitySpawnManager == null) {
            throw new MissingComponentException("No EntitySpawnManager assigned!");
        }

        if (DifficultyRampUpManager == null) {
            throw new MissingComponentException("No DifficultyRampUpManager assigned!");
        }
    }

    private void Start() {
        StartNewGame(); // Temporary
    }

    public void StartNewGame() {
        CurrentStage = 1;

        var firstLevel = DifficultyManager.Difficulties[CurrentStage - 1];
        SpeedControlManager.CurrentGameSpeed = firstLevel.BaseGameSpeed;
        SpeedControlManager.CurrentCollisionSpeedReduction = firstLevel.CollisionSpeedMultiplier;

        EntitySpawnManager.StartLevel();
        DifficultyRampUpManager.StartLevel();       
    }
}
