using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public GameObject grenade;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            float x, y, z;
            x = transform.forward.x*10;
            y = 5;
            z = transform.forward.z*10;
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(x, y, z, ForceMode.Impulse);
            rb.useGravity = true;
            StartCoroutine(Explode());
        }
    }
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2);
        AudioSource sound = grenade.GetComponent<AudioSource>();
        sound.Play();
            explosion.transform.position = grenade.transform.position;
    explosion.SetActive(true);
    }
}
