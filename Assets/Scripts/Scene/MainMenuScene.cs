using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene(1);
    }
}
