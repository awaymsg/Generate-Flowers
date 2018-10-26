using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbFlower : AFlower
{

    public override void Eat()
    {
        foreach (GameObject food in Foods)
        {
            if (Vector3.Distance(transform.position, food.transform.position) < 2)
            {
                if (food.GetComponent<IFood>().NutritionalValue == 1)
                {
                    YellowEaten += 0.3f;
                    food.GetComponent<IFood>().Diminish(0.3f);
                }
                else
                if (food.GetComponent<IFood>().NutritionalValue == 0)
                {
                    RedEaten += 0.3f;
                    food.GetComponent<IFood>().Diminish(0.3f);
                }
            }
        }
    }

    public override bool EatenEnough()
    {
        if (RedFoodReq <= RedEaten && YellowFoodReq <= YellowEaten)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Awake()
    {
        Foods = GameObject.FindObjectOfType<FoodManager>().Foods;
        RedFoodReq = 1f;
        BlueFoodReq = 7f;
        IsFruiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        Foods = GameObject.FindObjectOfType<FoodManager>().Foods;
        Eat();
    }
}
