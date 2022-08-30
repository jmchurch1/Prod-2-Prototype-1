using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _projectileSpeed = 10f;
    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        
        // destroy projectile 4 seconds after spawn
        StartCoroutine("DeathTimer");
    }

    // Update is called once per frame
    private void Update()
    {
        Transform target = GameObject.FindWithTag("Target").transform;
        // get direction of the target
        Vector3 direction = (transform.position - target.position).normalized;
        // move the projectile towards the target
        gameObject.transform.position -= direction * _projectileSpeed * Time.deltaTime;
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
 