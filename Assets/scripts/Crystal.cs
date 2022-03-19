using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{

    [SerializeField] int points = 5;

    public override void Picked()
    {
        Debug.Log("up");
        GameManager.gameManager.AddPoints(points);
        Destroy(this.gameObject);
        
    }
}
