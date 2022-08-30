using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volleyball : MonoBehaviour
{
    [SerializeField] private float _hitStrength = 300f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            // get the direction the projectile was moving
            Vector3 direction = (gameObject.transform.position - other.gameObject.transform.position).normalized;
            // apply a certain force to the rb of the target
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * _hitStrength);
            // destroy the projectile that hit the target
            Destroy(other.gameObject);
        }
    }
}
