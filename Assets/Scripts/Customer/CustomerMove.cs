using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    float speed = 5.0f;
    public static string[] my_order;

    public static bool isStopped;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        my_order = CustomerOrder.OrderMaker(GamePlayManager.Instance.GetScore());
        CheckOrderManager.Instance.SetExpected(my_order);
        isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.position.z < GameObject.Find("customer waypoint").transform.position.z)
        {
            speed = 0.0f;
            isStopped = true;
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            isStopped = false;
        }
        


    }
}
