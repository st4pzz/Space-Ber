using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGroundController : MonoBehaviour
{

    public float timeToDisappear = 3f; // Tempo em segundos para o chão desaparecer
    private float timer = 0f; // Temporizador para a contagem
    private bool playerOnTop = false; // Se o jogador está sobre o chão

    private void Update()
    {
        if (playerOnTop)
        {
            timer += Time.deltaTime;
            if (timer >= timeToDisappear)
            {
                // Código para fazer o chão desaparecer
                gameObject.SetActive(false);
            }
        }
        else
        {
            // Resetar o temporizador se o jogador sair do chão
            timer = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnTop = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Verifica novamente se é o jogador que está saindo
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnTop = false;
        }
    }
}
