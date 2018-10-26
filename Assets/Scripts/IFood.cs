using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFood {

    float FoodAmt { get; set; }
    float NutritionalValue { get; set; }
    int NutritionType { get; set; }

    void Diminish(float amt);

}
