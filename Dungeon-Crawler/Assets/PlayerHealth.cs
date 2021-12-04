using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
     private float _totalHealth;
    private void Start() {
        _totalHealth = GetComponentInParent<PlayerStats>().PlayerHealth;
    }
    public Image HealthBar;
    void Update()
    {
        HealthBar.fillAmount =  GetComponentInParent<PlayerStats>().PlayerHealth/_totalHealth;
    }
}
