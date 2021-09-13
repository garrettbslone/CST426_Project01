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
        // TODO: Add ingredient to CheckOrder list
        ingredient = GameObject.Instantiate(this.ingredient, spawner.transform);
        ingredient.transform.position = spawner.transform.position;
        CommandManager.Instance.AddCommand(this);
    }

    public void Undo()
    {
        // TODO: Remove ingredient from CheckOrder list
        GameObject.Destroy(ingredient);   
    }
}
