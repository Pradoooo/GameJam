using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlideShow : MonoBehaviour
{
    public string[] slideTexts; // Array de textos do slideshow

    public Image[] slides; // Array de imagens do slideshow

    private int currentIndex = 0; // �ndice da imagem atual
    

    private void Start()
    {
        // Exibe a primeira imagem no in�cio
        ShowSlide(0);
    }

    private void Update()
    {
        
    }

    private void NextSlide()
    {
        // Incrementa o �ndice da imagem atual
        currentIndex++;

        // Verifica se chegou ao final do slideshow
        if (currentIndex >= slides.Length)
        {
            // Volta para o in�cio do slideshow
            SceneManager.LoadScene("Fase1");
        }

        // Exibe a pr�xima imagem
        ShowSlide(currentIndex);
    }

    private void ShowSlide(int index)
    {
        // Desativa todas as imagens
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].gameObject.SetActive(false);
        }

        // Ativa a imagem atual
        slides[index].gameObject.SetActive(true);

        if (index < slideTexts.Length)
        {
            // Define o texto correspondente
            // Supondo que voc� tenha um componente Text anexado ao objeto das imagens
            Text textComponent = slides[index].GetComponentInChildren<Text>();
            if (textComponent != null)
            {
                textComponent.text = slideTexts[index];
            }
        }
    }
    public void NextSlideButton()
    {
        NextSlide();
    }
}


