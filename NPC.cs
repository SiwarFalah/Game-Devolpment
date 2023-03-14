using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    private Animator animator;
    private Animator animator1;
    private Animator animator2;
    private NavMeshAgent agent;
    public GameObject targetGun;
    public GameObject targetEnemy;
    public GameObject targetEnemy2;
    public GameObject gunInHand;
    public Text pick, dead;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animator1 = targetEnemy.GetComponent<Animator>();
        animator2 = targetEnemy2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetInteger("state") != 4)
        {
            agent.enabled = true;
        }
        else
        {
            dead.gameObject.SetActive(true);
            gunInHand.SetActive(false);
            agent.enabled = false;

        }
        if (!gunInHand.active)
        {
            agent.SetDestination(targetGun.transform.position);
        }
        else
        {
            pick.gameObject.SetActive(true);
            if (animator1.GetInteger("state") == 4)
            {
                if (animator2.GetInteger("state") == 4)
                {
                    animator.enabled = false;
                    agent.enabled = false;
                }
                else
                {
                    agent.SetDestination(targetEnemy2.transform.position);
                }
            }
            else
            {
                agent.SetDestination(targetEnemy.transform.position);
            }
        }
        if (animator.GetInteger("state") == 0)
        {
            animator.enabled = false;
            animator.SetInteger("state", 1);
            animator.enabled = true;

        }
        if (gunInHand.active && animator.GetInteger("state") == 1)
        {
            animator.enabled = false;
            animator.SetInteger("state", 4);
            animator.enabled = true;
        }
    }
   
}
