using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public Door[] doors;
    Animator animator;

    bool iCanOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You can use Lock");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("You can't use Lock");
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void UseKey()
    {
        foreach(Door drzwi in doors)
        {
            drzwi.OpenClose();
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && iCanOpen)
        {
            animator.SetBool("useKey", true);
        }
    }
}
