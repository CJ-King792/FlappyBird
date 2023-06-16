using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _gameOverCanvas;
    public static GameManager instance;

    private State state;

     private enum State
    {
        Scene1,
        Scene2,
        Scene3,
        Scene4,
        Scene5

    }

       private void Start()
    {
        if (instance == null) 
        {
            instance = this;
        }

        Time.timeScale = 1f;
    }

      private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex; 
        switch (state)
        {
            default:
            case State.Scene1:
            if (buildIndex == 2)
            {
               state = State.Scene2; 
            }
            if (buildIndex == 3)
            {
               state = State.Scene3; 
            }
            if (buildIndex == 4)
            {
               state = State.Scene4; 
            }
            if (buildIndex == 5)
            {
               state = State.Scene5; 
            }
            break;
            case State.Scene2:
             if (buildIndex == 1)
            {
               state = State.Scene1; 
            }
            if (buildIndex == 3)
            {
               state = State.Scene3; 
            }
            if (buildIndex == 4)
            {
               state = State.Scene4; 
            }
            if (buildIndex == 5)
            {
               state = State.Scene5; 
            }
            break;
             case State.Scene3:
             if (buildIndex == 1)
            {
               state = State.Scene1; 
            }
            if (buildIndex == 2)
            {
               state = State.Scene2; 
            }
            if (buildIndex == 4)
            {
               state = State.Scene4; 
            }
            if (buildIndex == 5)
            {
               state = State.Scene5; 
            }
            break;
             case State.Scene4:
             if (buildIndex == 1)
            {
               state = State.Scene1; 
            }
            if (buildIndex == 3)
            {
               state = State.Scene3; 
            }
            if (buildIndex == 2)
            {
               state = State.Scene2; 
            }
            if (buildIndex == 5)
            {
               state = State.Scene5; 
            }
            break;
            case State.Scene5:
             if (buildIndex == 1)
            {
               state = State.Scene1; 
            }
            if (buildIndex == 3)
            {
               state = State.Scene3; 
            }
            if (buildIndex == 2)
            {
               state = State.Scene2; 
            }
            if (buildIndex == 4)
            {
               state = State.Scene4; 
            }
            break;
        }
    }


    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        if (state == State.Scene1) 
        {
            SceneManager.LoadScene(1);
        }
        if (state == State.Scene2)
        {
            SceneManager.LoadScene(2);
        }
        if (state == State.Scene3)
        {
            SceneManager.LoadScene(3);
        }
        if (state == State.Scene4)
        {
            SceneManager.LoadScene(4);
        }
         if (state == State.Scene5)
        {
            SceneManager.LoadScene(5);
        }
    }
    

    public void GoToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        Time.timeScale = 1f;
    }
}