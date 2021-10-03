using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Util;
using UnityEngine.UI;

public class CheckOrderManager : MonoBehaviour
{
    private static List<Ingredient> expected;
    private static List<Ingredient> entered;
    
    public static CheckOrderManager Instance { get; private set; }

    private Timer timer;

    public Text checkText;

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
        bool correct = false;
        
        if (entered.SequenceEqual(expected))
        {
            Debug.Log("You were correct!");
            checkText.text = "CORRECT!\nScore + 1";
            GamePlayManager.Instance.Score();
            
            this.timer.Dec();
            correct = true;
        }
        else
        {
            Debug.Log("You were incorrect!");
            checkText.text = "INCORRECT!\nStrike + 1";
            GamePlayManager.Instance.Strike();
        }

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
