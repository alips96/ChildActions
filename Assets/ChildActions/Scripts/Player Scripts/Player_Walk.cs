using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Child
{
    public class Player_Walk : MonoBehaviour
    {
        public List<Vector3> destinations = new List<Vector3>();
        GameManager_Master gameManagerMaster;
        Vector3 targetDestination;
        NavMeshAgent myNavMeshAgent;

        float nextCheck;
        float checkRate = 0.3f;
        byte index = 0;

        private void Start()
        {
            SetInitialReferences();
        }

        private void SetInitialReferences()
        {
            gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
            
            if(GetComponent<NavMeshAgent>() != null)
            {
                myNavMeshAgent = GetComponent<NavMeshAgent>();
            }

            HeadTowardTheFirstVector();
        }

        public void HeadTowardTheFirstVector()
        {
            MoveTowardNextTarget(0);
        }

        private void MoveTowardNextTarget(byte i)
        {
            if(i <= destinations.Count - 1)
            {
                targetDestination = destinations[i];
                myNavMeshAgent.SetDestination(targetDestination);
            }
            else
            {
                //Game is finished
                myNavMeshAgent.isStopped = true;
                gameManagerMaster.CallEventGameOver();
            }

        }

        private void Update()
        {
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;
                
                if(myNavMeshAgent.remainingDistance <= myNavMeshAgent.stoppingDistance)
                {
                    MoveTowardNextTarget(++index);
                }
            }
        }
    }
}

