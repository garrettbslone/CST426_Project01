using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public GameObject customer;
    private bool isSpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawned == false)
        {
            Instantiate(customer, this.transform.position, this.transform.rotation);
            isSpawned = true;
        }
        
    }
}
