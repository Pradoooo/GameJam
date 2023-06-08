using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform telaGameOver;
    public Transform pauseMenu;
    public int totalLeite;
    public Text leiteText;
    


    public static GameManager instance;

    void Start()
    {
        instance = this;
    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void GameOver()
    {
        telaGameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        telaGameOver.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Pause()
    {
        if (pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ResumeMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateLeiteText()
    {
        leiteText.text = "x " + totalLeite.ToString();
    }
}
