using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class SlimeControll : MonoBehaviour
{
    public UnityEvent onDie;
    public Camera cam;
    public LayerMask ground;
    NavMeshAgent agent;
    bool dead = false;

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
        }
    }
    
    public void takeDamage()
    {
        dead = true;
        agent.SetDestination(transform.position);
        onDie?.Invoke();
        Destroy(this.gameObject, 1);
    }
}
