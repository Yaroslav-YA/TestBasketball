using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CatchBall : MonoBehaviour
{
    public bool is_counted=false;
    public SpriteShapeRenderer shape_renderer;
    Color count_color=new Color(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Catch()
    {
        is_counted = true;
        shape_renderer.color = count_color;
        //GameplayUI.instance.IncreaseBasketScore();
        //LevelManager.instance.DeleteBasket(this.gameObject.GetComponentInParent<Transform>());
        //LevelManager.instance.GenerateUpLevel();
    }

    private void OnBecameInvisible()
    {
        LevelManager.instance.DeleteBasket(this.gameObject.GetComponentInParent<Transform>());
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
