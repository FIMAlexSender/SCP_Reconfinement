using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlinkSystem : MonoBehaviour
{
    public NavMeshAgent statueController;
    public StatueMovement statueMovement;
    public Camera cam;

    void Update()
    {
        bool isHitting = Physics.Raycast(cam.transform.position, statueController.transform.position - cam.transform.position, out RaycastHit hit);

        if (isHitting)
        {
            var statue = hit.collider.GetComponent<StatueMovement>();

            if (statue)
            {
                Vector3 rangeVector = cam.WorldToViewportPoint(statue.transform.position);

                if (rangeVector.z > 0)
                {
                    statueMovement.PlayerLookStatue();
                }
                else
                {
                    statueMovement.PlayerNotLookStatue();
                }
            }
        }
    }
}