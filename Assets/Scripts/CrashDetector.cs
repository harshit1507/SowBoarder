using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float reloadSceneDelay = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!FindObjectOfType<PlayerController>().IsDead() && gameObject.GetComponent<CircleCollider2D>().IsTouching(other.collider))
        {
            Debug.Log("Game Over!!!");
            FindObjectOfType<PlayerController>().SetIsDead(true);
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            crashEffect.Play();
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(reloadSceneDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
