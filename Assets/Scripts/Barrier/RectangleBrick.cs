using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectangleBrick : MonoBehaviour
{
    [SerializeField]
    private int health;

    private ParticleSystem particleSystem;
    private Image renderer;
    private PolygonCollider2D collider;

    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        renderer = GetComponent<Image>();
        collider = GetComponent<PolygonCollider2D>();
    }

}
