using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public GameObject customer;

    GameObject activeCustomer;
    public bool isSpawned = false;
    public DialogueManager dial;

    public static CustomerSpawn Instance {get; private set;}


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawned == false)
        {
            activeCustomer = Instantiate(customer, this.transform.position, this.transform.rotation);
            isSpawned = true;
            dial.endDialogue = false;
            dial.orderText.text = "Hello! I would like one burger please with: ";
            dial.buttonText.text = "Next >>";
        }
        
    }

    public void Respawn()
    {
        Destroy(activeCustomer);
        isSpawned = false;
    }
}
