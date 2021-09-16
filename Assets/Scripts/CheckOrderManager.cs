using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckOrderManager : MonoBehaviour
{
    private static List<Ingredient> expected;
    private static List<Ingredient> entered;
    
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
        expected = new List<Ingredient>();
        entered = new List<Ingredient>();
        
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
        Debug.Log("Expected: ");
        expected.ForEach(Debug.Log);
        Debug.Log("\nEntered: ");
        entered.ForEach(Debug.Log);

        if (entered.SequenceEqual(expected))
        {
            Debug.Log("You were correct!");
            GamePlayManager.Instance.Score();
        }
        else
        {
            Debug.Log("You were correct!");
            GamePlayManager.Instance.Strike();
        }
    }

    private static void AddIngredient(Ingredient ingredient, List<Ingredient> ingredients)
    {
        ingredients.Add(ingredient);
    }
    
    public void AddIngredientExpected(Ingredient ingredient)
    {
        AddIngredient(ingredient, expected);
    }
    
    public void AddIngredientEntered(Ingredient ingredient)
    {
        AddIngredient(ingredient, entered);
    }
    
    private static void RemoveIngredient(Ingredient ingredient, List<Ingredient> ingredients)
    {
        ingredients.Remove(ingredient);
    }
    
    public void RemoveIngredientExpected(Ingredient ingredient)
    {
        RemoveIngredient(ingredient, expected);
    }
    
    public void RemoveIngredientEntered(Ingredient ingredient)
    {
        RemoveIngredient(ingredient, entered);
    }
}
