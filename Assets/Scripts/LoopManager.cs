using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    List<Transform> reset_object = new List<Transform>();
    public static LoopManager instance;
    float step_distance=5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResetObject(Transform object_transform)
    {
        reset_object.Add(object_transform);
    }

    public void ResetPosition()
    {
        for(int i = 0; i < reset_object.Count; i++)
        {
            reset_object[i].position -= new Vector3(0, step_distance);
        }
    }
}