using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Renderer _mainRenderer;

    private Color _originColor;
    private void Start()
    {
        _originColor = _mainRenderer.material.color;
    }
    private void OnMouseEnter()
    {
        if (!GamePlayScene.singleton._isGameStarted)
        {
            _mainRenderer.material.color = Color.yellow;
        }
    }

    private void OnMouseDown()
    {
        if (!GamePlayScene.singleton._isGameStarted)
        {
            _mainRenderer.material.color = Color.green;
            GamePlayScene.singleton.StartGame(transform.position);
        }
    }

    private void OnMouseExit()
    {
        if (!GamePlayScene.singleton._isGameStarted)
        {
            _mainRenderer.material.color = _originColor;
        }
    }
}
