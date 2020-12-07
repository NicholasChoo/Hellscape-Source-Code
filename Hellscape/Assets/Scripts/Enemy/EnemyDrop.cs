using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject[] itemDrops;
    private int random;
    private int random2;

    public void Drops()
    {
        random = Random.Range(0, 10);

        if (random == 1)
        {
            random2 = Random.Range(0, itemDrops.Length);
            Instantiate(itemDrops[random2], transform.position, Quaternion.identity);
        }
    }
}
