using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volleyball : MonoBehaviour
{
    [SerializeField] private float _hitStrength = 10f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Projectile")
        {
            Vector3 direction = (gameObject.transform.position - other.gameObject.transform.position).normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * _hitStrength);
            Destroy(other.gameObject);
        }
    }
}
