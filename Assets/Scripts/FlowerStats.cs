using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FlowerStats {

    public enum FlowerType { triFlower, bulbFlower, roundFlower }
    public FlowerType flowertype;
    public float size;
    public float foodpullfactor;
    public float foodpulldistance;
    public Color flowercolor;
	
}
