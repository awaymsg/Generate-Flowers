using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AFlower : MonoBehaviour {

    public FlowerStats flowerstats;
    protected float RedFoodReq;
    protected float BlueFoodReq;
    protected float YellowFoodReq;
    protected List<GameObject> Foods = new List<GameObject>();
    protected float RedEaten;
    protected float BlueEaten;
    protected float YellowEaten;

    public abstract void Eat();

    public abstract bool EatenEnough();

    //public abstract void SetMeshData();

	public virtual void Grow()
    {

    }
}
