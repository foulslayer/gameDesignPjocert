using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnMananger : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Transform _spawnPoint;

    void Awake()
    {
        SceneManager.sceneLoaded += SpawnPlayer;
    }

  

    private void SpawnPlayer(Scene arg0, LoadSceneMode arg1)
    {
     _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
    var clone = Instantiate(_player,_spawnPoint.position,quaternion.identity);    
    }
}
