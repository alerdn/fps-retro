using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   private Camera _camera;

    void Start()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = _camera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                Debug.Log($"Looking at {raycastHit.transform.name}");
            } else
            {
                Debug.Log("Looking at nothing");
            }
        }
    }
}
