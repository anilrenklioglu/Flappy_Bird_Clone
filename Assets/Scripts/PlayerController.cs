using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private AudioSource flySound;
    [SerializeField] private AudioSource deathSound;
    private Rigidbody2D _rb;
    void Start()

    {
        _rb = GetComponent<Rigidbody2D>();
        flySound = GetComponent<AudioSource>();
    }
    void Update()
    {
       Jump();
    }

    public void Jump()
    {
        if (GameManager.instance.currentState != GameManager.GameState.Playing) return;

        if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(" jump calisiyor");
                _rb.velocity = Vector2.up * jumpForce;
                flySound.Play();
            }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        deathSound.Play();
        GameManager.instance.GameOver();
        _rb.bodyType = RigidbodyType2D.Static;
        
        
    }
   
}
