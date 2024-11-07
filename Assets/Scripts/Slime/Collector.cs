using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    public UnityEvent OnCollect;

    [SerializeField] private LayerMask _collectableLayerMask;

    private int _detectionRadius = 2;

    private void LateUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _detectionRadius, _collectableLayerMask);

        if (colliders.Length > 0)
            //OnCollect?.Invoke();
            Debug.Log(colliders);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);        
    }
}
