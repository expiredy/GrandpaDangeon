using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewPlatformSpawner : MonoBehaviour
{
    public float cameraWidth, cameraHeight;
    public GameObject chunkPrefab;
    public Sprite chunkCleanSprite;
    public int maxPlatformCount = 5;
    public int minDistance = 2;
    public int maxDistance = 5;
    public int minSize = 2, maxSize = 5;
    public int matrixSizeX = 18, matrixSizeY = 10;
    public int[,] matrix;

    private void Awake()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;

        matrix = new int[matrixSizeY, matrixSizeX];
        for (int i = 0; i < matrixSizeY; ++i)
        {
            for (int j = 0; j < matrixSizeX; ++j)
            {
                if (i == 0 || i == matrixSizeY - 1 || j == 0 || j == matrixSizeX - 1)
                {
                    matrix[i, j] = 1;
                }
                else
                {
                    matrix[i, j] = 0;
                }
            }
        }

        int spawnedCount = 0;
        int failedIterations = 0;
        while (spawnedCount < maxPlatformCount)
        {
            int randX = Random.Range(1, matrixSizeX - 1);
            int randY = Random.Range(1, matrixSizeY - 1);
            int size = Random.Range(minSize, maxSize + 1);
            bool canSpawn = true;
            bool foundPlatform = false;
            for (int x = Math.Max(0, randX - maxDistance); canSpawn && x < Math.Min(randX + size + maxDistance, matrixSizeX); ++x)
            {
                if (x > randX + size + minDistance || x < randX - minDistance)
                {
                    if (matrix[randY, x] == 1)
                    {
                        foundPlatform = true;
                    }
                }
                else if (matrix[randY, x] == 1)
                {
                    canSpawn = false;
                    break;
                }

                for (int y = Math.Max(0, randY - maxDistance); y < Math.Min(randY + maxDistance, matrixSizeY); ++y)
                {
                    if ((x > randX + size + minDistance || x < randX - minDistance) || (y > randY + minDistance || y < randY - minDistance))
                    {
                        if (matrix[y, x] == 1)
                        {
                            foundPlatform = true;
                        }
                    }
                    else if (matrix[y, x] == 1)
                    {
                        canSpawn = false;
                        break;
                    }
                }
            }

            if (!foundPlatform)
            {
                canSpawn = false;
            }

            if (canSpawn)
            {
                ++spawnedCount;
                for (int x = randX; x < randX + size && x < matrixSizeX; ++x)
                {
                    matrix[randY, x] = 1;
                }
            }
            else
            {
                ++failedIterations;
            }

            if (failedIterations >= 100)
            {
                break;
            }
        }

        for (int i = 0; i < matrixSizeY; ++i)
        {
            for (int j = 0; j < matrixSizeX; ++j)
            {
                if (matrix[i, j] == 1)
                {
                    var localScale = chunkPrefab.transform.localScale;
                    GameObject chunk = Instantiate(chunkPrefab,
                        new Vector3(-cameraWidth + j * localScale.x, cameraHeight - i * localScale.y, 0),
                        new Quaternion(0, 0, 0, 0));
                    if (i > 0 && matrix[i - 1, j] == 1 && chunkCleanSprite != null)
                    {
                        chunk.transform.Find("Square").GetComponent<SpriteRenderer>().sprite = chunkCleanSprite;
                    }
                }
            }
        }
    }
}