using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody phy;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float playerSpeed;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public float skew;

    float fireTime = 0;
    public float fireTimeInterval;

    public GameObject bullet;
    public Transform bulletExitPosition;

    AudioSource audio;

    void Start()
    {
        phy = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireTime)
        {
            fireTime = Time.time + fireTimeInterval;
            Instantiate(bullet, bulletExitPosition.position, Quaternion.identity);
            audio.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal, 0, vertical);
        phy.velocity = vec*playerSpeed;
        phy.position = new Vector3
            (
                Mathf.Clamp(phy.position.x, minX, maxX),
                0.0f,
                Mathf.Clamp(phy.position.z, minZ, maxZ)
            );
        phy.rotation = Quaternion.Euler(0, 0, phy.velocity.x * -skew);
    }
}
