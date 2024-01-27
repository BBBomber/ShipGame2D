using System.Collections;
using UnityEngine;

public class CannonballSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cannonballPrefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float cannonballSpeed = 5.0f;

    private float speedIncreaseTimer = 0f;
    [SerializeField] private float speedIncreaseInterval = 15f;

    void Start()
    {
        InvokeRepeating("SpawnCannonball", 2f, spawnInterval);
    }

    void Update()
    {
        // Update the timer
        speedIncreaseTimer += Time.deltaTime;

        if (speedIncreaseTimer >= speedIncreaseInterval)
        {
            // Increase cannonball speed by 1
            cannonballSpeed += 1.0f;

            if(spawnInterval > 0.1f)
            {
                spawnInterval -= 0.1f;
            }
            // Reset the timer
            speedIncreaseTimer = 0f;
        }
    }

    void SpawnCannonball()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        SoundManager.Instance.Play(Sounds.cannon);
        // Movement
        StartCoroutine(MoveCannonball(cannonball.transform, cannonballSpeed));
    }

    IEnumerator MoveCannonball(Transform cannonballTransform, float speed)
    {
        Vector2 moveDirection = (Vector2.zero - (Vector2)cannonballTransform.position).normalized;

        while (cannonballTransform != null)
        {
            cannonballTransform.Translate(moveDirection * speed * Time.deltaTime);

            if (cannonballTransform == null)
            {
                yield break;
            }

            yield return null;
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        float spawnX, spawnY;

        // Randomly choose between top, bottom, left, and right spawn points
        float randomValue = Random.value;

        if (randomValue < 0.25f) // 25% chance for top spawn
        {
            spawnX = Random.Range(Camera.main.transform.position.x - cameraWidth, Camera.main.transform.position.x + cameraWidth);
            spawnY = Camera.main.transform.position.y + cameraHeight + Random.Range(1f, 2f);
        }
        else if (randomValue < 0.5f) // bottom spawn
        {
            spawnX = Random.Range(Camera.main.transform.position.x - cameraWidth, Camera.main.transform.position.x + cameraWidth);
            spawnY = Camera.main.transform.position.y - cameraHeight - Random.Range(1f, 2f);
        }
        else if (randomValue < 0.75f) //left spawn
        {
            spawnX = Camera.main.transform.position.x - cameraWidth - Random.Range(1f, 2f);
            spawnY = Random.Range(Camera.main.transform.position.y - cameraHeight, Camera.main.transform.position.y + cameraHeight);
        }
        else //  right spawn
        {
            spawnX = Camera.main.transform.position.x + cameraWidth + Random.Range(1f, 2f);
            spawnY = Random.Range(Camera.main.transform.position.y - cameraHeight, Camera.main.transform.position.y + cameraHeight);
        }

        return new Vector2(spawnX, spawnY);
    }
}