using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WalkingDmg : MonoBehaviour
{
    [SerializeField]
    float WalkingDamage;
   
    private Vector3 previousPosition;
    private bool isMoving;

    private void Start()
    {
        previousPosition = transform.position;
        isMoving = false;
    }

    private void FixedUpdate()
    {
        // Check if the player is moving
        if (transform.position != previousPosition)
        {
            isMoving = true;
           // Debug.Log("chodzi");
            GetComponent<PlayerLife>().PlayerTakeDamage(WalkingDamage);
        }
        if(transform.position == previousPosition)
        {
            isMoving = false;
            //Debug.Log("niechodzi");
        }

        // Update the previous position
        previousPosition = transform.position;
    }
}
