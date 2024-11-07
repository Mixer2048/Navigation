using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class SlimeControll : MonoBehaviour
{
    public UnityEvent onDie;
    public UnityEvent OnCollect;

    public Camera cam;
    public LayerMask ground;
    NavMeshAgent agent;
    bool dead = false;

    private int _detectionRadius = 2;
    [SerializeField] private LayerMask _collectableLayerMask;
    Collider[] collectablesColliders;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void LateUpdate()
    {
        if (dead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000f, ground))
                {
                    agent.SetDestination(hit.point);
                }
            }

            CheckCollectables();
        }
    }
    
    public void takeDamage()
    {
        dead = true;
        agent.SetDestination(transform.position);
        onDie?.Invoke();
        Destroy(this.gameObject, 1);
    }

    public void CollectItem()
    {
        if (collectablesColliders.Length > 0)
        {
            Collectable item = collectablesColliders[0].GetComponent<Collectable>();

            if (item != null)
                item.TakeItem();
        }
    }

    private void CheckCollectables()
    {
        collectablesColliders = Physics.OverlapSphere(transform.position, _detectionRadius, _collectableLayerMask);

        if (collectablesColliders.Length > 0)
        {
            agent.SetDestination(transform.position);
            agent.transform.LookAt(collectablesColliders[0].transform);
            OnCollect?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
