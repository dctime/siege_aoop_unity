using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakEffect : MonoBehaviour
{
    [SerializeField]
    ParticleSystem thisParticleSystem;

    public void Break()
    {
        if (gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            thisParticleSystem.Play();
        }
        
    }
}
