using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayScene : MonoBehaviour
{
    public static GamePlayScene singleton;
    [SerializeField] private GameObject _characterObject;
    [SerializeField] private Rotator _rotatorObject;
    [SerializeField] private Text _statusText;
    public bool _isGameStarted;
    
    private void Awake()
    {
        singleton = this;
    }

    public void MoveToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame(Vector3 vPosition)
    {
        _rotatorObject.enabled = true;
        _isGameStarted = true;
        _statusText.text = "";
        GameObject go = Instantiate(_characterObject, vPosition, Quaternion.Euler(0, 90, 0));
    }

    public void StopGame()
    {
        _rotatorObject.enabled = false;
        _statusText.text = "Game Over";
        //_isGameStarted = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
