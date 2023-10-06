using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   [SerializeField] private Button _startButton;
   [SerializeField] private Button _quitButton;

   [SerializeField] private int sceneToLoadIndex;

     void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _quitButton.onClick.AddListener(QuitGame);
    }

     private void  StartGame()
    {
       SceneManager.LoadScene(1);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

   
}
