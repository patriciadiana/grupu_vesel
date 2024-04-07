using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public GameObject character;
    public AudioClip dialogClip;
    public float triggerDistance = 2f;

    private bool dialogTriggered = false;

    private void Update()
    {
        // Verificăm dacă jucătorul se află la o distanță suficient de mică față de personaj
        float distance = Vector3.Distance(transform.position, character.transform.position);
        if (distance < triggerDistance && !dialogTriggered)
        {
            // Redăm fișierul audio asociat liniei de dialog
            AudioSource.PlayClipAtPoint(dialogClip, character.transform.position);
            // Setăm triggerul pentru dialog ca fiind activat
            dialogTriggered = true;
        }
    }
}
