using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{

    // Called by button press from UI
    public void SpawnIngredient(GameObject ingredient)
    {
        SpawnCommand spawn = new SpawnCommand(this, ingredient);
        spawn.Execute();
    }
    
    public void DespawnIngredient()
    {
        CommandManager.Instance.Undo();
    }
}
