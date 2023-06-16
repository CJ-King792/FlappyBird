using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    Score score;
   public static MainMenu instance;

    private State state;

    private enum State
    {
        Scene1,
        Scene2,
        Scene3,
        Scene4,
        Scene5

    }

        private void Awake()
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
            if (buildIndex == 3) {
                state = State.Scene3; 
            }
            if (buildIndex == 4) {
                state = State.Scene4; 
            }
            if (buildIndex == 5) {
                state = State.Scene5; 
            }
            break;
            case State.Scene2:
            if (buildIndex == 1)
            {
               state = State.Scene1; 
            }
            if (buildIndex == 3) {
                state = State.Scene3; 
            }
            if (buildIndex == 4) {
                state = State.Scene4; 
            }
            if (buildIndex == 5) {
                state = State.Scene5; 
            }
            break;
            case State.Scene3:
            if (buildIndex == 1) {
                state = State.Scene1; 
            }
            if (buildIndex == 2) {
                state = State.Scene2; 
            }
            if (buildIndex == 4) {
                state = State.Scene4; 
            }
            if (buildIndex == 5) {
                state = State.Scene5; 
            }
            break;
            case State.Scene4:
            if (buildIndex == 1) {
                state = State.Scene1; 
            }
            if (buildIndex == 2) {
                state = State.Scene2; 
            }
            if (buildIndex == 3) {
                state = State.Scene3; 
            }
            if (buildIndex == 5) {
                state = State.Scene5; 
            }
            break;
             case State.Scene5:
            if (buildIndex == 1) {
                state = State.Scene1; 
            }
            if (buildIndex == 2) {
                state = State.Scene2; 
            }
            if (buildIndex == 3) {
                state = State.Scene3; 
            }
            if (buildIndex == 4) {
                state = State.Scene4; 
            }
            break;
            
        }
    }

    public void redBird()
    {
        SceneManager.LoadScene(2);
    }

     public void purpleBird()
    {
        SceneManager.LoadScene(3);
    }

    public void seagull()
    {
        SceneManager.LoadScene(4);
    }

    public void ninjaBird()
    {
        SceneManager.LoadScene(5);
    }

     public void originalBird()
    {
        SceneManager.LoadScene(1);
    }

    public void playGame()
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

    public void QuitGame()
    {
        Application.Quit();
    }
}