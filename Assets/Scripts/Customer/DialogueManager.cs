using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    int i = 0;
    public Text orderText;
    public Text buttonText;

    public Animator animator;

    public Button nextButton;


    public static DialogueManager Instance { get; private set; }

    public CustomerSpawn cust;
    public bool endDialogue;


    void Start()
    {
        Instance = this;
        Button btn = nextButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        endDialogue = false;
    }

    void Update()
    {
        if (CustomerMove.isStopped == true && endDialogue == false)
        {
            StartDialogue();                
        }
    }

    public void StartDialogue()
    {
        orderText.text = "Hello! I would like one burger please with: ";
        animator.SetBool("IsOpen", true);
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    void OnClick()
    {
        if (i < CustomerMove.my_order.Length)
        {
            if(i > 0 && (CustomerMove.my_order[i] == CustomerMove.my_order[i - 1]))
            {
                orderText.text = "another " + CustomerMove.my_order[i];

            }
            else
            {
                orderText.text = CustomerMove.my_order[i];
            }
            i++;


        }
        else if (i == CustomerMove.my_order.Length)
        {
            orderText.text = "...and thats it.";
            buttonText.text = "End";
            i++;
        }
        else
        {
            endDialogue = true;
            i = 0;
            EndDialogue();
            Destroy(GameObject.FindWithTag("Customer"));
            cust.isSpawned = false;
            CustomerMove.isStopped = false;
        }
        else
        {
            EndDialogue();
            Debug.Log("LET'S GRILL");
            CameraManager.Instance.SwitchViews();
        }
    }

    public void ResetDialogue()
    {
        i = 0;
    }
}
