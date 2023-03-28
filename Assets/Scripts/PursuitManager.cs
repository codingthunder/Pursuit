using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PursuitManager : MonoBehaviour
{
    public CivSpawnManager spawnManagerPrefab;

    public int maxPlayerHealth = 3;

    public int playerHealth = 3;

    private CivSpawnManager spawnManager;

    public Text healthCounter;

    private void Awake()
    {
        spawnManager = Instantiate(spawnManagerPrefab);
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializePursuit();
    }

    // Update is called once per frame
    void Update()
    {
        healthCounter.text = playerHealth.ToString();
    }

    void TakeDamage()
    {
        playerHealth--;
        healthCounter.text = playerHealth.ToString();
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        spawnManager.PlayerCar.OnCollision -= TakeDamage;

        Destroy(spawnManager.gameObject);
        spawnManager = Instantiate(spawnManagerPrefab);

        InitializePursuit();
    }

    void InitializePursuit()
    {
        spawnManager.PlayerCar.OnCollision += TakeDamage;
        playerHealth = maxPlayerHealth;
    }

    private void OnDestroy()
    {
        if (spawnManager != null)
            Destroy(spawnManager.gameObject);
    }
}
