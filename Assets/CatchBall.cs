using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision"+collision.name);
        collision.gameObject.transform.position = transform.position;
        collision.attachedRigidbody.simulated = false;
        gameObject.GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
    }

    public void ReleaseBall()
    {
        gameObject.GetComponent<FixedJoint2D>().connectedBody = null;
    }*/
}
