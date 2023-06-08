using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image vaca;
    public float rotationSpeed = 2f;
    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        float currentrotation = vaca.rectTransform.rotation.eulerAngles.z;
        float newrotation = currentrotation + rotationSpeed * Time.deltaTime;
        vaca.rectTransform.rotation = Quaternion.Euler(0f, 0f, newrotation);
    }
}
