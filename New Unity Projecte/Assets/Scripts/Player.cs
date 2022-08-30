using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject projectile;
    
    private Rigidbody2D _rigidbody;
    private bool _onGround = true;

    [SerializeField] private float _flightSpeed = 3f;

    [SerializeField] private float _movementSpeed = 3f;

    [SerializeField] private float _barrageSpeed = .07f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement keys
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(new Vector2(0f,_flightSpeed));
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(new Vector2(_movementSpeed,0f));
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        
        
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(new Vector2(-_movementSpeed,0f));
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        
        // shoot key
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 4; i++)
            {
                StartCoroutine("ProjectileBarrage");
            }
        }
    }

    // sends barrage of 4 projectiles with .2 second intervals between
    private IEnumerator ProjectileBarrage()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(.2f);
            // Instantiate a projectile into the world at ______ position
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
    
    
}
