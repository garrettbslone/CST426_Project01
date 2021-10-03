using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Util;
using UnityEngine.UI;

public class CheckOrderManager : MonoBehaviour
{
    private static string[] expected;
    private static Stack<string> entered;
    
    public static CheckOrderManager Instance { get; private set; }

    public Timer timer;

    public Text checkText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        entered = new Stack<string>();
        timer = new Timer();
        timer.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.timer.IsRunning())
        {
            GamePlayManager.Instance.Time(this.timer.GetTimeRemaining());
            return;
        };

        float rem = this.timer.Tick();
        
        if (rem <= 0f)
        {
            this.timer.Stop();
            Debug.Log("Time has run out. Checking order now!");
            Check();

            rem = 0f;
        }
        
        GamePlayManager.Instance.Time(rem);
    }

    public void Check()
    {
        CameraManager.Instance.SwitchViews();
        Array.Reverse(expected);

        Debug.Log("Expected: ");
        // expected.ForEach(Debug.Log);
        foreach (string s in expected)
        {
            Debug.Log(s);
        }
        Debug.Log("\nEntered: ");
        // entered.ForEach(Debug.Log);
        foreach (string s in entered)
        {
            Debug.Log(s);
        }
        
        if (entered.SequenceEqual(expected))
        {
            Debug.Log("You were correct!");
            checkText.text = "CORRECT!\nScore + 1";
            GamePlayManager.Instance.Score();
            
            this.timer.Dec();
        }
        else
        {
            Debug.Log("You were incorrect!");
            checkText.text = "INCORRECT!\nStrike + 1";
            GamePlayManager.Instance.Strike();
        }
        // Clear everything
        CustomerSpawn.Instance.Respawn();
        CommandManager.Instance.ClearAll();
        DialogueManager.Instance.ResetDialogue();
        this.timer.Reset();
        this.timer.Stop();
    }

    private static void AddIngredient(Ingredient ingredient, List<Ingredient> ingredients)
    {
        ingredients.Add(ingredient);
    }
    
    public void AddIngredientEntered(string ingredient)
    {
        // entered.Add(ingredient);
        entered.Push(ingredient);
    }
    
    public void RemoveIngredientEntered(string ingredient)
    {
        //entered.Remove(ingredient);
        entered.Pop();
    }

    public void SetExpected(string[] newExpected)
    {
        expected = newExpected;
    }
}
