using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IsLookingShyGuy : MonoBehaviour
{
    public GameObject shyGuyFace;
    public ShyGuyController shyGuyController;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        bool isHitting = Physics.Raycast(cam.transform.position, shyGuyFace.transform.position - cam.transform.position, out RaycastHit hit);

        if (isHitting)
        {
            Debug.Log("Hit");
            var shyGuy = hit.collider.GetComponent<GameObject>();

            if (shyGuy)
            {
                Vector3 rangeVector = cam.WorldToViewportPoint(shyGuy.transform.position);

                if (rangeVector.z > 0)
                {
                    shyGuyController.PlayerLookShyGuy();
                }
                else
                {
                    shyGuyController.PlayerNotLookShyGuy();
                }
            }
        }
    }
}
