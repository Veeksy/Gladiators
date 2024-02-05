using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField]
    List<GameObject> Enemies = new List<GameObject>();

    private float spawnDelay = 2.0f;
    private float spawning;

    private PlayerData playerData;

    void Start()
    {
        playerData = PlayerData.getInstance();
        spawning = 5f;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (0 < spawning * playerData.GetPlayerLevel())
        {
            Instantiate(Enemies[0], spawnPoints[Random.Range(0, spawnPoints.Count - 1)].transform); // создание корабля врага
            spawning--;
            yield return new WaitForSeconds(spawnDelay); // задержка между появлениями кораблей
        }
    }
}
