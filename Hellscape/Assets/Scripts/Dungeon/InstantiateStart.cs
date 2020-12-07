using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStart : MonoBehaviour
{
    public GameObject hub;
    public GameObject player;

    public GameObject startingRoom;
    public GameObject roomTemplate;

    public void EnterDungeon()
    {
        Destroy(hub);
        player.transform.position = new Vector3(0, -5, -1.2f);
        Instantiate(startingRoom, transform.position, Quaternion.identity);
        Instantiate(roomTemplate, transform.position, Quaternion.identity);
    }
}
