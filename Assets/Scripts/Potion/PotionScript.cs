using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    [SerializeField]
    private int m_Index = 0;

    PlayerData m_PlayerData;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        m_PlayerData = PlayerData.getInstance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            effect();
        }
    }

    void effect()
    {
        switch (m_Index)
        {
            case 0:
                m_PlayerData.SetHealthPoint(m_PlayerData.GetMaxHealthPoint());
                break;
            case 1:
                m_PlayerData.SetManaPoint(m_PlayerData.GetMaxManaPoint());
                break;
            default:
                break;
        }
        animator.SetTrigger("take");
    }
    
    void Destroy()
    {
        Destroy(gameObject);
    }
}
