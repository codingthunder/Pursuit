using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivCar : MonoBehaviour
{

    public static List<CivCar> despawnedCars = new List<CivCar> ();

    public static float CarSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.back * CarSpeed * Time.deltaTime);
    }

    public void Spawn(Vector3 spawnPosition)
    {
        if (despawnedCars.Contains(this))
        {
            despawnedCars.Remove(this);
        }

        transform.position = spawnPosition;
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);

        if (!despawnedCars.Contains(this))
        {
            despawnedCars.Add(this);
        }
    }
}
