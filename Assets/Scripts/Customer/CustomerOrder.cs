using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    static string[] ingredients = new string[5] {"Tomato", "Onion", "Lettuce", "Cheese", "Patty" };

    public static string[] OrderMaker(int score)
    {
        Debug.Log(score);

        score = 3 + (score % GamePlayManager.MAX_SCORE);
        string[] order = new string[score];

        order[0] = "Bun";
        order[1] = "Patty";

        for (int i = 2; i < score - 1; i++)
        {
            order[i] = ingredients[(int)Random.Range(0.0f, 5.0f)];
        }

        order[score - 1] = "Bun";

        return order;
    }
}
