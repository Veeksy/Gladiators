using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    List<GameObject> characters = new List<GameObject>();
    PlayerData playerData;
    private void Awake()
    {
        playerData = PlayerData.getInstance();
        Instantiate(characters[playerData.GetSelectedPlayer()]);   
    }
}
