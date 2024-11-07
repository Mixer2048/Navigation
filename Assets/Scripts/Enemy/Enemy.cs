using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    [Header("Player Detection")]
    [SerializeField] private float _detectionRadius = 10f;
    [SerializeField] private LayerMask _playerLayerMask;

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

        Collider[] colliders = Physics.OverlapSphere(transform.position, _detectionRadius, _playerLayerMask);

        if (colliders.Length > 0)
            _agent.SetDestination(colliders[0].transform.position);
        else
            _agent.SetDestination(_waypoints[_waypointIndex].position);
    }
}
