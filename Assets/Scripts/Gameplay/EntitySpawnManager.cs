﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EntitySpawnManager : MonoBehaviour
{
    public float YSpawn;
    public float XSpawnMin, XSpawnMax;

    private DifficultyManager DifficultyManager;
    private GameStateManager GameStateManager;

    private int currentLevel;

    private void Awake() {
        DifficultyManager = GetComponent<DifficultyManager>();

        if(DifficultyManager == null) {
            throw new MissingComponentException("No DifficultyManager found");
        }

        GameStateManager = GetComponent<GameStateManager>();

        if(GameStateManager == null) {
            throw new MissingComponentException("No GameStateManager found!");
        }
    }

    public void StartLevel() {
        currentLevel = GameStateManager.CurrentStage;

        StopAllCoroutines();
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        var currentDifficultyConfiguration = DifficultyManager.CurrentLevel;

        float spawnTimeMinimum = currentDifficultyConfiguration.SpawnTimeMinimum;
        float spawnTimeMaximum = currentDifficultyConfiguration.SpawnTimeMaximum;

        float spawnTime = Random.Range(spawnTimeMinimum, spawnTimeMaximum);

        yield return new WaitForSeconds(spawnTime);

        var enemyToSpawn = SelectEnemy(currentDifficultyConfiguration);
        float xSpawn = Random.Range(XSpawnMin, XSpawnMax);

        Instantiate(enemyToSpawn, new Vector3(xSpawn, YSpawn), Quaternion.identity);

        StartCoroutine(SpawnEnemy());
    }

    private GameObject SelectEnemy(DifficultyManager.DifficultyLevelConfiguration difficultyConfiguration) {
        float total = 0;
        float diceRoll = Random.Range(0, 100);

        for(int i = 0; i < difficultyConfiguration.SpawnableItems.Count; i++) {
            total += difficultyConfiguration.SpawnableItems[i].Probability;

            if(diceRoll < total) {
                return difficultyConfiguration.SpawnableItems[i].Enemy;
            }
        }

        throw new System.Exception("Probabilities of enemies did not add up to 100");
    }
}
