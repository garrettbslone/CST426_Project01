using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnIngredient(GameObject ingredient)
    {
        GameObject bun = GameObject.Instantiate(ingredient, this.transform);
        bun.transform.position = this.transform.position;
    }
}
