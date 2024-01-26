using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cannonballPrefab;
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private float cannonballSpeed = 5.0f;

    void Start()
    {
        InvokeRepeating("SpawnCannonball", 2f, spawnInterval);
    }

    void SpawnCannonball()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
        Vector2 moveDirection = (Vector2.zero - (Vector2)cannonball.transform.position).normalized;

        // Set the velocity based on the direction and speed
        rb.velocity = moveDirection * cannonballSpeed;
    }

    Vector2 GetRandomSpawnPosition()
    {
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // Randomly choose between left and right spawn points
        float spawnX = Random.Range(0f, 1f) > 0.5f ?
            Random.Range(Camera.main.transform.position.x - cameraWidth - 2f, Camera.main.transform.position.x - cameraWidth - 1f) :
            Random.Range(Camera.main.transform.position.x + cameraWidth + 1f, Camera.main.transform.position.x + cameraWidth + 2f);

        float spawnY = Random.Range(Camera.main.transform.position.y - cameraHeight - 2f,
                                    Camera.main.transform.position.y + cameraHeight + 2f);

        return new Vector2(spawnX, spawnY);
    }
}
