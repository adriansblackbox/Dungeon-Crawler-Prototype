using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private float _totalHealth;
    private void Start() {
        _totalHealth = GetComponentInParent<EnemyStats>().Health;
    }
    public Transform CameraRotation;
    public Image HealthBar;
    void Update()
    {
        transform.rotation = CameraRotation.rotation;
        HealthBar.fillAmount =  GetComponentInParent<EnemyStats>().Health/_totalHealth;
    }
}
