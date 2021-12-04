using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) FindObjectOfType<PlayerStats>().PlayerHealth -= other.gameObject.GetComponentInParent<EnemyStats>().Damage;
    }
}
