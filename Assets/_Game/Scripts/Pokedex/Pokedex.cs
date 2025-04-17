using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Pokedex", menuName = "UdeM/Pokedex")]
public class Pokedex : ScriptableObject
{
    public List<Criatura> criaturas = new List<Criatura>();

    public int GetPorID(int id)
    {
        int _id = -1;
        for (int i = 0; i < criaturas.Count; i++)
        {
            if (criaturas[i].id == id)
            {
                return i;
            }
        }
        return _id;
    }

    public Criatura GetCriaturaPorID(int id)
    {
        int _id = GetPorID(id);
        if (_id == -1)
        {
            return null;
        }

        return criaturas[_id];
    }
}
[System.Serializable]
public class Criatura
{
    public string nombre;
    public int id;
    public GameObject prefab;
    public Sprite img;
    public int nivel;
    public Tipo tipo;

    public int vida => CalcularVida();
    public int ataque => CalcularAtaque();

    private int CalcularVida()
    {
        // Por defecto, vida = nivel
        int vida = nivel;

        // Si es tipo planta, suma 1 adicional
        if (tipo == Tipo.planta)
        {
            vida += 1;
        }

        return vida;
    }

    private int CalcularAtaque()
    {
        // Por defecto, daño = nivel
        int ataque = nivel;

        // Si es tipo animal, suma 1 adicional
        if (tipo == Tipo.animal)
        {
            ataque += 1;
        }

        return ataque;
    }
}
public enum Tipo
{
    indefinido = 0, 
    planta = 1,
    animal = 2
}