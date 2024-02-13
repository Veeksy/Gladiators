using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArenaData
{
    private static ArenaData instance;
    public static ArenaData getInstance()
    {
        if (instance == null)
            instance = new ArenaData();
        return instance;
    }

    private int wave { get; set; }
    private float spawnDelay { get; set; } = 2.0f;
    private int spawning { get; set; }
    private int countEnemy { get; set; }


    public void SetWave(int wave) { this.wave = wave; }
    public void SetCountEnemy(int countEnemy) { this.countEnemy = countEnemy; }
    public void SetSpawning(int spawning) { this.spawning = spawning; }

    public int GetWave() { return wave; }
    public int GetCountEnemy() { return countEnemy; }
    public float GetSpawnDelay() { return spawnDelay; }
    public int GetSpawning() { return spawning; }

    public void NextWave()
    {
        if (wave > 1)
            Wallet.Replenishment(100);
        SetWave(GetWave() + 1);

        if (GetSpawning() <= 12)
        {
            SetSpawning(GetWave() + 3);
            SetCountEnemy(GetSpawning());
        }
        if (GetSpawning() > 12)
        {
            SetSpawning(12);
            SetCountEnemy(GetSpawning());
        }
    }
}
