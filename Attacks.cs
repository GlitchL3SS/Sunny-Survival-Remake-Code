using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject leftSpikes;
    public GameObject rightSpikes;
    public GameObject bottomSpikes;

    public GameObject leftSpikesWarning;
    public GameObject rightSpikesWarning;
    public GameObject bottomSpikesWarning;
    public GameObject bottomSpikesWarning2;

    public float timeInterval = 2.0f; // Time between generating random attacks
    private float randomNumber;
    private bool isAttacking;

    public Transform projectileSpawnPoint; // Reference to the spawn point on the boss
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float fireRate = 2.0f; // Time between projectile launches (seconds)
    public float projectileSpeed = 10.0f; // Speed of the projectile

    private float lastShotTime = Mathf.NegativeInfinity; // Tracks time of last projectile launch

    void Start()
    {
        StartCoroutine(GenerateRandomNumberCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) || randomNumber == 1 && !isAttacking)
        {
            Debug.Log("Attack 1");
            isAttacking = true;
            leftSpikesWarning.SetActive(true);
            StartCoroutine(attack1Start());
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || randomNumber == 2 && !isAttacking)
        {
            Debug.Log("Attack 2");
            isAttacking = true;
            rightSpikesWarning.SetActive(true);
            StartCoroutine(attack2Start());
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) || randomNumber == 3 && !isAttacking)
        {
            Debug.Log("Attack 3");
            isAttacking = true;
            bottomSpikesWarning.SetActive(true);
            bottomSpikesWarning2.SetActive(true);
            StartCoroutine(attack3Start());
        }
        else if (Time.time - lastShotTime >= fireRate) // Check if enough time has passed between shots
        {
            Debug.Log("Attack 4");
            FireProjectile();
            lastShotTime = Time.time; // Update last shot time
        }
    }

    IEnumerator GenerateRandomNumberCoroutine()
    {
        while (true) // Loop forever
        {
            randomNumber = Random.Range(0, 4); // Generate random number between 0 and 4 (1, 2, or 3)
            Debug.Log("Generated random attack: " + randomNumber); // Print to console
            yield return new WaitForSeconds(timeInterval); // Wait for 1 second
        }
    }

    IEnumerator attack1Start()
    {
        yield return new WaitForSeconds(.75f); // Wait for .75 seconds
        leftSpikesWarning.SetActive(false);
        leftSpikes.SetActive(true);
        StartCoroutine(attack1Deactivate());
    }
    IEnumerator attack2Start()
    {
        yield return new WaitForSeconds(.75f); // Wait for .75 seconds
        rightSpikesWarning.SetActive(false);
        rightSpikes.SetActive(true);
        StartCoroutine(attack2Deactivate());
    }
    IEnumerator attack3Start()
    {
        yield return new WaitForSeconds(.75f); // Wait for .75 seconds
        bottomSpikesWarning.SetActive(false);
        bottomSpikesWarning2.SetActive(false);
        bottomSpikes.SetActive(true);
        StartCoroutine(attack3Deactivate());
    }

    IEnumerator attack1Deactivate()
    {
        yield return new WaitForSeconds(.5f); // Wait for .5 seconds
        leftSpikes.SetActive(false);
        isAttacking = false;
    }
    IEnumerator attack2Deactivate()
    {
        yield return new WaitForSeconds(.5f); // Wait for .5 seconds
        rightSpikes.SetActive(false);
        isAttacking = false;
    }
    IEnumerator attack3Deactivate()
    {
        yield return new WaitForSeconds(.5f); // Wait for .5 seconds
        bottomSpikes.SetActive(false);
        isAttacking = false;
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized * projectileSpeed;

        // Make projectile point towards player
        projectile.transform.up = (GameObject.FindGameObjectWithTag("Player").transform.position - projectile.transform.position).normalized;
    }
}