using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; //생성할 발판의 원본 프리팹
    public int count = 3; // 생성할 발판의 수

    public float timeBetSpawnMin = 1.24f; // 다음 배치까지의 시간 간격 최솟값
    public float timeBetSpawnMax = 2.25f; // 다음 배치까지의 시간 최댓값
    private float timeBetSpawn; // 다음 배치까지의 시간 간격

    public float ymin = -3.5f; // 배치할 위치의 최소 y 값
    public float yMax = 1.5f; // 
    private float xPos = 20f; 

    private GameObject[] platforms;
    private int currentIndex = 0;

    private Vector2 poolPOsition = new Vector2(0, 25);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPOsition, Quaternion.identity);
        }
        lastSpawnTime = 0f;

        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(ymin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
