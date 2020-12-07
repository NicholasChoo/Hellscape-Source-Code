using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //0 start
    //1 up
    //2 down
    //3 left
    //4 right

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    public float waitTime = 2f;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (templates.rooms.Count < (templates.maxRooms - 7))
            {
                if (openingDirection == 0)
                {
                    rand = Random.Range(0, templates.startRooms.Length);
                    Instantiate(templates.startRooms[rand], transform.position, templates.startRooms[rand].transform.rotation);
                }
                else if (openingDirection == 1)
                {
                    if (templates.spawnedMiniBoss == false)
                    {
                        Instantiate(templates.miniBoss, transform.position, Quaternion.identity);
                        templates.spawnedMiniBoss = true;
                    }
                    else
                    {
                        rand = Random.Range(0, templates.topRooms.Length);
                        Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    }
                }
                else if (openingDirection == 2)
                {
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                }
                else if (openingDirection == 3)
                {
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                }
                else if (openingDirection == 4)
                {
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                }
                spawned = true;
            }
            else
            {
                if (openingDirection == 1)
                {
                    if (templates.spawnedMiniBoss == false)
                    {
                        Instantiate(templates.miniBoss, transform.position, Quaternion.identity);
                        templates.spawnedMiniBoss = true;
                    }
                    else
                    {
                        rand = Random.Range(0, templates.endTopRooms.Length);
                        Instantiate(templates.endTopRooms[rand], transform.position, templates.endTopRooms[rand].transform.rotation);
                    }
                }
                else if (openingDirection == 2)
                {
                    rand = Random.Range(0, templates.endBottomRooms.Length);
                    Instantiate(templates.endBottomRooms[rand], transform.position, templates.endBottomRooms[rand].transform.rotation);
                }
                else if (openingDirection == 3)
                {
                    rand = Random.Range(0, templates.endLeftRooms.Length);
                    Instantiate(templates.endLeftRooms[rand], transform.position, templates.endLeftRooms[rand].transform.rotation);
                }
                else if (openingDirection == 4)
                {
                    rand = Random.Range(0, templates.endRightRooms.Length);
                    Instantiate(templates.endRightRooms[rand], transform.position, templates.endRightRooms[rand].transform.rotation);
                }
                spawned = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
