using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform telaGameOver;
    public Transform pauseMenu;
    public int totalLeite;
    [SerializeField] private TMPro.TextMeshProUGUI leiteText;


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

    public void UpdateLeiteText()
    {
        leiteText.text = totalLeite.ToString();
    }
}
