using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCommand : CommandManager.ICommand
{
    IngredientSpawner spawner;
    GameObject ingredient;

    public SpawnCommand(IngredientSpawner spawner, GameObject ingredient)
    {
        this.spawner = spawner;
        this.ingredient = ingredient;
    }

    public void Execute()
    {
        ingredient = GameObject.Instantiate(this.ingredient, spawner.transform);
        ingredient.transform.position = spawner.transform.position;
        CheckOrderManager.Instance.AddIngredientEntered(ingredient.GetComponent<Ingredient>().type);
        CommandManager.Instance.AddCommand(this);
    }

    public void Undo()
    {
         CheckOrderManager.Instance.RemoveIngredientEntered(ingredient.GetComponent<Ingredient>().type);
        GameObject.Destroy(ingredient);   
    }

    public GameObject GetIngredient()
    {
        return ingredient;
    }
}
