using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    static string[] ingredients = new string[4] {"Tomato", "Onion", "Lettuce", "Cheese" };

    public static string[] OrderMaker2()
    {
        string[] order = new string[5];
        order[0] = "Bun";
        order[1] = "Patty";
        order[2] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[3] = ingredients[(int)Random.Range(0.0f, 4.0f)]; 
        order[4] = "Bun";
        return order;
    }

    public static string[] OrderMaker3()
    {
        string[] order = new string[6];
        order[0] = "Bun";
        order[1] = "Patty";
        order[2] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[3] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[4] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[5] = "Bun";
        return order;
    }

    public static string[] OrderMaker4()
    {
        string[] order = new string[7];
        order[0] = "Bun";
        order[1] = "Patty";
        order[2] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[3] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[4] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[5] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[6] = "Bun";
        return order;
    }

    public static string[] OrderMaker5()
    {
        string[] order = new string[8];
        order[0] = "Bun";
        order[1] = "Patty";
        order[2] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[3] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[4] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[5] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[6] = ingredients[(int)Random.Range(0.0f, 4.0f)];
        order[7] = "Bun";
        return order;
    }
}
