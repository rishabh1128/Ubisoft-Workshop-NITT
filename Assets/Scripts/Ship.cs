using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Ship : MonoBehaviour
{
    public float TurnRate = 150f;
    public float ThrustForce = 500f;
    
    public GameObject bullet;
    public float fireRate = 1f;

    private Rigidbody rb;
    private float xInput;
    private float yInput;
    private float timeSinceLastShot = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if(xInput > 0){
            transform.Rotate(Vector3.up,TurnRate * Time.deltaTime);
        }
        else if(xInput<0){
            transform.Rotate(Vector3.up,-1f * TurnRate * Time.deltaTime);
        }

        if(yInput > 0){
            rb.AddForce(transform.forward * ThrustForce * Time.deltaTime);
        }
        else if(yInput < 0){
            rb.AddForce(-1f * transform.forward * ThrustForce * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Space) && timeSinceLastShot > fireRate)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Wall")){
            rb.velocity *= -0.5f;
        }

        if(other.CompareTag("Enemy")){
            GameManager.Instance.Lives -= 1;
            if(GameManager.Instance.Lives > 0)
                GameManager.Instance.setLives(GameManager.Instance.Lives);
            else{
                //Game over
                //Pause
                GameManager.Instance.setLives(GameManager.Instance.Lives);
                Time.timeScale = 0;
            }
        }
    }

    private void Shoot(){
        GameObject.Instantiate(bullet,transform.position + 2f * transform.forward, transform.rotation);
    }
}
