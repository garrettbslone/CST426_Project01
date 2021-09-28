using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Util;

public class CheckOrderManager : MonoBehaviour
{
    private static string[] expected;
    private static Stack<string> entered;
    
    public static CheckOrderManager Instance { get; private set; }

    private Timer timer;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // TODO: get expected from scene
        // expected = new List<string>();
        entered = new Stack<string>();
        timer = new Timer();
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

        bool correct = false;
        
        if (entered.SequenceEqual(expected))
        {
            Debug.Log("You were correct!");
            GamePlayManager.Instance.Score();
            
            this.timer.Dec();
            correct = true;
        }
        else
        {
            Debug.Log("You were incorrect!");
            GamePlayManager.Instance.Strike();
        }
        // Clear everything
        CustomerSpawn.Instance.Respawn();
        CommandManager.Instance.ClearAll();
        DialogueManager.Instance.ResetDialogue();

        if (correct || 
            (!this.timer.IsRunning() && this.timer.GetTimeRemaining() <= 0.0f))
        {
            this.timer.Reset();
        }
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
