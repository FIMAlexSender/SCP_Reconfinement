using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatueMovement : MonoBehaviour
{
    public NavMeshAgent statue;
    public GameObject characterController;

    bool IsLook = false;

    void Awake()
    {
        statue = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (IsLook == false)
        {
            statue.isStopped = false;
            statue.SetDestination(characterController.gameObject.transform.position);
        }
        else
        {
            statue.velocity = new Vector3(0, 0, 0);
            statue.isStopped = true;
        }
    }

    public void PlayerLookStatue()
    {
        IsLook = true;
    }
    public void PlayerNotLookStatue()
    {
        IsLook = false;
    }

}
