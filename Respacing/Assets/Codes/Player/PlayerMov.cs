using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMov : MonoBehaviour
{
    public Animator anim;

    public float velocidadeRotacao = 5f;
    public float aceleracaoMovimento = 5f;
    public float desaceleracaoMovimento = 2f;
    public float velocidadeMaxima = 100f;
    public float velocidadeMinima = -5f;

    [Header("velociadade atual")]
    public float velocidadeAtual = 0f;

    public void Start()
    {
        anim = GetComponent<Animator>();
       
    }


    void Update()
    {
       


        // Movimentação horizontal (rotação)
        float inputHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * -inputHorizontal * velocidadeRotacao);

        // Movimentação vertical (propulsores)
        float inputVertical = Input.GetAxis("Vertical");
        
        

        if (inputVertical != 0)
        {
            // Aceleração
            velocidadeAtual += inputVertical * aceleracaoMovimento * Time.deltaTime;
        }
        else
        {
            // Desaceleração suave          
           velocidadeAtual = (Mathf.Abs(velocidadeAtual) < 0.9) ? 0 : Mathf.Lerp(velocidadeAtual, 0, desaceleracaoMovimento * Time.deltaTime);

        }
        anim.SetFloat("PowerLvl", Mathf.Abs(velocidadeAtual));

        // Limita a velocidade máxima
        velocidadeAtual = Mathf.Clamp(velocidadeAtual, velocidadeMinima, velocidadeMaxima);

        // Movimentação da nave
        transform.Translate(Vector3.up * velocidadeAtual * Time.deltaTime);
    }
}

