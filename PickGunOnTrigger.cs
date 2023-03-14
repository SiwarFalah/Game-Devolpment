using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickGunOnTrigger : MonoBehaviour
{
    public GameObject gunInBox;
    public GameObject gunInHand;
    public Text GunPicked;
    private Animator animator;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gunInBox.SetActive(false);
        gunInHand.SetActive(true);
        if (Input.GetKeyDown(KeyCode.A))
        {

            animator.SetInteger("state", 6);
        }
        GunPicked.text = "Group 1 ";
       

    }

    // Update is called once per frame
    void Update()
    {

    }
}