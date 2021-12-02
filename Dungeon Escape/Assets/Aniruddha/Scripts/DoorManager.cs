using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public DoorData[] doors;
    public bool closeOnTrigger = true;
    public bool disabled = false;
    public AudioClip doorCloseSound, doorOpenSound;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void DoorClose()
    {
        foreach (DoorData door in doors)
            door.t.rotation = Quaternion.Euler(door.closeAngle);
        source.PlayOneShot(doorCloseSound);
    }
    public void DoorOpen()
    {
        foreach (DoorData door in doors)
            door.t.rotation = Quaternion.Euler(door.openAngle);
        source.PlayOneShot(doorOpenSound);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!disabled)
            {
                if (closeOnTrigger)
                    DoorClose();
                else
                    DoorOpen();
                disabled = true;
            }
        }
    }
}
