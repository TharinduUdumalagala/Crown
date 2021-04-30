using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wall : Barrier, IDamagable
{

    private ParticleSystem particleSystem;
    private Vector3 _currentTarget;
    private Image renderer;
    private BoxCollider2D collider;
    public int Health { get; set; }

    private void Start()
    {
        Health = base.health;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        renderer = GetComponent<Image>();
        collider = GetComponent<BoxCollider2D>();
    }

    public override void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
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
