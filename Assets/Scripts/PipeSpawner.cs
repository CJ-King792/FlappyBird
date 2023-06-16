using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;

    public static PipeSpawner instance;

    public static PipeSpawner GetInstance() {
        return instance;
    }

    private float _timer;
    private State state;

    private enum State {
        WaitingToStart,
        Playing,
        BirdDead
    }

    private void Awake() {
        instance = this;
        state = State.WaitingToStart;
    }

    private void Start()
    {
        FlyBehavior.GetInstance().OnDied += Bird_OnDied;
        FlyBehavior.GetInstance().OnStartedPlaying += Bird_OnStartedPlaying;
    }

    private void Bird_OnStartedPlaying(object sender, System.EventArgs e) {
        state = State.Playing;
    }

       private void Bird_OnDied(object sender, System.EventArgs e) {
        state = State.BirdDead;
    }


    private void Update()
    {
        if (state == State.Playing){
            if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;    
        }
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}