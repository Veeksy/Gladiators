using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private int skillNumber;

    [SerializeField]
    private Animator animator;

    PlayerData playerData;
    private Vector2 direction;

    public Transform _attack;
    private void Start()
    {
        playerData = PlayerData.getInstance();
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (skillNumber)
            {
                case 1:
                    Roll();
                    break;
                case 2:
                    EnchantedAttackSkill();
                    break;
                case 3:
                    SpeedUp();
                    break;
                default:
                    break;
            }
            
        }

        if (playerData.GetManaPoint() < playerData.GetMaxManaPoint())
            playerData.SetManaPoint(playerData.GetManaPoint() + Time.deltaTime * 4f);
    }

    private void Roll()
    {
        if ((direction.x != 0 || direction.y != 0) && playerData.GetManaPoint() >= 20) {
            animator.SetTrigger("Roll");
            playerData.SetBonusSpeed(1.45f);
            playerData.SetManaPoint(playerData.GetManaPoint() - 20);
            Invoke("ReturnSpeed", 0.5f);
        }
    }
    private void ReturnSpeed()
    {
        playerData.SetBonusSpeed(1);
    }

    private void EnhancedAttack()
    {
        PlayerAttack.Action(_attack.position, 2, 3, playerData.GetDamage()+8, true);
    }

    private void EnchantedAttackSkill()
    {
        if (playerData.GetManaPoint() >= 20)
        {
            playerData.SetManaPoint(playerData.GetManaPoint() - 20);
            animator.SetTrigger("AttackS");
            Invoke("EnhancedAttack", 0.5f);
        }
    }

    private void SpeedUp()
    {
        if (playerData.GetManaPoint() >= 100)
        {
            animator.SetTrigger("SpeedUP");
            playerData.SetManaPoint(playerData.GetManaPoint() - 50);
            playerData.SetBonusSpeed(1.5f);
            Invoke("ReturnSpeed", 2f);
        }
    }
}
