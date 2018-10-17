using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour {
    public float Size;

    // Use this for initialization
    private void Awake()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }

    void Start () {
        //Debug.Log(Size);
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x < Size)
        {
            transform.localScale += new Vector3(1,1,1) * 0.05f * Time.deltaTime;
        }
	}
}

public class FlowerStats
{
    public PetalDrawer.FlowerType flowertype;
    public Color flowercolor;
    public float size;
}
