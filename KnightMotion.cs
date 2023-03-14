using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnightMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
   // private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
      //  agent.enabled = false;
     //   line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (agent.enabled)

        int st = animator.GetInteger("state");

        agent.SetDestination(target.transform.position); // start AI path generation (A*)
                                                         // and start moving on the path
                                                         // draw path
        if (st == 4) 
            agent.enabled = false;
       
        //  line.positionCount = agent.path.corners.Length;
        //     line.SetPositions(agent.path.corners);

        /*
        if (Input.GetKeyDown(KeyCode.Z))
            animator.SetInteger("state", 0);
        else if (Input.GetKeyDown(KeyCode.X))
            animator.SetInteger("state", 1);
        else if (Input.GetKeyDown(KeyCode.C))
            animator.SetInteger("state", 2);
        else if (Input.GetKeyDown(KeyCode.V))
            animator.SetInteger("state", 3);
        else if (Input.GetKeyDown(KeyCode.B))
            animator.SetInteger("state", 4);
        */

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == target.gameObject.name)  // if the NPC has touched the
        {// target then we move the target to a new position
            float x, y, z;

            x = Random.Range(-20, 150);
            z = Random.Range(30, 170);
            y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z));

            target.transform.position = new Vector3(x, y, z);
        }
    }

}
