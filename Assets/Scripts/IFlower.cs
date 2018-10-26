using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlower {

    int[] ReqFoodTypes { get; set; }
    FlowerStats flowerstats { get; set; }

}
