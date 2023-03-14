using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer3Motion : MonoBehaviour
{
    public Animator animator;
    public GameObject camera;
    public GameObject seeThroughCrosshair;
    public GameObject touchCrosshair;
    public Text whatToDo;
    private bool isDrawerOpened = false,isFocusOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // check what object is in our focus
        if(Physics.Raycast(camera.transform.position,camera.transform.forward,out hit))
        {
            if(hit.transform.gameObject!=null && hit.distance<5)
            {
                // check that the object in camera focus is THIS
                if (this.transform.gameObject == hit.transform.gameObject)
                {
                    // change crosshair
                    if (!isFocusOn)
                    {
                        seeThroughCrosshair.SetActive(false);
                        touchCrosshair.SetActive(true);
                        isFocusOn = true;
                    }
                    // show the right inscription
                    if(isDrawerOpened)
                    {
                        whatToDo.text = "Press [E] to close the drawer";

                    }
                    else // the drawer is closed
                    {
                        whatToDo.text = "Press [E] to open the drawer";

                    }
                    whatToDo.gameObject.SetActive(true);
                    // and allow action on drawer
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        animator.SetBool("Drawer3Openning", !isDrawerOpened);
                        isDrawerOpened = !isDrawerOpened;
                    }
                }
                else // this.transform.gameObject != hit.transform.gameObject
                {
                    if(isFocusOn)
                    {
                        isFocusOn = false;
                        seeThroughCrosshair.SetActive(true);
                        touchCrosshair.SetActive(false);
                        whatToDo.gameObject.SetActive(false);
                    }
                }

            }
           
        }


     }
}
