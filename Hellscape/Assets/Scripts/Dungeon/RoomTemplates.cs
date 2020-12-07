using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] startRooms;
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] endTopRooms;
    public GameObject[] endBottomRooms;
    public GameObject[] endLeftRooms;
    public GameObject[] endRightRooms;
    [Space(16)]

    public GameObject closedRoom;
    [Space(16)]

    public GameObject miniBoss;
    public bool spawnedMiniBoss;
    [Space(16)]

    public float maxRooms;
    public List<GameObject> rooms;
    [Space(16)]

    public float waitTime;
}