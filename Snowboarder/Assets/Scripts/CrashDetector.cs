using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] AudioSource audioSource;
    [SerializeField] SurfaceEffector2D surfaceEffector2D;

    PlayerController playerController;

    public bool crashFlag;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        crashFlag = false;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground" && !crashFlag)
        {
            Debug.Log("Crash!");
            crashParticle.Play();
            audioSource.Play();
            crashFlag = true;
            playerController.enabled = false;
            surfaceEffector2D.speed = 0;
            Invoke("ReloadScene", reloadDelay);
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
