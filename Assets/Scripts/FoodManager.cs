using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FoodManager : MonoBehaviour {

    [HideInInspector] public List<GameObject> Foods = new List<GameObject>();
    [SerializeField] GameObject RedFood;
    [SerializeField] GameObject BlueFood;
    [SerializeField] GameObject YellowFood;

    void GenerateFood()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(Random.Range(-8f, 8f), Random.Range(5f, 9f), Random.Range(-2f, 5f));
            GameObject food = Instantiate(RedFood, position, Quaternion.identity, transform);
            Foods.Add(food);
        }
        for (int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(Random.Range(-8f, 8f), Random.Range(5f, 9f), Random.Range(-2f, 5f));
            GameObject food = Instantiate(BlueFood, position, Quaternion.identity, transform);
            Foods.Add(food);
        }
        for (int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(Random.Range(-8f, 8f), Random.Range(5f, 9f), Random.Range(-2f, 5f));
            GameObject food = Instantiate(YellowFood, position, Quaternion.identity, transform);
            Foods.Add(food);
        }
    }

    void MoveFood()
    {
        foreach(GameObject food in Foods)
        {
            food.GetComponent<Rigidbody>().AddForce(new Vector3(Random.value, Random.value, Random.value) * 5f);
        }
    }

	// Use this for initialization
	void Start () {
        GenerateFood();
        MoveFood();
	}
	
	// Update is called once per frame
	void Update () {
        CheckFoods();
    }

    void CheckFoods()
    {
        foreach (GameObject food in Foods)
        {
            if (food.GetComponent<IFood>().FoodAmt <= 0)
            {
                Foods.Remove(food);
                Destroy(food);
            }
        }
    }
}
