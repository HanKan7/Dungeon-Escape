using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public DoorData[] doors;
    public bool closeOnTrigger = true;
    public bool disabled = false;

    public void DoorClose()
    {
        foreach (DoorData door in doors)
            door.t.rotation = Quaternion.Euler(door.closeAngle);
    }
    public void DoorOpen()
    {
        foreach (DoorData door in doors)
            door.t.rotation = Quaternion.Euler(door.openAngle);
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
