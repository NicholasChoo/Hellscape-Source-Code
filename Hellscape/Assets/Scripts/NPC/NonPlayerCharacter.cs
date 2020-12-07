using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public static bool npcDialogue = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        npcDialogue = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        npcDialogue = false;
    }
}
