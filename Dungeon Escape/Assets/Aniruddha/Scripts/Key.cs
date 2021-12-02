using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Knight;
    public DoorManager dmOpen;
    public DoorManager dmClose;
    private void OnDestroy()
    {
        Knight.SetActive(true);
        dmOpen.DoorOpen();
        dmClose.DoorClose();
    }
}
