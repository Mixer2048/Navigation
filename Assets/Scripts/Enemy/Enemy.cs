using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    
    private int _waypointIndex = 0;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_waypoints[_waypointIndex].position);
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, _waypoints[_waypointIndex].position) < 0.5f)
        {
            _waypointIndex++;

            if (_waypointIndex >= _waypoints.Length)
                _waypointIndex = 0;

            _agent.SetDestination(_waypoints[_waypointIndex].position);
        }
    }
}
