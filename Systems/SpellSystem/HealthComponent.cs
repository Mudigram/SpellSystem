using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] public float maxHealth = 50f;
    private float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;

        Debug.Log(currentHealth);

        if (currentHealth <= 0) Destroy(this.gameObject);
    }

}
