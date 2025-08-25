using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasEspeciais : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arma1;
    public GameObject arma2;
    public GameObject arma3;
    public GameObject arma4;
    public ControleDoJogador controleDoJogador;
    public bool armasAtivas;
    public ItensColetaveis itensColetaveis;


    //public GameObject[] vetorDeArmas;

    int aux;

    int indice;

    void Start()
    {
        controleDoJogador = FindObjectOfType<ControleDoJogador>();
        itensColetaveis = FindObjectOfType<ItensColetaveis>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AtivarArmasEspeciais()
    {
        //Debug.Log("chamando ativar armas especiais");
        armasAtivas = true;
        /*Debug.Log("ativando armas especiais");
        itensColetaveis.InstanciarPowerUpComMaiorDano();
        itensColetaveis.powerUpsArmazenados.Clear(); */
        


        Instantiate(vetorDeArmas[indice],controleDoJogador.localDoDisparoUnico.position, controleDoJogador.localDoDisparoUnico.rotation);
        

        indice = EscolherComMaiorDano();

        int EscolherComMaiorDano(){
        int maiorDano = -1; // Inicializando com um valor negativo para garantir que qualquer dano positivo será maior

        if (itensColetaveis.itemDeArma1 && arma1.GetComponent<LaserDoJogador>().danoParaDar > maiorDano)
        {
            maiorDano = arma1.GetComponent<LaserDoJogador>().danoParaDar;
            aux = 0;
        }

        if (itensColetaveis.itemDeArma2 && arma2.GetComponent<LaserDoJogador>().danoParaDar > maiorDano)
        {
            maiorDano = arma2.GetComponent<LaserDoJogador>().danoParaDar;
            aux = 1;
        }

        if (itensColetaveis.itemDeArma3 && arma3.GetComponent<LaserDoJogador>().danoParaDar > maiorDano)
        {
            maiorDano = arma3.GetComponent<LaserDoJogador>().danoParaDar;
            aux = 2;
        }

        if (itensColetaveis.itemDeArma4 && arma4.GetComponent<LaserDoJogador>().danoParaDar > maiorDano)
        {
            maiorDano = arma4.GetComponent<LaserDoJogador>().danoParaDar;
           aux = 3;
        }

        return aux;
        }
    }



        /*if (itensColetaveis.itemDeArma1)
                {
                    Debug.Log("arma 1 sendo ativada");
                    Instantiate(arma1, controleDoJogador.localDoDisparoUnico.position, controleDoJogador.localDoDisparoUnico.rotation);
                }
                else if(itensColetaveis.itemDeArma4)
                {
                    Debug.Log("arma 4 sendo ativada");
                    Instantiate(arma4, controleDoJogador.localDoDisparoUnico.position, controleDoJogador.localDoDisparoUnico.rotation);
                }
                else if(itensColetaveis.itemDeArma3)
                {
                    Debug.Log("arma 3 sendo ativada");
                    Instantiate(arma3, controleDoJogador.localDoDisparoUnico.position, controleDoJogador.localDoDisparoUnico.rotation);
                }
                else if(itensColetaveis.itemDeArma2)
                {
                    Debug.Log("arma 2 sendo ativada");
                    Instantiate(arma2, controleDoJogador.localDoDisparoUnico.position, controleDoJogador.localDoDisparoUnico.rotation);
                }*/
}


    

