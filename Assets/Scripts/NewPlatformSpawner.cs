using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewPlatformSpawner : MonoBehaviour
{
    public float cameraWidth, cameraHeight;
    public GameObject chunkPrefab;
    public int maxPlatformCount = 5;
    public int minDistance = 2;
    public int maxDistance = 5;
    public int minSize = 2, maxSize = 5;
    public int matrixSize = 18;
    public int[,] matrix;

    private void Awake()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;

        matrix = new int[matrixSize, matrixSize];
        for (int i = 0; i < matrixSize; ++i)
        {
            for (int j = 0; j < matrixSize; ++j)
            {
                if (i == 0 || i == matrixSize - 1 || j == 0 || j == matrixSize - 1)
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
        while (spawnedCount < maxPlatformCount)
        {
            int randX = Random.Range(1, matrixSize - 1);
            int randY = Random.Range(1, matrixSize - 1);
            int size = Random.Range(minSize, maxSize);
            bool canSpawn = true;
            bool foundPlatform = false;
            for (int x = Math.Max(0, randX - maxDistance); canSpawn && x < randX + size + maxDistance && x < matrixSize; ++x)
            {
                if (x > randX + minDistance || x < randX - minDistance)
                {
                    if (matrix[x, randY] == 1)
                    {
                        foundPlatform = true;
                    }
                }
                else if (matrix[x, randY] == 1)
                {
                    canSpawn = false;
                    break;
                }

                for (int y = Math.Max(0, randY - maxDistance); y < randY + size + maxDistance && y < matrixSize; ++y)
                {
                    if (x > randX + minDistance || x < randX - minDistance || y > randY + minDistance || y < randY - minDistance)
                    {
                        if (matrix[x, y] == 1)
                        {
                            foundPlatform = true;
                        }
                    }
                    else if (matrix[x, y] == 1)
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
                for (int x = randX; x < randX + size && x < matrixSize; ++x)
                {
                    matrix[x, randY] = 1;
                }
            }
        }

        for (int i = 0; i < matrixSize; ++i)
        {
            for (int j = 0; j < matrixSize; ++j)
            {
                if (matrix[i, j] == 1)
                {
                    var localScale = chunkPrefab.transform.localScale;
                    Instantiate(chunkPrefab,
                        new Vector3(-cameraWidth + j * localScale.x, cameraHeight - i * localScale.y, 0),
                        new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}