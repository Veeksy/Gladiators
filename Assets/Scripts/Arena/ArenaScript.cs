using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField]
    List<GameObject> Enemies = new List<GameObject>();
    [SerializeField]
    List<GameObject> Bosses = new List<GameObject>();
    [SerializeField]
    TextMeshProUGUI waves;

    private PlayerData playerData;
    private ArenaData arenaData;
    private int currentWave;

    private int bossFight;

    void Start()
    {
        playerData = PlayerData.getInstance();
        arenaData = ArenaData.getInstance();
        arenaData.NextWave();
        NextWave1();
        waves.SetText($"Волна: {arenaData.GetWave()}");
        currentWave = arenaData.GetWave();
    }

    private void Update()
    {
        if (currentWave < arenaData.GetWave()) 
        {
            currentWave = arenaData.GetWave();
            Invoke("NextWave1", 1);
        }
    }

    void NextWave1()
    {
        waves.SetText($"Волна: {arenaData.GetWave()}");
        Invoke("startCor", 4);
    }

    void startCor()
    {
        if (arenaData.GetWave() % 5 == 0)
        {
            bossFight++;
            StartCoroutine(SpawnBoss());
        }
        else
        {
            StartCoroutine(SpawnEnemies());

        }
    }

    IEnumerator SpawnEnemies()
    {
        while (0 < arenaData.GetSpawning())
        {
            Instantiate(Enemies[Random.Range(0, Enemies.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].transform);
            arenaData.SetSpawning(arenaData.GetSpawning()-1);
            yield return new WaitForSeconds(arenaData.GetSpawnDelay()); 
        }
    }

    IEnumerator SpawnBoss()
    {
        while (0 < bossFight)
        {
            Instantiate(Bosses[Random.Range(0, Bosses.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].transform);
            bossFight--;
            yield return new WaitForSeconds(arenaData.GetSpawnDelay());
        }
    }

}
