using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _projectileSpeed = 1f;
    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine("DeathTimer");
    }

    // Update is called once per frame
    private void Update()
    {
        Transform projectile = GameObject.FindWithTag("Projectile").transform;
        Vector3 direction = (transform.position - projectile.position).normalized;
        gameObject.transform.position -= direction * _projectileSpeed * Time.deltaTime;
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
 