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
    }

    // Update is called once per frame
    private void Update()
    {
        Transform projectile = GameObject.FindWithTag("Projectile").transform;
        gameObject.transform.position += new Vector3(projectile.position.x, projectile.position.y, 0) * _projectileSpeed * Time.deltaTime;
    }
}
 