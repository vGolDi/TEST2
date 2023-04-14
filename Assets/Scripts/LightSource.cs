using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    [SerializeField]
    Transform target; 
    [SerializeField]
    float rotationSpeed; 
    private float _horizontalInput;
    private bool _isRotating; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isRotating = true;
            _horizontalInput = -1f; 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _isRotating = true;
            _horizontalInput = 1f; 
        }
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            _isRotating = false;
        }
    }

    void LateUpdate()
    {
        if (_isRotating)
        {
            transform.RotateAround(Vector3.zero, Vector3.up, _horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}
