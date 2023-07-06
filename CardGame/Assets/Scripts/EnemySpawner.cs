using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public StageData[] stages;
    private int currentStageIndex = 0;
    private SpawnModifier spawnModifier;

    private void Start()
    {
        spawnModifier = GenerateSpawnModifier();
        StartNextStage();
    }

    private SpawnModifier GenerateSpawnModifier()
    {
        SpawnModifier modifier = new SpawnModifier();

        // Customize the spawn modifier values based on your desired randomness
        modifier.spawnRate = Random.Range(0.8f, 1.2f);
        modifier.enhanceEnemy = Random.Range(0.8f, 1.2f);
        modifier.randomEvents = Random.Range(0.8f, 1.2f);

        return modifier;
    }

    private void StartNextStage()
    {
        if (currentStageIndex >= stages.Length)
        {
            // All stages completed
            return;
        }

        StageData currentStage = stages[currentStageIndex];
        StartCoroutine(SpawnEnemies(currentStage));

        currentStageIndex++;
    }

    private IEnumerator SpawnEnemies(StageData stage)
    {
        var list = GridManagerPlus.instance.PickRandomFirstRowElement(2);

        foreach (GameObject smt in list)
        {
            var offset = GridManagerPlus.instance.offset;
            var random = Random.Range(0, stages[currentStageIndex].enemiesToSpawn.Length);
            var enemy = Instantiate(stages[currentStageIndex].enemiesToSpawn[random], smt.transform.position + offset, stages[currentStageIndex].enemiesToSpawn[random].transform.rotation);
            var grid = smt.GetComponent<Grid>();
            grid.thingHold = enemy;
            grid.UpdateGrid();
        }
        /*
        for (int i = 0; i < stage.enemiesToSpawn.Length; i++)
        {
            GameObject enemyPrefab = stage.enemiesToSpawn[i];
            Vector3 spawnPosition = stage.spawnPositions[i];

            // Apply spawn modifier values to the enemy's properties
            Enemy enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity).GetComponent<Enemy>();
            enemy.spawnRate *= spawnModifier.spawnRate;
            enemy.enhanceValue *= spawnModifier.enhanceEnemy;
            enemy.randomEvents *= spawnModifier.randomEvents;

            yield return new WaitForSeconds(stage.spawnDelay / spawnModifier.spawnRate);
        }

        */
        // Start the next stage after all enemies are spawned
        StartNextStage();
    }
}

