using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickGun : MonoBehaviour
{
    public GameObject gunInBox;
    public GameObject gunInHand;
    public Text GunPicked;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator =GetComponent<Animator>();
    }

    private void OnMouseDown()
    {

        gunInBox.SetActive(false);
        gunInHand.SetActive(true);
        GunPicked.text = "Group 1 ";
        animator.SetInteger("state", 6);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

