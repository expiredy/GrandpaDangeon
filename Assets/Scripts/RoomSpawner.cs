using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    // 1 --> bottom
    // 2 --> top
    // 3 --> left
    // 4 --> right

    private RoomTemplates _templates;
    private int rand;
    public bool spawned;

    private void Start()
    {
        _templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .1f);
    }
    private void Spawn()
    {
        if (spawned)
            return;
        if (openingDirection == 1)
        {
            rand = Random.Range(0, _templates.bottomRooms.Length);
            if (_templates.maxRooms < _templates.rooms.Count)
            {
                rand = 0;
            }
            Instantiate(_templates.bottomRooms[rand], transform.position, _templates.bottomRooms[rand].transform.rotation);
        }
        else if (openingDirection == 2)
        {
            rand = Random.Range(0, _templates.topRooms.Length);
            if (_templates.maxRooms < _templates.rooms.Count)
            {
                rand = 0;
            }
            Instantiate(_templates.topRooms[rand], transform.position, _templates.topRooms[rand].transform.rotation);
        }
        else if (openingDirection == 3)
        {
            rand = Random.Range(0, _templates.leftRooms.Length);
            if (_templates.maxRooms < _templates.rooms.Count)
            {
                rand = 0;
            }
            Instantiate(_templates.leftRooms[rand], transform.position, _templates.leftRooms[rand].transform.rotation);
        }
        else if (openingDirection == 4)
        {
            rand = Random.Range(0, _templates.rightRooms.Length);
            if (_templates.maxRooms < _templates.rooms.Count)
            {
                rand = 0;
            }
            Instantiate(_templates.rightRooms[rand], transform.position, _templates.rightRooms[rand].transform.rotation);
        }

        spawned = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}