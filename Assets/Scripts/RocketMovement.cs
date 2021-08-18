using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float movementSpeed = 50f;
    public float rotateSpeed = 20f;
    public float shootForce = 100f;

    public ParticleSystem smoke;

    public Transform spawnPoint;
    public GameObject laserPrefab;
    public AudioClip laserSound;

    public Rigidbody rocketBody;

    private AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        smoke.Stop();
    }

    // Update is called once per frame
    void Update()
    {
      

        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");


        if (   Input.GetKey(KeyCode.W)   )
        {
            rocketBody.AddForce(transform.forward * movementSpeed * Time.deltaTime);
            smoke.Play();
        }

        if (Input.GetKey(KeyCode.S))
        {
            rocketBody.AddForce(transform.forward * movementSpeed * Time.deltaTime * -1);
            smoke.Play();
        }

        if (Input.GetKey(KeyCode.A))
        {
            rocketBody.AddForce(transform.right * movementSpeed * Time.deltaTime * -1);
            smoke.Play();
        }

        if (Input.GetKey(KeyCode.D))
        {
            rocketBody.AddForce(transform.right * movementSpeed * Time.deltaTime);
            smoke.Play();
        }

        if( !Input.GetKey(KeyCode.W)  && !Input.GetKey(KeyCode.S)  && !Input.GetKey(KeyCode.A)  && !Input.GetKey(KeyCode.D))
        {
            rocketBody.velocity = rocketBody.velocity * 0.99f;
            smoke.Stop();
        }

        if(horizontalRotation == 0 && verticalRotation == 0)
        {
            rocketBody.angularVelocity = rocketBody.angularVelocity * 0.99f;
        }
       



            if (Input.GetMouseButton(1))
        {
            // Mouse X movement, Rotate
            rocketBody.AddTorque(0, horizontalRotation * Time.deltaTime * rotateSpeed, 0);

            // Mouse Y movement, Yaw
            rocketBody.AddTorque(verticalRotation * Time.deltaTime * rotateSpeed, 0, 0);


        }

        if (Input.GetMouseButtonDown(0))
        {
            // Create a new laser bullet
           GameObject laserShot =  Instantiate(laserPrefab, spawnPoint.position, spawnPoint.rotation);

            laserShot.GetComponent<Rigidbody>().velocity = rocketBody.velocity;
            laserShot.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);

            audioPlayer.PlayOneShot(laserSound);

            Destroy(laserShot, 5f);
        }
    }
}
