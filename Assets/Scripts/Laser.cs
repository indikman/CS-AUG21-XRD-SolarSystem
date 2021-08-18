using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laserParticle;
    //public AudioClip laserDestroy;

    //public AudioSource audioPlayer;


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

        Instantiate(laserParticle, transform.position, transform.rotation);
        //audioPlayer.PlayOneShot(laserDestroy);

        Destroy(gameObject);
    }

}
