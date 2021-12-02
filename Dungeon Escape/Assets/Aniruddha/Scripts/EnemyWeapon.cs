using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aniruddha.AI.Combat
{
    public class EnemyWeapon : MonoBehaviour
    {
        public Collider collider;
        
        public void OnAttackStart()
        {
            collider.enabled = true;
        }

        public void OnAttackEnd()
        {
            collider.enabled = false;
        }
        public DoorManager dm;
        public void DefeatedKnight()
        {
            dm.DoorOpen();
        }
    }
}