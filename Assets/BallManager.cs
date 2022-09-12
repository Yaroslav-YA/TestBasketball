using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    #region Values
    public Rigidbody2D ball;            //value that contains Ball Rigidbody

    bool is_drag = false;               //value that used for know is the ball drag

    Vector2 start;                      //position of ball at moment when ball drag
    Vector2 end;                        //position of touch at moment when ball drag

    public int power_multiplier = 100;  //strength multiplier of ball push
    public int basket_count = 0;
    
    public static bool is_in_basket;
    //FixedJoint2D ball_fixed_joint;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        /*ball_fixed_joint = gameObject.GetComponent<FixedJoint2D>();
        ball_fixed_joint.enabled = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    //check is start drag
        {
            is_drag = true;
            start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0)&&is_drag)      //check is releaze ball
        {
            //start = ball.transform.position;
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Push();
            //is_drag = false;
        }

        /*if (is_drag)                        //check is the drag now
        {
            //start = ball.transform.position;
            //end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }*/
    }
    /// <summary>
    /// Push the ball
    /// </summary>
    void Push()
    {
        end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ball.simulated = true;
        //ball.isKinematic=false;
        //ball_fixed_joint.connectedBody = null;
        //ball_fixed_joint.enabled = false;
        //transform.DetachChildren();
        //transform.parent = null;
        //ball.WakeUp();
        ball.AddForce((end - start) * -power_multiplier);
        is_drag = false;
        //is_in_basket = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!is_in_basket)
        {
            Debug.Log("collision" + collision.name);
            //ball_fixed_joint.enabled = true;

            ball.transform.position = collision.transform.position;
            ball.simulated = false;
            //ball.MovePosition(collision.gameObject.transform.position);
            //ball.isKinematic=true;
            is_in_basket = true;
            CatchBall temp_catch = collision.gameObject.GetComponent<CatchBall>();
            if (!temp_catch.is_counted)
            {
                basket_count++;
                //temp_catch.is_counted = true;
                temp_catch.Catch();
                GameplayUI.instance.ChangeBasketScore(basket_count);
            }
            //transform.parent=collision.gameObject.transform.parent;
            //collision.gameObject.transform.parent = transform;

        }
        else {
            Debug.Log("collision2" + collision.name);
            is_in_basket = false;
        }
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit " + collision);
        ////is_in_basket = false;
    }*/
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        is_in_basket = true;
    }*/
}
