using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    public GameObject objectToCreate;
    private float interval = 10f;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Instantiate(objectToCreate, transform.position, transform.rotation);
            timer -= interval;
        }
    }
}