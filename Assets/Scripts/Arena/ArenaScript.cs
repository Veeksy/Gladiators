using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

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

    [SerializeField]
    List<GameObject> Potions = new List<GameObject>();

    private ArenaData arenaData;

    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TextMeshProUGUI wavesComplete;

    [SerializeField]
    private TextMeshProUGUI coins;

    private int currentWave;
    private float spawnPotionTime;
    private float spawnPotionTimeMax;

    private PlayerData playerData;
    void Start()
    {
        arenaData = ArenaData.getInstance();
        playerData = PlayerData.getInstance();
        arenaData.SetWave(currentWave);
        arenaData.NextWave();
        NextWave1();

        waves.SetText($"Волна: {arenaData.GetWave()}");
        coins.SetText(Wallet.GetBalance().ToString());
        currentWave = arenaData.GetWave();
        spawnPotionTimeMax = 15f;
    }

    private void Update()
    {
        if (playerData.GetHealthPoint() <= 0)
        {
            GameOver();
        }
        else
        {
            if (currentWave < arenaData.GetWave())
            {
                currentWave = arenaData.GetWave();
                Invoke("NextWave1", 1);
            }
            if (spawnPotionTime >= spawnPotionTimeMax)
            {
                Instantiate(Potions[Random.Range(0, Potions.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].transform);
                spawnPotionTime = 0;
            }
            spawnPotionTime += Time.deltaTime;
        }
       
    }

    void NextWave1()
    {
        if (currentWave > 1)
        {
            Wallet.Replenishment(100);
            waves.SetText($"Волна: {arenaData.GetWave()}");
            coins.SetText(Wallet.GetBalance().ToString());
            if (YandexGame.SDKEnabled)
            {
                YandexGame.savesData.coins = Wallet.GetBalance();
                YandexGame.SaveProgress();
            }

        }
        
        Invoke("startCor", 4);
    }

    void startCor()
    {
        if (arenaData.GetWave() % 5 == 0)
        {
            arenaData.SetSpawning(1);
            arenaData.SetCountEnemy(1);
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
            arenaData.SetSpawning(arenaData.GetSpawning() - 1);
            yield return new WaitForSeconds(arenaData.GetSpawnDelay());
        }
    }


    IEnumerator SpawnBoss()
    {
        while (0 < arenaData.GetSpawning())
        {
            Instantiate(Bosses[Random.Range(0, Bosses.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].transform);
            arenaData.SetSpawning(arenaData.GetSpawning() - 1);
            yield return new WaitForSeconds(arenaData.GetSpawnDelay());
        }
    }


    public void GameOver()
    {
        
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        wavesComplete.SetText($"Волн пройдено:{arenaData.GetWave() - 1}");
    }


}
