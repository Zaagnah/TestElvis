
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMove : MonoBehaviour
{
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
    }
    
}
