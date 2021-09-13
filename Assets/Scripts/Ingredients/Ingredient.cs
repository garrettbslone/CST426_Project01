using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string type;
    public Color color;

    void Awake()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", color);
    }



}
