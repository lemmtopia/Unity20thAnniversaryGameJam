using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCharacter2D : MonoBehaviour
{
    [SerializeField] private float GravityScale = 1f;
    [SerializeField] private LayerMask _solidLayerMask;
    [SerializeField] private BoxCollider2D _hitbox;

    protected Rigidbody2D _rb2D;
    protected Vector2 _velocity;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        _velocity += GravityScale * Physics2D.gravity * Time.deltaTime;

        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 movementVector = Vector2.up * deltaPosition.y;

        Move(movementVector);
    }

    private void Move(Vector2 movementVector)
    {
        Vector2 newPosition = _rb2D.position;

        Vector2 checkPositionY = _rb2D.position + new Vector2(0, movementVector.y);
        if (IsCollidingAt(checkPositionY, _solidLayerMask))
        {
            Vector2 signedCheckPositionY = _rb2D.position + new Vector2(0, Mathf.Sign(movementVector.y) * Time.deltaTime);
            while (!IsCollidingAt(signedCheckPositionY, _solidLayerMask))
            {
                newPosition.y += Mathf.Sign(movementVector.y) * Time.deltaTime;
            }

            movementVector.y = 0;
        }

        newPosition.y += movementVector.y;

        _rb2D.MovePosition(newPosition);
    }
    
    private bool IsCollidingAt(Vector2 positionToCheck, LayerMask layerMask)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(positionToCheck, _hitbox.size, 0, layerMask);
        return colliders.Length > 0;
    }
}
