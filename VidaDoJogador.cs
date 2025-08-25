using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class VidaDoJogador : MonoBehaviour
{

    public Slider barraDeVidaDoJogador;
    public Slider barraDeEnergiaDoEscudo;

    public GameObject escudoDoJogador;

    public int vidaMaximaDoJogador;

    public int vidaAtualDoJogador;

    public int vidaAtualDoEscudo;
    public int vidaMaximaDoEscudo;

    //public int vidaAtualDoEscudo;

    public bool temEscudo;
    // Start is called before the first frame update
    void Start()
    {
        

        vidaAtualDoJogador = vidaMaximaDoJogador;

        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        barraDeVidaDoJogador.maxValue = vidaMaximaDoJogador;

        barraDeVidaDoJogador.value = vidaAtualDoJogador;

        barraDeEnergiaDoEscudo.maxValue = vidaMaximaDoEscudo;

        barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

        barraDeEnergiaDoEscudo.gameObject.SetActive(false);//desativa a barrinha de energia na hora que o jogo inicia

        escudoDoJogador.SetActive(false);

        temEscudo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarEscudo()
    {
        barraDeEnergiaDoEscudo.gameObject.SetActive(true);//ativando a barra do escudo

        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        //barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

        escudoDoJogador.SetActive(true);
        temEscudo = true;
    }


     public void GanharVida(int vidaParaReceber)
    {
        if(vidaAtualDoJogador + vidaParaReceber <= vidaMaximaDoJogador)
        {
            vidaAtualDoJogador += vidaParaReceber;
        }
        else
        {
            vidaAtualDoJogador = vidaMaximaDoJogador;
        }

        barraDeVidaDoJogador.value = vidaAtualDoJogador;
    }


    public void MachucarJogador(int danoParaReceber)
    {
    
        if(temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;
            barraDeVidaDoJogador.value = vidaAtualDoJogador;
            barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

            if(vidaAtualDoJogador <= 0)
            {
                FindObjectOfType<ControleDoJogador>().jogadorEstaVivo = false; //acesso ao metodo de outro script
                GameManager.instance.GameOver();
                Debug.Log("Game Over!");
            }
        }else{

            vidaAtualDoEscudo -= danoParaReceber;

            barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

            if(vidaAtualDoEscudo <= 0){

                escudoDoJogador.SetActive(false);

                temEscudo = false;

                barraDeEnergiaDoEscudo.gameObject.SetActive(false);

            }
        }
    }
}