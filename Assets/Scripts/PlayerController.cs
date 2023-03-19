using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _commands;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _commands = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMovement = transform.up * -_commands.x;
        Vector3 verticalMovement = transform.right * _commands.y;

        _rb.velocity = (horizontalMovement + verticalMovement) * _speed;
    }
}
