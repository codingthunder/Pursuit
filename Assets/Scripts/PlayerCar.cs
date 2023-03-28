using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCar : MonoBehaviour
{
    public CivSpawnManager spawnManager;
    private List<Vector3> lanePositions = new List<Vector3>();

    public int lanePosition;
    private int maxLaneIndex;

    public event Action OnCollision;

    // Start is called before the first frame update
    void Start()
    {
        var civSpawns = spawnManager.spawnList;

        for (int i = 0; i < civSpawns.Length; i++)
        {
            Vector3 newPos = civSpawns[i].transform.position;

            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            lanePositions.Add(newPos);
        }

        maxLaneIndex = lanePositions.Count - 1;

        lanePosition = maxLaneIndex / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lanePositions[lanePosition];
    }

    public void OnMoveRight()
    {
        lanePosition += 1;

        if (lanePosition > maxLaneIndex)
        {
            lanePosition = maxLaneIndex;
        }
    }

    public void OnMoveLeft()
    {
        lanePosition -= 1;

        if (lanePosition < 0)
        {
            lanePosition = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CivCar otherCar;

        Rigidbody otherRigidbody = other.attachedRigidbody;
        if (otherRigidbody.TryGetComponent<CivCar>(out otherCar))
        {
            otherCar.Despawn();
            OnCollision.Invoke();
        }
    }

}
