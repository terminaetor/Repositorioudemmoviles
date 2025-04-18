using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaturaInstanciada : MonoBehaviour
{
    public Criatura baseDatos;
    public Criatura criaturaBase;
    Pokedex pokedex;
    public int nivel;
    public int id;
    public int vida => baseDatos.CalcularVida(nivel);
    public int ataque => baseDatos.CalcularAtaque(nivel);

    public void Awake()
    {
        criaturaBase = pokedex.GetCriaturaPorID(id);
    }

   
}
