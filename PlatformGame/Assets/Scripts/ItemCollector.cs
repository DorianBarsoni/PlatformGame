using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    [SerializeField] AudioSource collectingSound;

    [SerializeField] Text coinsText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinsText.text = "Coins : " + ++coins;
            collectingSound.Play();
        }
    }
}
