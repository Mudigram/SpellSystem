using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spells : MonoBehaviour
{
    public SpellScriptableObject SpellToCast;

    private SphereCollider myCollider;
    private Rigidbody myRigidbody;

    void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = SpellToCast.SpellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        Destroy(this.gameObject, SpellToCast.Lifetime);
    }


    private void Update()
    {
       if (SpellToCast.Speed > 0) transform.Translate(Vector3.forward * SpellToCast.Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(SpellToCast.DamageAmount);
        }
        Destroy(this.gameObject);
    }

     public void Activate()
    {
        // Implement the activation logic for this spell (e.g., enable visual effects).
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        // Implement the deactivation logic for this spell (e.g., disable visual effects).
        gameObject.SetActive(false);
    }
}
