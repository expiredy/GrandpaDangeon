using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public float minDistance = 5f;
    public int maxPlatformCount = 4;
    public float cameraWidth, cameraHeight;
    
    private List<GameObject> usedPlatforms;
    
    private void Awake()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;
        usedPlatforms = new List<GameObject>();
    }
    private void Update()
    {
        int rand = Random.Range(0, platformPrefabs.Length);
        GameObject platform = platformPrefabs[rand];
        int iterations = 0, failedToSpawn = 0;
        while (usedPlatforms.Count < maxPlatformCount && failedToSpawn < platformPrefabs.Length)
        {
            float rand_x = Random.Range(-cameraWidth, cameraWidth + 1);
            float rand_y = Random.Range(-cameraHeight, cameraHeight + 1);
            platform.transform.position = new Vector3(rand_x, rand_y, 0);
            if (CanSpawn(platform))
            {
                usedPlatforms.Add(platform);
                Instantiate(platform);
                //while (usedPlatforms.Contains(platformPrefabs[rand]))
               // {
                    rand = Random.Range(0, platformPrefabs.Length);
              //  }
                platform = platformPrefabs[rand];
                continue;
            }
            ++iterations;
            if (iterations >= 100)
            {
                ++failedToSpawn;
                iterations = 0;
                usedPlatforms.Add(platform);
               // while (platform == platformPrefabs[rand])
              //  {
                    rand = Random.Range(0, platformPrefabs.Length);
               // }
                platform = platformPrefabs[rand];
            }
        }
    }

    bool CanSpawn(GameObject platform)
    {
        Transform square;
        for (int i = 0; i < platform.transform.childCount; ++i)
        {
            square = platform.transform.GetChild(i);
            if (square.transform.position.x - square.transform.localScale.x < -cameraWidth ||
                square.transform.position.x + square.transform.localScale.x > cameraWidth ||
                square.transform.position.y - square.transform.localScale.y < -cameraHeight ||
                square.transform.position.y + square.transform.localScale.y > cameraHeight)
            {
                return false;
            }
            RaycastHit2D closestValidHit = new RaycastHit2D();
            RaycastHit2D[] hits = Physics2D.RaycastAll(square.position, new Vector2(1, 0));
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.collider.CompareTag("Environment") && !hit.transform.IsChildOf(transform) && (closestValidHit.collider == null || closestValidHit.distance > hit.distance))
                {
                    closestValidHit = hit;
                    break;
                }  
            }
            if (closestValidHit.distance < minDistance)
                return false;
            closestValidHit = new RaycastHit2D();
            hits = Physics2D.RaycastAll(square.position, new Vector2(-1, 0));
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.collider.CompareTag("Environment") && !hit.transform.IsChildOf(transform) && (closestValidHit.collider == null || closestValidHit.distance > hit.distance))
                {
                    closestValidHit = hit;
                    break;
                }  
            }
            if (closestValidHit.distance < minDistance)
                return false;
            closestValidHit = new RaycastHit2D();
            hits = Physics2D.RaycastAll(square.position, new Vector2(0, 1));
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.collider.CompareTag("Environment") && !hit.transform.IsChildOf(transform) && (closestValidHit.collider == null || closestValidHit.distance > hit.distance))
                {
                    closestValidHit = hit;
                    break;
                }  
            }
            if (closestValidHit.distance < minDistance)
                return false;
            closestValidHit = new RaycastHit2D();
            hits = Physics2D.RaycastAll(square.position, new Vector2(0, -1));
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.collider.CompareTag("Environment") && !hit.transform.IsChildOf(transform) && (closestValidHit.collider == null || closestValidHit.distance > hit.distance))
                {
                    closestValidHit = hit;
                    break;
                }  
            }
            if (closestValidHit.distance < minDistance)
                return false;
            closestValidHit = new RaycastHit2D();
            hits = Physics2D.RaycastAll(square.position, new Vector2(1, 1));
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.collider.CompareTag("Environment") && !hit.transform.IsChildOf(transform) && (closestValidHit.collider == null || closestValidHit.distance > hit.distance))
                {
                    closestValidHit = hit;
                    break;
                }  
            }
            if (closestValidHit.distance < minDistance)
                return false;
            closestValidHit = new RaycastHit2D();
            hits = Physics2D.RaycastAll(square.position, new Vector2(-1, -1));
            foreach(RaycastHit2D hit in hits)
            {
                if(hit.collider.CompareTag("Environment") && !hit.transform.IsChildOf(transform) && (closestValidHit.collider == null || closestValidHit.distance > hit.distance))
                {
                    closestValidHit = hit;
                    break;
                }  
            }
            if (closestValidHit.distance < minDistance)
                return false;
        }

        return true;
    }
}