using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : MonoBehaviour
{
    [SerializeField]
    private int skillNumber;

    [SerializeField]
    private GameObject spawnEnemy;
    
    [SerializeField]
    private int countMinions;

    private float _startTimespawn;
    private float _timespawn;

    private void Start()
    {
        _startTimespawn = 10;
    }

    void Update()
    {
        if (_timespawn >= _startTimespawn) {
            Instantiate(spawnEnemy);
            _timespawn = 0;
        }

        _timespawn += Time.deltaTime;
    }

}
