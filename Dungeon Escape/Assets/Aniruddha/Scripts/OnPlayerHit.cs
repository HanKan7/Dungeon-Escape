using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aniruddha.AI.Combat
{
    public class OnPlayerHit : MonoBehaviour
    {
        public PlayerStats playerStats;
        public AudioClip hitSound;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hit by " + other.name);
            if(other.transform.root.CompareTag("AI"))
            {
                playerStats.TakeDamage(20);
                if(audioSource)
                {
                    audioSource.PlayOneShot(hitSound);
                }
            }
        }
    }
}