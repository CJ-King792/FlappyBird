using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class FlyBehavior : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    private static FlyBehavior instance;
    
    public static FlyBehavior GetInstance() {
        return instance;
    }

    public AudioSource source1;
    public AudioSource source2;
    public event EventHandler OnDied;
    public event EventHandler OnStartedPlaying;
    private Rigidbody2D _rb;
    private State state;
    private enum State 
    {
        WaitingToStart,
        Playing,
        Dead
    }

    private void Awake() 
    {
        instance = this;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Static;
        state = State.WaitingToStart;
   }

   private void Update()
   {
    switch (state) {
        default:
        case State.WaitingToStart:
        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex; 
        if (buildIndex == 0) 
        {
            state = State.WaitingToStart;
        }
        else if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            if (OnStartedPlaying != null) OnStartedPlaying(this, EventArgs.Empty);
            state = State.Playing;
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.velocity = Vector2.up * _velocity;
            source1.Play();
        }
        break;
        case State.Playing:
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {   
            source1.Play();
            _rb.velocity = Vector2.up * _velocity;
        }
        break;
        case State.Dead:
        break;
        }
        }
       private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        state = State.Dead;
        GameManager.instance.GameOver();
        if (OnDied != null) OnDied(this, EventArgs.Empty);
        source2.Play();
    }
}