using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPointScript : MonoBehaviour {

    [HideInInspector]
    public bool IsFruiting;
    FlowerStats flowerstats = new FlowerStats();
    Color FlowerColor;
    [HideInInspector]
    public float Size;
    [SerializeField] GameObject SeedGeneratorr;

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
                IsFruiting = true;
                SeedGeneratorr.GetComponent<SeedGenerator>().GenerateSeed(transform, flowerstats);
            }
        }
    }

	// Use this for initialization
	void Start () {
        IsFruiting = false;
	}

    public void GetFlowerStats(FlowerStats flowerstatz)
    {
        flowerstats = flowerstatz;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
