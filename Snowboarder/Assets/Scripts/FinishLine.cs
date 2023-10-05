using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishParticle;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float reloadDelay = 1f;

    bool finishFlag;
    void Start()
    {
        finishFlag = false;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && !finishFlag)
        {
            Debug.Log("Finish!");
            finishParticle.Play();
            audioSource.Play();
            finishFlag = true;
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
