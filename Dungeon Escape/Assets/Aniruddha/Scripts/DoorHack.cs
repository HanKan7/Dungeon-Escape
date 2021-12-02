using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHack : MonoBehaviour
{
    public DoorManager dm;
    public void DefeatedKnight()
    {
        dm.DoorOpen();
    }
}
