using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float Health = 80f;
    public float Damage = 15f;
    private Rigidbody EnemyRB;
    public Transform PlayerTransform;
    public float KnockBackForce = 10f;
    public float KnockBackTime = 0.25f;
    private bool enemyStable = true;

    private void Start() {
        EnemyRB = GetComponent<Rigidbody>();
    }
    private void Update() {
        if(Health <= 0.0f){
            Death();
        }
    }
    private void Death(){
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Weapon")){
            Health -= FindObjectOfType<PlayerStats>().PlayerDamage;
        }
        if(other.gameObject.CompareTag("Weapon") && FindObjectOfType<PlayerController>().melee){
            enemyStable = false;
            StartCoroutine("KnockBack");
        }
    }
    private IEnumerator KnockBack(){
        if(!enemyStable){
            EnemyRB.velocity = PlayerTransform.forward*KnockBackForce;
            yield return new WaitForSeconds(KnockBackTime);
            EnemyRB.velocity = Vector3.zero;
            enemyStable = true;
        }

    }
}
