using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{

    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip crashSFX;
    bool hasCrash = false;

    private void Start()
    {
        hasCrash = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if (!hasCrash)
            {
                hasCrash = true;
                GetComponent<PlayerController>().DisableControls();
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                Invoke("ReloadScene", delayTime);

            }
            
        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
