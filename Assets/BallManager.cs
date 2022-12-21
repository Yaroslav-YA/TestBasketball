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
    Transform current_basket;
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

        if (is_drag)                        //check is the drag now
        {
            //start = ball.transform.position;
            //end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //RotateBasket(start, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.z = ball.transform.position.z;
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(start.x,start.y,0);
            //target.z = current_basket.position.z;
            //current_basket.LookAt(target);
            //current_basket.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //current_basket.right = target-current_basket.position;
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.z = 0;
            /*current_basket.LookAt(target);
            Quaternion temp_rotation= Quaternion.FromToRotation(current_basket.position, current_basket.up);
            temp_rotation.eulerAngles=new Vector3 (0,0,temp_rotation.eulerAngles.z);
            current_basket.rotation *= temp_rotation;*/
            /*Debug.Log("current for " + current_basket.right + " angle " + Vector3.Angle(current_basket.right, Camera.main.ScreenToWorldPoint(Input.mousePosition)));
            current_basket.Rotate(Vector3.forward, Vector3.Angle(current_basket.up, Camera.main.ScreenToWorldPoint(Input.mousePosition)));*/
            target = -target + current_basket.position;
            ////target.z = current_basket.position.z;
            RotateBasket(current_basket.up,target);
        }
    }
    private void FixedUpdate()
    {
        /*if (is_in_basket)
        {
            current_basket.rotation = ball.transform.rotation;
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
            current_basket = collision.gameObject.transform.parent.transform;
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

    void RotateBasket(Vector3 start,Vector3 end) 
    {
        start.z = end.z = 0;
        Quaternion rotation = new Quaternion();
        rotation = Quaternion.FromToRotation(start,end);
        //rotation.eulerAngles=new Vector3((end - start).x, (end - start).y, 0);
        //rotation.eulerAngles = new Vector3(0, 0, 0);
        //Debug.Log("rotation " + rotation.eulerAngles + " vector " + (end - start));
        Debug.Log("rotation" + rotation.eulerAngles);
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
