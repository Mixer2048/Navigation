using UnityEngine;
using UnityEngine.AI;

public class SlimeAnimation : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void LateUpdate()
    {
        if (_agent.velocity.magnitude > 0.1f)
            _anim.SetInteger("state", 1);
        else
            _anim.SetInteger("state", 0);
    }

    public void PlayDieAnimation()
    {
        _anim.Play("Die");  
        //_anim.SetInteger("state", 3);
    }

    public void PlayAttackAnimation()
    {
        _anim.Play("Attack");
        //_anim.SetInteger("state", 2);
    }
}
