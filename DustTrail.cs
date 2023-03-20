using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustTrail;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dustTrail.Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        dustTrail.Stop();
    }
}
