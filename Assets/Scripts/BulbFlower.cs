using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbFlower : AFlower {

    public override void Eat()
    {
        foreach (GameObject food in Foods)
        {
            if (Vector3.Distance(transform.position, food.transform.position) < 2)
            {
                if (food.GetComponent<IFood>().NutritionType == 1 && BlueEaten <= BlueFoodReq)
                {
                    BlueEaten += 2f * Time.deltaTime;
                    food.GetComponent<IFood>().Diminish(2f * Time.deltaTime);
                }
                else if (food.GetComponent<IFood>().NutritionType == 0 && RedEaten <= RedFoodReq)
                {
                    RedEaten += 2f * Time.deltaTime;
                    food.GetComponent<IFood>().Diminish(2f * Time.deltaTime);
                }
            }
        }
    }

    public override void PullFood()
    {
        foreach (GameObject food in FindObjectOfType<FoodManager>().Foods)
        {
            if (Vector3.Distance(food.transform.position, transform.position) <= flowerstats.foodpulldistance)
            {
                if (food.GetComponent<IFood>().NutritionType == 1 || food.GetComponent<IFood>().NutritionType == 0)
                {
                    food.GetComponent<Rigidbody>().AddForce((transform.position - food.transform.position) * flowerstats.foodpullfactor * Time.deltaTime);
                }
            }
        }
    }

    public override bool EatenEnough()
    {
        if (RedEaten >= RedFoodReq * 0.5f && BlueEaten >= BlueFoodReq * 0.5f)
        {
            CanPropagate = true;
        }
        if (RedFoodReq <= RedEaten && BlueFoodReq <= BlueEaten)
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
        Foods = FindObjectOfType<FoodManager>().Foods;
        RedFoodReq = 1f;
        BlueFoodReq = 7f;
        IsFruiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        Foods = FindObjectOfType<FoodManager>().Foods;
        CheckForChilren();
        PullFood();
        Eat();
    }
}
