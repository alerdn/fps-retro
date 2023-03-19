using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _mouseSensibilty;

    private Rigidbody2D _rigidBody;
    private Vector2 _playerMovement;
    private Vector2 _mouseMovement;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleCamera();
    }

    private void HandleMovement()
    {
        _playerMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontalMovement = transform.up * -_playerMovement.x;
        Vector3 verticalMovement = transform.right * _playerMovement.y;

        _rigidBody.velocity = (horizontalMovement + verticalMovement) * _moveSpeed;
    }

    private void HandleCamera()
    {
        _mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * _mouseSensibilty;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - _mouseMovement.x);
    }
}
