using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Asteroid;
    public float spawnRadius = 100f;
    public float spawnAngleOffset = 10f;
    public float spawnRate = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid),0,spawnRate);        
    }

    private void SpawnAsteroid(){
        Vector3 position = Random.insideUnitCircle.normalized * spawnRadius;
        position.z = position.y;
        position.y=0;
        Quaternion rotation = Quaternion.LookRotation(-1f*position.normalized);
        float angle = Random.Range(-spawnAngleOffset,spawnAngleOffset);
        Quaternion offsetRotation = Quaternion.AngleAxis(angle,Vector3.up);
        rotation *= offsetRotation;
        GameObject.Instantiate(Asteroid,position,rotation);
    }
}
