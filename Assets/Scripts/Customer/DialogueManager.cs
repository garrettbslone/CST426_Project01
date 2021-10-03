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
    public CheckOrderManager check;
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
        if (CustomerMove.isStopped == true && endDialogue == false && i == 0)
        {
            StartDialogue();                
        }
    }

    public void StartDialogue()
    {
        orderText.text = "Hello! I would like one burger please with: ";
        animator.SetBool("IsOpen", true);
        check.checkText.text = "";
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    IEnumerator TypeSentence(string sentence)
    {
        orderText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            orderText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

    }

    void OnClick()
    {
        StopAllCoroutines();
        if (i < CustomerMove.my_order.Length)
        {
            StartCoroutine(TypeSentence(CustomerMove.my_order[i]));

            i++;
        }
        else if (i == CustomerMove.my_order.Length)

        {
            StartCoroutine(TypeSentence("... and that's it."));
            buttonText.text = "End";
            i++;
        }
        else
        {
            endDialogue = true;
            EndDialogue();
            CameraManager.Instance.SwitchViews();
            CheckOrderManager.Instance.timer.Start();
        }
    }

    public void ResetDialogue()
    {
        i = 0;
        Destroy(GameObject.FindWithTag("Customer"));
        cust.isSpawned = false;
        CustomerMove.isStopped = false;
        
    }
}

