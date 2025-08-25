using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    // Start is called before the first frame update
   // public GameObject[] vetorDeArmas;
   // int inidiceMaximo = 3;

    public GameObject arma1;
    public GameObject arma2;
    public GameObject arma3;
    public GameObject arma4;


    public bool itemDeEscudo;

    public bool itemDeLaserDuplo;

    public bool itemDeVida;

     // Defina o limite máximo de power-ups
    //private int contadorPowerUps;

    //public bool jaPodeUsarOPowerUp;


    /*public class PowerUp
{
    public GameObject powerUpPrefab;
    public int danoDoPowerUp;
}

    public int limiteMaximoPowerUps = 3;
    private List<PowerUp> powerUpsArmazenados = new List<PowerUp>();    */


    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(itemDeEscudo == true)
            {
                other.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();
            }

            if(itemDeLaserDuplo == true)
            {
                other.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = false;

                other.gameObject.GetComponent<ControleDoJogador>().tempoAtualDosLasersDuplos = other.gameObject.GetComponent<ControleDoJogador>().tempoMaximoDosLasersDuplos;

                other.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo = true;
            }

            if(itemDeVida)
            {
                other.gameObject.GetComponent<VidaDoJogador>().GanharVida(vidaParaDar);
            }

            if(itemDeArma1 == true || itemDeArma2 == true || itemDeArma3 == true || itemDeArma4 == true)
            {
                 Debug.Log("Power-up coletado!");
                 other.gameObject.GetComponent<ControleDoJogador>().temArmaEspecial = false;


                /*PowerUp powerUpAtual = CriarPowerUpAtual();

                if (powerUpAtual != null)
                {
                    powerUpsArmazenados.Add(powerUpAtual);

                if (powerUpsArmazenados.Count >= limiteMaximoPowerUps)
                {
                    
                    armaAtiva = true;
                    other.gameObject.GetComponent<ControleDoJogador>().temArmaEspecial = true;
                    /*InstanciarPowerUpComMaiorDano();
                    powerUpsArmazenados.Clear();  Limpar o vetor após a instância
                }*/
            }

                






               //other.gameObject.GetComponent<ControleDoJogador>().temArmaEspecial = true;
               
               
                //contadorPowerUps = contadorPowerUps + 1;
               
                /*if(contadorPowerUps < limiteMaximoPowerUps)
                {
                    Debug.Log("Power-up coletado!");
                     contadorPowerUps = contadorPowerUps + 1;


                }*/
            // Se o jogador atingiu o limite máximo, avise que precisa usar os power-ups antes de coletar mais
                    /*if (contadorPowerUps >= limiteMaximoPowerUps)
                    {
                        Debug.Log("autorizado a usar o poder ");
                        jaPodeUsarOPowerUp = true;
                        other.gameObject.GetComponent<ControleDoJogador>().temArmaEspecial = true;
                    }*/

                Destroy(this.gameObject);
            }
        
    }


    /*PowerUp CriarPowerUpAtual()
    {
        if (itemDeArma1) return new PowerUp { powerUpPrefab = arma1, danoDoPowerUp = arma1.GetComponent<LaserDoJogador>().danoParaDar };
        if (itemDeArma2) return new PowerUp { powerUpPrefab = arma2, danoDoPowerUp = arma2.GetComponent<LaserDoJogador>().danoParaDar };
        if (itemDeArma3) return new PowerUp { powerUpPrefab = arma3, danoDoPowerUp = arma3.GetComponent<LaserDoJogador>().danoParaDar };
        if (itemDeArma4) return new PowerUp { powerUpPrefab = arma4, danoDoPowerUp = arma4.GetComponent<LaserDoJogador>().danoParaDar };

        return null;
    }

    void InstanciarPowerUpComMaiorDano()
    {
        int maiorDano = -1;
        GameObject powerUpEscolhido = null;

        foreach (PowerUp powerUp in powerUpsArmazenados)
        {
            if (powerUp.danoDoPowerUp > maiorDano)
            {
                maiorDano = powerUp.danoDoPowerUp;
                powerUpEscolhido = powerUp.powerUpPrefab;
            }
        }

        if (powerUpEscolhido != null)
        {
            // Instanciar o power-up com maior dano
            Instantiate(powerUpEscolhido, transform.position, Quaternion.identity);
        }
    }*/
}


