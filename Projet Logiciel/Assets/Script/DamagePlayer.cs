using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] int damageToDeal = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && GameManager.instance.CanFight)
        {
            other.GetComponent<PlayerHealth>().DamagePlayer(damageToDeal);
        }
    }
}
