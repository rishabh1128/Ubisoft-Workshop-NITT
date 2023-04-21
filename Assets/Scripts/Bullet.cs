using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
            GameManager.Instance.setScore(GameManager.Instance.Score+1);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
