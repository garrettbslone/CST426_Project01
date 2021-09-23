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

    private bool endDialogue;

    void Start()
    {
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
        else if(i == CustomerMove.my_order.Length)
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
        }


    }
}
