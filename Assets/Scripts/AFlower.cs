using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AFlower : MonoBehaviour {

    public FlowerStats flowerstats;
    public bool IsFruiting;
    public int SeedNum;
    protected float RedFoodReq;
    protected float BlueFoodReq;
    protected float YellowFoodReq;
    protected List<GameObject> Foods = new List<GameObject>();
    protected float RedEaten;
    protected float BlueEaten;
    protected float YellowEaten;
    protected bool CanPropagate;
    public GameObject SeedGeneratorr;

    public bool FruitingChange
    {
        get
        {
            return IsFruiting;
        }
        set
        {
            if (value != IsFruiting)
            {
                SeedGeneratorr = GameObject.FindGameObjectWithTag("SeedGenerator");
                IsFruiting = true;
                Debug.Log(gameObject);
                Debug.Log(flowerstats);
                if (EatenEnough() && CanPropagate)
                {
                    SeedNum = Random.Range(1, 4);
                } else if (!EatenEnough() && CanPropagate)
                {
                    SeedNum = Random.Range(0, 1);
                } else
                {
                    SeedNum = 0;
                }
                SeedGeneratorr.GetComponent<SeedGenerator>().GenerateSeed(gameObject, flowerstats, SeedNum);
            }
        }
    }

    public void ResetFoodEaten()
    {
        RedEaten = 0;
        BlueEaten = 0;
        YellowEaten = 0;
    }

    public void CheckForChilren()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    public abstract void PullFood();

    public void GetFlowerStats(FlowerStats flowerstatz)
    {
        flowerstats = flowerstatz;
    }

    public abstract void Eat();

    public abstract bool EatenEnough();

    //public abstract void SetMeshData();

	public virtual void Grow()
    {

    }
}
