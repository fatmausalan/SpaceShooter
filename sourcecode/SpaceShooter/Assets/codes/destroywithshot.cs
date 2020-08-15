using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroywithshot : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    GameObject gameControl;
    gameControl control;
    private void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("gameControl");
        control = gameControl.GetComponent<gameControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "myboundary" )
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            control.scoreIncrease(10);
        }
        if(other.gameObject.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            control.gameOver();
        }
        
    }
}
