using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMotion : MonoBehaviour
{
    private float rotationAboutY = 0, rotationAboutX = 0;
    private float speed = 10, angularSpeed = 100;
    private CharacterController controller;
    private Animator animator;
    public GameObject camera; // publics must be initialized in Unity
    public GameObject gun;
    public Text dead, pick;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rotationAboutY = transform.localEulerAngles.y;
        animator = GetComponent<Animator>();
        Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dy = -1/*kind of a gravity*/, dz;
        if (animator.GetInteger("state") != 4)
        {
            // rotation about Y
            rotationAboutY += Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
            //       camera.transform.localEulerAngles = new Vector3(0, rotationAboutY, 0);
            transform.localEulerAngles = new Vector3(0, rotationAboutY, 0);

            // rotation about X
            rotationAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
            camera.transform.localEulerAngles = new Vector3(rotationAboutX, 0, 0);

            // moving forward/backward/left/right
            dz = Input.GetAxis("Vertical"); // can be -1, 0 , 1
            dz *= speed * Time.deltaTime;

            dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            Vector3 motion = new Vector3(dx, dy, dz); // in Local coordinates
            motion = transform.TransformDirection(motion);// change to Global coordinates
            controller.Move(motion);//in Global coordinates
            /* if (dz < -0.1 || dz > 0.1 || dx < -0.1 || dx > 0.1)
             {
                 agent.enabled = true;
                 animator.enabled = false;
                 animator.SetInteger("state", 1);
                 animator.enabled = true;
             }*/
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
            {
                if (gun.active)
                {
                    pick.gameObject.SetActive(true);
                    animator.enabled = false;
                    animator.SetInteger("state", 6);
                    animator.enabled = true;
                }
                else
                {
                    animator.enabled = false;
                    animator.SetInteger("state", 1);
                    animator.enabled = true;
                }
            }
        }
        else
        {
            dead.gameObject.SetActive(true);
            gun.SetActive(false);
        }
    }
}

