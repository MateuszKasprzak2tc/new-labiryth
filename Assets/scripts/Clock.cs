using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    [SerializeField] int addTime = -9;

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(sound);
        Debug.Log("add " +addTime);
        GameManager.gameManager.AddTime(addTime);
        Destroy(this.gameObject);
    }
}
