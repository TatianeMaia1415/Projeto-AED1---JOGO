using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public AudioSource musicaDoJogo;
    public AudioSource musicaDeGameOver;
    public GameObject painelDeGameOver;
    public TextMeshProUGUI textoDePontuacaoFinal;
    public TextMeshProUGUI textoDeHighScore;
    public static GameManager instance;

    public TextMeshProUGUI textoDePontuacaoAtual;



    public int pontuacaoAtual;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        musicaDoJogo.Play();

        pontuacaoAtual = 0;
        textoDePontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AumentarPontuacao(int pontosParaGanhar)
    {
        pontuacaoAtual += pontosParaGanhar;
        textoDePontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }

    public void GameOver()
    { 
        Time.timeScale = 0f;
        musicaDoJogo.Stop();
        musicaDeGameOver.Play();
        painelDeGameOver.SetActive(true);
        textoDePontuacaoFinal.text = "PONTUAÇÃO: " + pontuacaoAtual;

        if(pontuacaoAtual > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", pontuacaoAtual);
        }

        textoDeHighScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");
    }

}
