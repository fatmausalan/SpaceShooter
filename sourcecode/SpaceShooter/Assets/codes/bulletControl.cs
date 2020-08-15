using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    Rigidbody phy;
    public float speed;
    void Start()
    {
        phy = GetComponent<Rigidbody>();
        phy.velocity = transform.forward*speed;

    }

    
}
