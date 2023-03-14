using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MPShooting : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject bullet;
    public GameObject muzzle;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject Gun;
    public AudioSource sound;
    private LineRenderer line;
    private Animator animator, animator2;
    private int numOfHit, numOfHit2;
    // Start is called before the first frame update
    void Start()
    {
        numOfHit = 0;
        numOfHit2 = 0;
        line = GetComponent<LineRenderer>();
        animator = enemy.GetComponent<Animator>();
        animator2 = enemy2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Gun.active)
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                bullet.transform.position = hit.point;
                sound.Play();
                StartCoroutine(ShowFlash());
                if (hit.transform.gameObject == enemy)
                {
                    numOfHit++;
                    if (numOfHit == 2)
                    {
                        animator.enabled = false;
                        animator.SetInteger("state", 4);
                        animator.enabled = true;
                    }
                }
                if (hit.transform.gameObject == enemy2)
                {
                    numOfHit2++;
                    if (numOfHit2 == 2)
                    {
                        animator2.enabled = false;
                        animator2.SetInteger("state", 4);
                        animator2.enabled = true;
                    }
                }
            }
        }
    }
    IEnumerator ShowFlash()
    {
        line.SetPosition(0, muzzle.transform.position);
        line.SetPosition(1, bullet.transform.position);
        yield return new WaitForSeconds(0.1f);
        line.SetPosition(0, aCamera.transform.position);
        line.SetPosition(1, aCamera.transform.position);
    }
}
