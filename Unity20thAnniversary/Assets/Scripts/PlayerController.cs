using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance => _instance;

    private Rigidbody2D _rb2D;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }

        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }
    
    private void Move(float moveDirection)
    {
        Vector2 movementVector = _rb2D.velocity;
        movementVector.x = moveDirection;

        _rb2D.velocity = movementVector;
    }
}
