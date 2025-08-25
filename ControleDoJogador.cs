using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{
    public ItensColetaveis itensColetaveis;
    public ArmasEspeciais armasEspeciais;
    //public  ArmasEspeciais armasEspeciais;
    public Rigidbody2D oRigidbody2D;
     /*public GameObject arma1;
    public GameObject arma2;
    public GameObject arma3;
    public GameObject arma4;*/
    public GameObject laserDoJogador;
    public Transform localDoDisparoUnico;
    public Transform localDoDisparoDaEsquerda;
    public Transform localDoDisparoDaDireita;

    public float tempoAtualDosLasersDuplos;

    public float tempoMaximoDosLasersDuplos;
    public float tempoAtualDasArmasEspeciais;

    public float tempoMaximoDasArmasEspeciais;

    public float velocidadeDaNave; 
    public bool temLaserDuplo;
    public bool temArmaEspecial;
    private Vector2 teclasApertadas;

    public bool jogadorEstaVivo;


    //public KeyCode teclaAtivarPowerUp = KeyCode.Space;

    


    void Start()
    {
       
        
        itensColetaveis = FindObjectOfType<ItensColetaveis>();
        armasEspeciais = FindObjectOfType<ArmasEspeciais>();


        jogadorEstaVivo = true;
        temLaserDuplo = false;
        temArmaEspecial = false;
        tempoAtualDosLasersDuplos = tempoMaximoDosLasersDuplos;
        tempoAtualDasArmasEspeciais = tempoMaximoDasArmasEspeciais;



       // itensColetaveis = GameObject.Find("Itens Coletaveis").GetComponent<ItensColetaveis>();

    }

    
    void Update()
    {
        MovimentarJogador();
        if(jogadorEstaVivo == true)
        {
            AtirarLaser();
        }

        if(temLaserDuplo == true)
        {
            tempoAtualDosLasersDuplos -= Time.deltaTime;
            if(tempoAtualDosLasersDuplos <= 0)
            {
                DesativarLaserDuplo();
            }
        }
         if(temArmaEspecial == true)
        {
            tempoAtualDasArmasEspeciais -= Time.deltaTime;
            if(tempoAtualDasArmasEspeciais <= 0)
            {
                DesativarArmasEspeciais();
            }
        }



       
        
    }

    //metodo para movimentação da nave
    private void MovimentarJogador()
    {
        //dizer pra unity quais foram as teclas apertadas
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        oRigidbody2D.velocity = teclasApertadas.normalized * velocidadeDaNave;

    }

    private void AtirarLaser()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(temLaserDuplo == false && temArmaEspecial == false)
            {
                Instantiate(laserDoJogador, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            }
            else if(temLaserDuplo == true)
            {
                Instantiate(laserDoJogador, localDoDisparoDaEsquerda.position, localDoDisparoDaEsquerda.rotation);
                Instantiate(laserDoJogador, localDoDisparoDaDireita.position, localDoDisparoDaDireita.rotation);

            }
            else if(temArmaEspecial == true)
            {
              // Instantiate(arma2, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
                //Instantiate(arma4, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
                /*if(itensColetaveis.itemDeArma1){

                    Instantiate(arma1, localDoDisparoUnico.position, localDoDisparoUnico.rotation);

                }else if(itensColetaveis.itemDeArma2)
                {
                         Instantiate(arma2, localDoDisparoUnico.position, localDoDisparoUnico.rotation);

                }else if(itensColetaveis.itemDeArma3)
                {
                        Instantiate(arma3, localDoDisparoUnico.position, localDoDisparoUnico.rotation);

                }else if(itensColetaveis.itemDeArma4)
                {
                        Instantiate(arma4, localDoDisparoUnico.position, localDoDisparoUnico.rotation);

                }*/
                
                    Debug.Log("utilizando o poder");
                   armasEspeciais.AtivarArmasEspeciais();
    




                
                //else if (temArmaEspecial == true)
            /*if (itensColetaveis.itemDeArma1)
                {
                    Instantiate(arma1, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
                }
                else if(itensColetaveis.itemDeArma2)
                {
                    Instantiate(arma2, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
                }
                else if(itensColetaveis.itemDeArma3)
                {
                    Instantiate(arma3, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
                }
                else if(itensColetaveis.itemDeArma4)
                {
                    Instantiate(arma4, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
                }*/

                
                
                    
    
                
            }

            EfeitosSonoros.instance.somDoLaserDoJogador.Play();
        }
    }

   

    

    
    private void DesativarLaserDuplo()
    {
        temLaserDuplo = false;

        tempoAtualDosLasersDuplos = tempoMaximoDosLasersDuplos;
    }

    private void DesativarArmasEspeciais()
    {
        
        temArmaEspecial = false;

        tempoAtualDasArmasEspeciais = tempoMaximoDasArmasEspeciais;
    }
    
    

}
