using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject volleyball;
    
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _projectileSpeed = 1f;
    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.position += volleyball.transform.position * _projectileSpeed * Time.deltaTime;
    }
}
