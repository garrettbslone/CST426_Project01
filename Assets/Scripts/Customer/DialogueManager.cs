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

    public CustomerSpawn cust;
<<<<<<< Updated upstream
=======
    public CheckOrderManager check;
    public bool endDialogue;
>>>>>>> Stashed changes

    public bool endDialogue;

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
<<<<<<< Updated upstream

=======
        check.checkText.text = "";
>>>>>>> Stashed changes
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
            i = 0;
            EndDialogue();
            Destroy(GameObject.FindWithTag("Customer"));
            cust.isSpawned = false;
            CustomerMove.isStopped = false;
        }

<<<<<<< Updated upstream

=======
    public void ResetDialogue()
    {
        i = 0;
        cust.isSpawned = false;
        CustomerMove.isStopped = false;
        
>>>>>>> Stashed changes
    }
}
