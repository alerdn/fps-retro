using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _currentAmmo;

    private Camera _camera;

    void Start()
    {
        _camera = GetComponentInChildren<Camera>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_currentAmmo > 0)
            {
                Ray ray = _camera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    Debug.Log($"Looking at {raycastHit.transform.name}");
                }
                else
                {
                    Debug.Log("Looking at nothing");
                }

                _currentAmmo--;
            }
        }
    }
}
