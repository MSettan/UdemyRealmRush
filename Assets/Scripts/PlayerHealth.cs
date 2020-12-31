using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] private Text healthText;
    [SerializeField] private AudioClip playerHitSound;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
         GetComponent<AudioSource>().PlayOneShot(playerHitSound);
        health -= healthDecrease;
        healthText.text = health.ToString();
    }
}
