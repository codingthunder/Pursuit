using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CivCar otherCar;

        Rigidbody otherRigidbody = other.attachedRigidbody;
        if (otherRigidbody.TryGetComponent<CivCar>(out otherCar))
        {
            otherCar.Despawn();
        }
    }
}
