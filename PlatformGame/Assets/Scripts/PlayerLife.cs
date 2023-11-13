using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    bool dead = false;
    [SerializeField] AudioSource deathSound;

    public void Start()
    {
        
    }

    private void Update()
    {
        if((transform.position.y < -1f) && !dead)
        {
            Die();
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
    }

    private void Die()
    {
        dead = true;
        //GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        transform.Find("/BG Music").gameObject.GetComponent<AudioSource>().Stop();
        deathSound.Play();
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
