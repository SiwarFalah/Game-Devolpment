using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject MPlayer;
    public GameObject Teammate;
    public GameObject enemy;
    public GameObject enemy2;
    private Animator animator, animator2, animator3, animator4;
    public Text over;
    // Start is called before the first frame update
    void Start()
    {
        animator = MPlayer.GetComponent<Animator>();
        animator2 = enemy.GetComponent<Animator>();
        animator3 = enemy2.GetComponent<Animator>();
        animator4 = Teammate.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((animator.GetInteger("state") == 4 && animator4.GetInteger("state") == 4) || (animator2.GetInteger("state") == 4 && animator3.GetInteger("state") == 4))
        {
            if (animator2.GetInteger("state") == 4 && animator3.GetInteger("state") == 4)
            {
                over.text = "Congrats, You Won";
            }
            else
            {
                over.text = "Sadly, You Lose";
            }
            over.gameObject.SetActive(true);
        }
    }
}
