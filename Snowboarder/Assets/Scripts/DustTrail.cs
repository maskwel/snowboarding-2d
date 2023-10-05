using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] GameObject moveParticle;
    [SerializeField] CrashDetector crashDetector;

    ParticleSystem partSystem;

    void Start()
    {
        partSystem = moveParticle.GetComponent<ParticleSystem>();
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (!crashDetector.crashFlag)
        {
            partSystem.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        partSystem.Stop();    
    }
}
