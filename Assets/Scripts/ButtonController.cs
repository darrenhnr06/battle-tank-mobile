using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Button playAgain;

    [SerializeField]
    private Button exitGame;

    private void Awake()
    {
        playAgain.onClick.AddListener(ReloadScene);
        exitGame.onClick.AddListener(ExitScene);
    }

    void ReloadScene()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    void ExitScene()
    {
        Application.Quit();
    }

}
