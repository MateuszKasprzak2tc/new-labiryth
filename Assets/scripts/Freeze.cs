using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : PickUp
{
    [SerializeField] float frezzeTime = 5f;

    public override void Picked()
    {
        Debug.Log("Time will resume in" + frezzeTime);
        GameManager.gameManager.FreezeTime(frezzeTime);
        Destroy(this.gameObject);
    }
}
