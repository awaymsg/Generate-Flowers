using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFood : MonoBehaviour, IFood
{
    public float FoodAmt { get; set; }
    public float NutritionalValue { get; set; }
    public int NutritionType { get; set; }

    public void Diminish(float amt)
    {
        FoodAmt -= amt;
        if (FoodAmt <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        FoodAmt = Random.Range(3, 8);
        NutritionalValue = Random.Range(3f, 8f);
        NutritionType = 2;
    }

    void Update()
    {
        UpdateSize();
    }

    void UpdateSize()
    {
        transform.localScale = new Vector3(1, 1, 1) * FoodAmt * 0.1f;
    }
}
