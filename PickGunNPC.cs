using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickGunNPC : MonoBehaviour
{
    public GameObject gunInBox;
    public GameObject gunInHand;
    public Text GunPicked;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gunInBox.SetActive(false);
        gunInHand.SetActive(true);
        GunPicked.text = "Group 2 ";
        animator.SetInteger("state", 6);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
