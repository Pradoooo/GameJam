using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timeValue;
    public Transform telaGameOver;
    public Transform pauseMenu;

    public int timeLeft;
    private float timer;


    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timeLeft--;
            timeValue.text = timeLeft.ToString();
            timer = 0;
        }

        if (timeLeft <= 0)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    void GameOver()
    {
        telaGameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
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
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
