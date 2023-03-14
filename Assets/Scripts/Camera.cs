using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Transform target; // obiekt, wokó³ którego bêdzie obracaæ siê kamera
    [SerializeField]
    float rotationSpeed; // prêdkoœæ obrotu kamery

    private float _horizontalInput; // wejœcie z osi X
    private bool _isRotating; // czy kamera jest obecnie w ruchu

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
