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
<<<<<<< Updated upstream
            StartDialogue();                
=======
            StartDialogue();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
        }

    }

    public void StartDialogue()
    {
<<<<<<< Updated upstream
        animator.SetBool("IsOpen", true);        
=======
        animator.SetBool("IsOpen", true);
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    void OnClick()
    {
        if (i < CustomerMove.my_order.Length)
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            if(i > 0 && (CustomerMove.my_order[i] == CustomerMove.my_order[i - 1]))
=======
            if (i > 0 && (CustomerMove.my_order[i] == CustomerMove.my_order[i - 1]))
>>>>>>> Stashed changes
=======
            if (i > 0 && (CustomerMove.my_order[i] == CustomerMove.my_order[i - 1]))

>>>>>>> Stashed changes
            {
                orderText.text = "another " + CustomerMove.my_order[i];

            }
            else
            {
                orderText.text = CustomerMove.my_order[i];
            }
            i++;


        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        else if(i == CustomerMove.my_order.Length)
=======
        else if (i == CustomerMove.my_order.Length)
>>>>>>> Stashed changes
=======
        else if (i == CustomerMove.my_order.Length)

>>>>>>> Stashed changes
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
