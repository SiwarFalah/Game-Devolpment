using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShooting : MonoBehaviour
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
    private bool updateOn = true;
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
        if (updateOn == true)
        {
            if (Gun.active)
            {
                RaycastHit hit;
                if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
                {

                    if (hit.transform.gameObject == enemy && animator.GetInteger("state") != 3)
                    {
                        StartCoroutine(Stop());
                        bullet.transform.position = hit.point;
                        sound.Play();
                        StartCoroutine(ShowFlash());
                        numOfHit++;
                        if (numOfHit == 2)
                        {
                            animator.enabled = false;
                            animator.SetInteger("state", 3);
                            animator.enabled = true;

                        }
                    }
                    if (hit.transform.gameObject == enemy2 && animator2.GetInteger("state") != 3)
                    {
                        StartCoroutine(Stop());
                        bullet.transform.position = hit.point;
                        sound.Play();
                        StartCoroutine(ShowFlash());
                        numOfHit2++;
                        if (numOfHit2 == 2)
                        {
                            animator2.enabled = false;
                            animator2.SetInteger("state", 3);
                            animator2.enabled = true;

                        }
                    }
                }
            }
        }
    }
    IEnumerator ShowFlash()
    {
        line.SetPosition(0, muzzle.transform.position);
        line.SetPosition(1, bullet.transform.position);
        yield return new WaitForSeconds(0.5f);
        line.SetPosition(0, aCamera.transform.position);
        line.SetPosition(1, aCamera.transform.position);
    }

    IEnumerator Stop()
    {
        updateOn = false;
        yield return new WaitForSeconds(0.5f);
        updateOn = true;
    }
}
