using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmeraldAI;


public class DamageCollider : MonoBehaviour
{
    BoxCollider damageCollider;

    int currentWeaponDamage = 40;

    private void Awake()
    {
        damageCollider = GetComponent<BoxCollider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.name);
        if (other.tag == "Player")
        {
            PlayerStats pStats = other.GetComponent<PlayerStats>();

            if (pStats != null)
            {
                pStats.TakeDamage(currentWeaponDamage);
            }
        }

        if (other.tag == "Enemy")
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();

            if (enemyStats != null)
            {
                enemyStats.TakeDamage(currentWeaponDamage);
            }
        }

        if (other.CompareTag("AI"))
        {
            Debug.Log("Hit enemy");
            EmeraldAI.EmeraldAISystem eai = other.GetComponent<EmeraldAI.EmeraldAISystem>();
            if (eai != null)
            {
                eai.Damage(20, EmeraldAI.EmeraldAISystem.TargetType.Player, transform.root, 100);
            }
        }
    }
}