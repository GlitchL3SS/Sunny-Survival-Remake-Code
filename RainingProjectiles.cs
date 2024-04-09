using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainingProjectiles : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float spawnRate = 1.0f; // Time between projectile spawns (seconds)
    public float spawnHeight = 10.0f; // Height from where projectiles spawn
    public float projectileSpeed = 5.0f; // Speed of the projectile (downwards)

    private float lastSpawnTime = Mathf.NegativeInfinity; // Tracks time of last projectile spawn

    void Start()
    {
        // If no spawner prefab is used, set this transform's y position to spawnHeight
        if (transform.parent == null)
        {
            transform.position = new Vector3(transform.position.x, spawnHeight, transform.position.z);
        }
    }

    void Update()
    {
        if (Time.time - lastSpawnTime >= spawnRate) // Check if enough time has passed between spawns
        {
            SpawnProjectile();
            lastSpawnTime = Time.time; // Update last spawn time
        }
    }

    void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, new Vector3(Random.Range(-35.0f, 15.0f), spawnHeight, 0.0f), Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * projectileSpeed;

        Destroy(projectile, 5f);
    }
}