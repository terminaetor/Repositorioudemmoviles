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

    //Logica ara calcular probabilidad de captura

    public bool IntentarCaptura(int nivelJugador)
    {
        float probabilidad = CalcularProbabilidadCaptura(nivelJugador);
        Debug.Log(probabilidad);
        float random = Random.Range(0f, 1f);//lanza un valor aleatorio
        return random <= probabilidad;// si el valor aleatorio es menor o igual a la probabilidad retornara a true, o si no a false
    }

    public float CalcularProbabilidadCaptura(int nivelJugador)
    {
        float baseProbabilidad = 0.95f;//variable que representa el porcentaje base de captura
        float dificultadPorNivel = 0.17f;// variable que aumenta dificultad de atrapar el pokemon
        float ventajaPorJugador = 0.03f;// variable que segun el nivel de jugador es mas facil capturar

        float probabilidad = baseProbabilidad - (nivel * dificultadPorNivel) + (nivelJugador * ventajaPorJugador);//valor que se da al operar con todas las variables

        return Mathf.Clamp(probabilidad, 0.05f, 0.95f);//impide que los valores vayan mas alla de 0.5% Y 95%
    }
}
public enum Tipo
{
    indefinido = 0, 
    planta = 1,
    animal = 2
}