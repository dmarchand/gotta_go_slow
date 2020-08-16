using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public List<DifficultyLevelConfiguration> Difficulties;

    public DifficultyLevelConfiguration CurrentLevel {
        get {
            return Difficulties[GameStateManager.CurrentStage - 1];
        }
    }

    private GameStateManager GameStateManager;

    private void Awake() {
        GameStateManager = GetComponent<GameStateManager>();

        if(GameStateManager == null) {
            throw new MissingComponentException("No GameState Manager found!");
        }
    }

    [System.Serializable]
    public class DifficultyLevelConfiguration {
        public float SpawnTimeMinimum;
        public float SpawnTimeMaximum;
        public float BaseGameSpeed;
        public float MinimumGameSpeed;
        public float CollisionSpeedMultiplier;

        public List<EnemyProbability> SpawnableItems;
    }

    [System.Serializable]
    public class EnemyProbability {
        public int Probability;
        public GameObject Enemy;
    }
}
