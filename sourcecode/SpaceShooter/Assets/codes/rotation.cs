using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    Rigidbody phy;
    public float speed;
    void Start()
    {
        phy = GetComponent<Rigidbody>();
        phy.angularVelocity = Random.insideUnitSphere*speed;
    }

     
}