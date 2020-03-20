using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int playerHealth = 5;
    public Text heathText;
    public AudioClip baseReached;
    AudioSource aSource;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        heathText.text = playerHealth.ToString();
    }
void OnTriggerEnter(Collider other)
    {
        playerHealth--;
        heathText.text = playerHealth.ToString();
        aSource.PlayOneShot(baseReached);
        if (playerHealth <= 0)
        {
            print("YOU SUCKS");
        }
    }
}
