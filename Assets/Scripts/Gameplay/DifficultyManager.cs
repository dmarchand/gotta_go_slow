using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public List<DifficultyLevelConfiguration> Difficulties;

    [System.Serializable]
    public class DifficultyLevelConfiguration {
        public float SpawnTimeMinimum;
        public float SpawnTimeMaximum;
        public float BaseGameSpeed;
        public float CollisionSpeedMultiplier;
        public Dictionary<GameObject, int> SpawnableItems;
    }
}
