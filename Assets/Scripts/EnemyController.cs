using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public struct PositionEnemies
{
    public float startX;
    public float endX;
    public bool isLeft;
}


public class EnemyController : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;
    public int numEnemies = 10;
    public int margin = 1;
    public float delayMove;
    public List<PositionEnemies> platformObjectsPositions = new List<PositionEnemies>();
    

    void Start()
    {
        GameObject[] platformObjects = GameObject.FindGameObjectsWithTag("Platform");
        delayMove = 0.015f;
        
        // GameObject wallLeft = GameObject.Find("wallLeft");
        // GameObject wallRight = GameObject.Find("wallRight");
        // GameObject wallUp = GameObject.Find("wallUp");
        // GameObject wallDown = GameObject.Find("wallDown");
        //
        // float xStart = wallLeft.transform.position.x + wallLeft.transform.localScale.x + margin;
        // float xEnd = wallRight.transform.position.x - wallRight.transform.localScale.x - margin;
        // float yStart = wallDown.transform.position.y + wallDown.transform.localScale.y + margin;
        // float yEnd = wallUp.transform.position.y - wallUp.transform.localScale.y - margin;

        for (int i = 0; i < platformObjects.Length; i++)
        {
            // int platformIndex = Random.Range(0, platformObjects.Length);
            // usedPlatforms.Add(platformIndex);
            GameObject platform = platformObjects[i];
            GameObject prefab = enemies[Random.Range(0, enemies.Length)];

            Vector3 platformPos = platform.transform.position;
            Vector3 platformScale = platform.transform.localScale;

            float xStart = platformPos.x - platformScale.x / 2 + prefab.transform.localScale.x / 2;
            float xEnd = platformPos.x + platformScale.x / 2 - prefab.transform.localScale.x / 2;

            float yCoord = platformPos.y + platformScale.y;
            float xCoord = Random.Range(xStart, xEnd);

            PositionEnemies enemyLocalPos = new PositionEnemies
            {
                endX = xEnd,
                startX = xStart,
                isLeft = true
            };
            print(enemyLocalPos);
            platformObjectsPositions.Add(enemyLocalPos);

            Instantiate(prefab, new Vector3(x: xCoord, y: yCoord, z: 0), Quaternion.identity, transform);
        }
    }

    void FixedUpdate()
    {
        MoveEnemies();
    }

    void MoveEnemies()
    {
        GameObject[] enemiesForMove = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemiesForMove.Length; i++)
        {
            GameObject enemyLocal = enemiesForMove[i];
            PositionEnemies enemyPos = platformObjectsPositions[i];
            Vector3 oldPosition = enemyLocal.transform.position;
            float newPositionX;
            if (enemyPos.isLeft)
            {
                newPositionX = oldPosition.x - delayMove;
                if (newPositionX < enemyPos.startX)
                {
                    enemyPos.isLeft = false;
                    newPositionX = enemyPos.startX;
                }
            }
            else
            {
                newPositionX = oldPosition.x + delayMove;
                if (newPositionX > enemyPos.endX)
                {
                    enemyPos.isLeft = true;
                    newPositionX = enemyPos.endX;
                }
            }

            platformObjectsPositions[i] = enemyPos;

            Vector3 newPosition = new Vector3(newPositionX, oldPosition.y, oldPosition.z);
            enemyLocal.transform.position = newPosition;
        }
    }
}
