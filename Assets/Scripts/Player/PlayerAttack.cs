using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float attackRange;

    public Transform _attack;

    private float attackRate = 2f;
    private float nextAttackTime = 0f;

    static GameObject NearTarget(Vector3 position, Collider2D[] array)
    {
        Collider2D current = null;
        float dist = Mathf.Infinity;

        foreach (Collider2D coll in array)
        {
            float curDist = Vector3.Distance(position, coll.transform.position);

            if (curDist < dist)
            {
                current = coll;
                dist = curDist;
            }
        }

        return (current != null) ? current.gameObject : null;
    }
    public void Action(Vector2 point, float radius, int layerMask, float damage, bool allTargets)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);
        
        
        if (!allTargets)
        {
            GameObject obj = NearTarget(point, colliders);
            
            var component_enemyData = obj.GetComponent<EnemyController>();

            if (obj != null && component_enemyData)
            {
                component_enemyData.TakeDamage((int)damage);
            }
            return;
        }

        foreach (Collider2D hit in colliders)
        {
            var component_enemyData = hit.GetComponent<EnemyController>();

            if (component_enemyData)
            {
                component_enemyData.TakeDamage((int)damage);
            }
        }
    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else
            {
                _animator.ResetTrigger("Attack");
            }
        }

        
    }

    public void onAttack()
    {

        Action(_attack.position, attackRange, 3, 20, true);
    }


}
