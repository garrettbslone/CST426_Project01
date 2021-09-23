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

    public static DialogueManager Instance { get; private set; }

    void Start()
    {
        Instance = this;
        Button btn = nextButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void Update()
    {
        if (CustomerMove.isStopped == true && i == 0)
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
        if(i < CustomerMove.my_order.Length)
        {
            orderText.text = (i + 1) + ": " + CustomerMove.my_order[i];
            i++;

        }
        else if (i == CustomerMove.my_order.Length)
        {
            orderText.text = "...and thats it.";
            i++;
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
