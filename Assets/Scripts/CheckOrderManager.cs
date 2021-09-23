using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckOrderManager : MonoBehaviour
{
    private static string[] expected;
    private static Stack<string> entered;
    
    public static CheckOrderManager Instance { get; private set; }

    private float timeRemaining;
    private bool timerRunning;

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
        
        // TODO: dynamically update timer
        timeRemaining = 100;
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerRunning) return;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time has run out. Checking order now!");
            timerRunning = false;
            Check();
        }
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
            GamePlayManager.Instance.Score();
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
