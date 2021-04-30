using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectangleWall : MonoBehaviour,IDamagable
{

    [SerializeField]
    private int health;

    private ParticleSystem particleSystem;
    private Image renderer;
    private PolygonCollider2D collider;
    public int Health { get; set; }

    private void Start()
    {
        Health = health;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        renderer = GetComponent<Image>();
        collider = GetComponent<PolygonCollider2D>();
    }
    public void Damage()
    {
        Health--;

        if (Health < 1)
        {
            StartCoroutine(BreakObject());
        }
    }

    IEnumerator BreakObject()
    {
        particleSystem.Play();
        renderer.enabled = false;
        collider.enabled = false;
        FindObjectOfType<AudioManager>().Play("Break");
        yield return new WaitForSeconds(particleSystem.main.startLifetime.constantMax);
        Destroy(this.gameObject);
    }
}
