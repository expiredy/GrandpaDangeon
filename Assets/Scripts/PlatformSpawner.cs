using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private int children;
    public float minDistance = 5f;
    private void Start()
    {
        children = transform.childCount;
    }

    bool CanSpawn()
    {
        Transform square;
        for (int i = 0; i < children; ++i)
        {
            square = transform.GetChild(i);
            //    Ray2D ray = new Ray2D(square.position, transform.right);
           // RaycastHit2D hit = Physics2D.Raycast(square.position, transform.right, 20f);
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
            Debug.DrawRay(square.position, transform.right, Color.green);
            if (closestValidHit.distance < minDistance)
                return false;
        }

        return true;
    }
}