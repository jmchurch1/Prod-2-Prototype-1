using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _onGround = true;

    [SerializeField] private float _flightSpeed = 10f;

    [SerializeField] private float _gravitySpeed = 5f;

    [SerializeField] private float _movementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, Time.deltaTime * _flightSpeed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(Time.deltaTime * _movementSpeed,0, 0);
        }
        
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(Time.deltaTime * _movementSpeed,0, 0);
        }
        
        if (!_onGround)
            transform.position -= new Vector3(0, Time.deltaTime * _gravitySpeed, 0);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Border"))
            _onGround = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Border"))
            _onGround = false;
    }
}
