using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Volleyball : MonoBehaviour
{
    [SerializeField] private float _hitStrength = 300f;

    [SerializeField] private float _maxSpeed = 10f;

    private Rigidbody2D _rigidbody;

    [SerializeField] private float _currMagnitude;
    
    [SerializeField] private Vector2 _currVelocity;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude > _maxSpeed)
        {
            // get the percentage that the current magnitude of velocity is over max speed
            float percentageOver = _maxSpeed / _rigidbody.velocity.magnitude;
            Debug.Log("Velocity before multiplication: " + _rigidbody.velocity);
            // multiply the velocity by percentage over so the velocity is _maxSpeed
            _rigidbody.velocity *= percentageOver;
            Debug.Log("Velocity after multiplication: " + _rigidbody.velocity);
        }
    }

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
