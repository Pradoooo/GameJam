using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mutecontroller : MonoBehaviour
{
    public Image image; // Referência para o componente Image
    public AudioSource audioSource; // Referência para o componente AudioSource
    public Sprite sprite;
    public Sprite spriteantiga;
    private bool audioEnabled = true; // Variável para controlar o estado do áudio
    private bool isNovaSpriteAtiva = false;
    private float audioposition = 0f;
    public void OnButtonPress()
    {
        isNovaSpriteAtiva = !isNovaSpriteAtiva;
        if (isNovaSpriteAtiva)
        {
            image.sprite = sprite;
        }
        else
        {
            image.sprite = spriteantiga;
        }
        if (audioEnabled)
        {
            audioEnabled = false;
            audioposition = audioSource.time;
            audioSource.Stop();
        }
        else
        {
            audioEnabled = true;
            audioSource.time = audioposition;
            audioSource.Play();
        }

        // Percorre todas as cenas carregadas
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            // Encontra todos os objetos na cena
            GameObject[] rootObjects = scene.GetRootGameObjects();

            // Ativa ou desativa o áudio em cada objeto com AudioSource
            foreach (GameObject obj in rootObjects)
            {
                AudioSource source = obj.GetComponent<AudioSource>();
                if (source != null)
                {
                    source.enabled = audioEnabled;
                }
            }
        }
    }
}


