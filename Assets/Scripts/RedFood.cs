﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFood : MonoBehaviour, IFood {

    public float FoodAmt { get; set; }
    public float NutritionalValue { get; set; }
    public int NutritionType { get; set; }

    public void Diminish(float amt)
    {
        FoodAmt-= amt;
    }

	void Awake () {
        FoodAmt = Random.Range(3, 8);
        NutritionalValue = Random.Range(3f, 8f);
        NutritionType = 0;
    }
	
	void Update () {
        UpdateSize();
    }

    void UpdateSize ()
    {
        transform.localScale = new Vector3(1, 1, 1) * FoodAmt * 0.1f;
    }
}
