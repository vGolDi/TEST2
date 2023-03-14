using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{

    [SerializeField]
    bool onShadow = false;

    [SerializeField]
    float damageOverTime;
    
    void FixedUpdate()
    {
        if (onShadow == false)
        {
            SetInLight();
        }
        if(onShadow == true)
        {
            SetInShadow();
        }
    }

    public void SetInShadow()
    {
        onShadow = true;
        //Debug.Log("cie�");
    }
    public void SetInLight()
    {
        onShadow = false;
        //Debug.Log("swiat�o");
        GetComponent<PlayerLife>().PlayerTakeDamage(damageOverTime);
    }
}
