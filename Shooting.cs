using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooting : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject target;
    public GameObject muzzle;
    private LineRenderer line;
    public AudioSource shootingSound;
    public GameObject Knight;
    public GameObject Knight2;
    private Animator animator;
    private Animator animator2;
    private int numHits;
    private NavMeshAgent agent;
    private NavMeshAgent agent2;
    // Start is called before the first frame update
    void Start()
    {
        numHits = 0;
        line = GetComponent<LineRenderer>();
        animator = Knight.GetComponent<Animator>();
        agent = Knight.GetComponent<NavMeshAgent>();
        animator2 = Knight2.GetComponent<Animator>();
        agent2 = Knight2.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                target.transform.position = hit.point;
                shootingSound.Play();
                StartCoroutine(ShowFlash());
                if (hit.transform.gameObject == Knight || Knight2)
                {
                    numHits++;
                    if (numHits < 3) // npc can fall and get up again
                        StartCoroutine(KnightFallAndGettingUp());
                    else // npc is dying
                    {
                        animator.SetInteger("state", 4); // dying
                        animator2.SetInteger("state", 4);
                        agent.enabled = false;
                    }
                }
            }

        }
    }
    IEnumerator KnightFallAndGettingUp()
    {
        // check what state was before falling
        int st = animator.GetInteger("state");
        st = animator2.GetInteger("state");

        // stop moving towards the target
        if (st == 1) // walking
            agent.enabled = false;

        animator.SetInteger("state", 2); // fall back
        animator2.SetInteger("state", 2);

        yield return new WaitForSeconds(2f); // delay
        animator.SetInteger("state", 3); // getting up
        animator2.SetInteger("state", 3);
        yield return new WaitForSeconds(1f); // delay
                                             // renew motion
        if (st == 1) // it was walking
        {
            agent.enabled = true;
        }
        animator.SetInteger("state", st); // previous state
        animator2.SetInteger("state", st);


    }

    IEnumerator ShowFlash()
    {
        // draw flash
        line.SetPosition(0, muzzle.transform.position);
        line.SetPosition(1, target.transform.position);

        // all the lines before next line run immideatly
        yield return new WaitForSeconds(0.1f); // delay
                                               // the next lines will be executed after the delay
                                               // erase flash
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);

    }
}