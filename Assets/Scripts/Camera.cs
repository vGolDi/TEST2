using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Transform target; 
    [SerializeField]
    float rotationSpeed;

    private float _horizontalInput;
    private bool _isRotating; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _isRotating = true;
            _horizontalInput = -1f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _isRotating = true;
            _horizontalInput = 1f; 
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _isRotating = false;
        }
    }

    void LateUpdate()
    {
        if (_isRotating)
        {
            transform.RotateAround(target.position, Vector3.up, _horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}
