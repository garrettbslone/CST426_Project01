using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public List<GameObject> ingredients;
    
    public void SpawnIngredient(string ingredient)
    {
        // Find ingredient with name provided
        GameObject toSpawn = ingredients.Find(r => r.GetComponent<Ingredient>().type == ingredient);
        SpawnCommand spawn = new SpawnCommand(this, toSpawn);
        spawn.Execute();

        
        Debug.Log("Ingredient added");
    }
    
    public void DespawnIngredient()
    {
        CommandManager.Instance.Undo();
    }
}
