using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivSpawnManager : MonoBehaviour
{
    public CivSpawn[] spawnList;
    public CivCar civCarPrefab;
    public PlayerCar playerCarPrefab;
    private PlayerCar _playerCar;
    public PlayerCar PlayerCar { get { return _playerCar; } }
    public List<CivCar> carList;
    public float playerSpawnOffset;

    private Despawner despawner;

    public float laneWidth = 10f;
    public float laneLength = 100f;

    public float timeBetweenSpawns = 1f;
    private float timeSinceSpawn = 0f;

    [SerializeField]
    private int _maxCarsOnRoad = 10;

    private void Awake()
    {
        for (int i = 0; i < _maxCarsOnRoad; i++)
        {
            CivCar newCar = Instantiate(civCarPrefab);
            newCar.Despawn();
            newCar.transform.parent = transform;
            carList.Add(newCar);
        }

        spawnList = GetComponentsInChildren<CivSpawn>();

        despawner = GetComponentInChildren<Despawner>();
        despawner.transform.position = transform.position;

        _playerCar = Instantiate(playerCarPrefab);
        _playerCar.transform.parent = transform;
        _playerCar.spawnManager = this;
        Vector3 playerSpawnPos = transform.position;
        playerSpawnPos.z = playerSpawnOffset;
        _playerCar.transform.position = playerSpawnPos;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn > timeBetweenSpawns && CivCar.despawnedCars.Count > 0)
        {
            int spawnPointIndex = Random.Range(0, spawnList.Length);

            Vector3 spawnPos = spawnList[spawnPointIndex].transform.position;

            CivCar.despawnedCars[CivCar.despawnedCars.Count - 1].Spawn(spawnPos);
            timeSinceSpawn = 0;
            Debug.Log("Should be spawning.");
        }
    }
}
