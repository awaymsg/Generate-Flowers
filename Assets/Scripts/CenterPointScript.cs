﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPointScript : MonoBehaviour {

    bool IsFruiting;
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
                SeedGeneratorr.GetComponent<SeedGenerator>().GenerateSeed(transform, Size);
            }
        }
    }

	// Use this for initialization
	void Start () {
        IsFruiting = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
