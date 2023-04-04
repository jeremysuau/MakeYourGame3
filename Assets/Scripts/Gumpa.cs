using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumpa : MonoBehaviour
{
    public  GameObject gfx;
    public ParticleSystem particles;


    public void Die()
    {
        gfx.SetActive(false);
        particles.Play();
        Destroy(gameObject,1);
    }
}
