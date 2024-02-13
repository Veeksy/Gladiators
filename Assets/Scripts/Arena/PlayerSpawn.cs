using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    List<GameObject> characters = new List<GameObject>();

    private void Awake()
    {
        Instantiate(characters[2]);
    }
}
