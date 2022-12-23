using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position=new Vector3(transform.position.x,Mathf.Lerp( transform.position.y,target.transform.position.y,Time.deltaTime),transform.position.z);
    }
}
