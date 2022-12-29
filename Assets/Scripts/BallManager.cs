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
    //public int basket_count = 0;        //basket score
    
    public static bool is_in_basket;
    
    Transform current_basket;

    bool is_reset = false;

    string roof_tag = "roof";
    //FixedJoint2D ball_fixed_joint;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        LoopManager.instance.AddResetObject(this.transform);
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
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Push();
        }

        if (is_drag)                        //check is the drag now
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target = -target + current_basket.position;
            RotateBasket(current_basket.up,target);
        }
    }
    private void FixedUpdate()
    {
       
    }
    /// <summary>
    /// Push the ball
    /// </summary>
    void Push()
    {
        end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ball.simulated = true;
        ball.AddForce((end - start) * -power_multiplier);
        is_drag = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == roof_tag)
        {
            is_reset = true;
            return;
        }
        if (!is_in_basket)
        {
            //Debug.Log("collision" + collision.name);
            ball.transform.position = collision.transform.position;
            ball.simulated = false;
            is_in_basket = true;
            current_basket = collision.gameObject.transform.parent.transform;
            CatchBall temp_catch = collision.gameObject.GetComponent<CatchBall>();
            if (is_reset)
            {
                is_reset = false;
                LoopManager.instance.ResetPosition();
            }
            if (!temp_catch.is_counted)
            {
                //basket_count++;
                temp_catch.Catch();
                //GameplayUI.instance.ChangeBasketScore(basket_count);
                GameplayUI.instance.IncreaseBasketScore();
                LevelManager.instance.GenerateUpLevel();
            }
        }
        else {
            Debug.Log("collision2" + collision.name);
            is_in_basket = false;
        }
    }

    void RotateBasket(Vector3 start,Vector3 end) 
    {
        start.z = end.z = 0;
        Quaternion rotation = new Quaternion();
        rotation = Quaternion.FromToRotation(start,end);
        current_basket.rotation*=rotation;
    }
    float Angle(Vector2 start,Vector2 end)
    {
        return end.x - start.x;
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
