using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tooManyVoicesController : MonoBehaviour
{
    public GameObject playerCharacter;
    public NavMeshAgent scp;

    public GameObject[] Borders;

    public float rangeRandomMove;

    public float hearingDistance;
    public float attackDistance;
    public float rangeRandomMoveHearing;

    public LayerMask characterMask;
    
    // Update is called once per frame
    void Update()
    {
        bool isHearing = Physics.CheckSphere(scp.transform.position, hearingDistance, characterMask);

        if (isHearing)
        {
            Vector3 characterVelocity = playerCharacter.GetComponent<CharacterController>().velocity;

            if (characterVelocity != new Vector3 (0,0,0))
            {
                Vector3 characterPosition = playerCharacter.transform.position;

                float randX = Random.Range(characterPosition.x - rangeRandomMoveHearing, characterPosition.x + rangeRandomMoveHearing);
                float randZ = Random.Range(characterPosition.z - rangeRandomMoveHearing, characterPosition.z + rangeRandomMoveHearing);

                scp.SetDestination(new Vector3(randX, 0, randZ));

                bool isAttacking = Physics.CheckSphere(scp.transform.position, attackDistance, characterMask);

                if (isAttacking)
                {
                    scp.SetDestination(characterPosition);
                }
                else
                {
                    MoveRandomly();
                }
            }
            else
            {
                MoveRandomly();
            }
        }

        else
        {
            MoveRandomly();
        }
    }

    public void MoveRandomly()
    {
        if (scp.velocity == new Vector3(0, 0, 0))
        {
            float minBorderX = Borders[0].transform.position.x;
            float maxBorderX = Borders[1].transform.position.x;
            float minBorderY = Borders[0].transform.position.y;
            float maxBorderY = Borders[2].transform.position.y;

            Vector3 randRange = new Vector3(Random.Range(minBorderX, maxBorderX), 0, Random.Range(minBorderY, maxBorderY));

            scp.SetDestination(randRange);
        }

    }
}
