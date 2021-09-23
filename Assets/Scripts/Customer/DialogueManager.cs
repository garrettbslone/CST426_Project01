using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    int i = 0;
    public Text orderText;

    public Animator animator;

    public Button nextButton;

    void Start()
    {
        Button btn = nextButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void Update()
    {
        if (CustomerMove.isStopped == true)
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
        if(i < CustomerMove.my_order.Length)
        {
            orderText.text = CustomerMove.my_order[i];
            i++;

        }
        else
        {
            orderText.text = "...and thats it.";
        }


    }
}