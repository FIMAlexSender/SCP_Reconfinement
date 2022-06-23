using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class ShyGuyController : MonoBehaviour
{
    public NavMeshAgent scp;
    public CharacterController characterController;
    
    bool isLooking = false;
    bool startScream = false;
    bool startRuning = false;
    
    void Update()
    {
        if (startScream)
        {
            if (isLooking)
            {
                startScream = true;

                int randSleep = Random.Range(6000, 15000);

                Debug.Log(randSleep);

                Thread.Sleep(randSleep);

                startRuning = true;
            }
        }

        if (startRuning)
        {
            scp.SetDestination(characterController.gameObject.transform.position);
        }
    }

    public void PlayerLookShyGuy()
    {
        isLooking = true;
    }

    public void PlayerNotLookShyGuy()
    {
        isLooking = false;
    }
}
