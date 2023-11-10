using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    [SerializeField] private GameObject boss;
    [SerializeField] private float enemiesPerSecond;
    [SerializeField] private float BossPerSecond;
    [SerializeField] private float r;

    private Transform player;
    private float timeSinceLastSpawn = 0;
    private float timeSinceLastSpawnBoss = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate ()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond)) 
        {
            float a = Random.Range(0, 2 * Mathf.PI);
            float x = r * Mathf.Cos(a) + player.position.x;
            float y = r * Mathf.Sin(a) + player.position.y;
            Vector2 spawn = new Vector2(x, y);
            switch (Random.Range(0, 3)) 
            {
                case 0:
                    Instantiate(enemy1, spawn, Quaternion.Euler(0, 0, 0));
                    break;
                case 1:
                    Instantiate(enemy2, spawn, Quaternion.Euler(0, 0, 0));
                    break;
                case 2:
                    Instantiate(enemy3, spawn, Quaternion.Euler(0, 0, 0));
                    break;

            }
            timeSinceLastSpawn = 0;
        }

        timeSinceLastSpawnBoss += Time.deltaTime;
        if (timeSinceLastSpawnBoss >= (1f / BossPerSecond))
        {
            float a = Random.Range(0, 2 * Mathf.PI);
            float x = r * Mathf.Cos(a) + player.position.x;
            float y = r * Mathf.Sin(a) + player.position.y;
            Vector2 spawn = new Vector2(x, y);
            Instantiate(boss, spawn, Quaternion.Euler(0, 0, 0));
            timeSinceLastSpawnBoss = 0;
        }
    }
}
