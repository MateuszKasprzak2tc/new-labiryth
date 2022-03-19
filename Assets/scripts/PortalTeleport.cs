using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform reciever;


    public bool isPlayerOverlapping = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Teleportation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOverlapping = false;
        }
    }

    private void Teleportation()
    {
        if (isPlayerOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProdcut = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProdcut < 0)
            {
                float rotationDifference = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDifference += 180;
                player.Rotate(Vector3.up, rotationDifference);
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;


                player.position = reciever.position + positionOffset;
                isPlayerOverlapping = false;

                isPlayerOverlapping = false;
            }
        }
    }
}
