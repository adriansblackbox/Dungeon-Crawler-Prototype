using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float PlayerHealth = 100f;
    public float PlayerDamage = 20f;
    private void Update() {
        if(PlayerHealth <= 0.0f){
            // game over code here
            Destroy(this.gameObject);
        }
    }

}
