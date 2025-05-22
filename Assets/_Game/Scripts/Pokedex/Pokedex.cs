using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Pokedex", menuName = "UdeM/Pokedex")]
public class Pokedex : ScriptableObject
{
    public List<Criatura> criaturas = new List<Criatura>();

    public int criaturaActivaID = 1;

    public int criaturaEnemigaActivaID = -1;

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

    public Criatura GetCriaturaActiva()
    {
        if (criaturaActivaID == -1)
            return null;

        return GetCriaturaPorID(criaturaActivaID);
    }

    public Criatura GetCriaturaEnemiga()
    {
        if (criaturaEnemigaActivaID == -1)
            return null;

        return GetCriaturaPorID(criaturaEnemigaActivaID);
    }

    public void CargarDesdePlayerPrefs()
    {
        criaturaEnemigaActivaID = PlayerPrefs.GetInt("CriaturaEnemigaActivaID", -1);
    }

    
}
[System.Serializable]
public class Criatura
{
    public string nombre;
    public Vector3 ubicacion;
    public int id;
    public GameObject prefab;
    public Sprite img;
    public int nivel;
    public Tipo tipo;
    public string descripcion;
    public int vida => CalcularVida();
    public Vector2 ataque => CalcularAtaque();



    //Logica ara calcular probabilidad de captura

    public int CalcularVida()
    {
        // Por defecto, vida = nivel
        int vida = nivel + 6;

        // Si es tipo planta, suma 1 adicional
        if (tipo == Tipo.planta)
        {
            vida += 3;
        }
        Debug.Log(vida);
        return vida;
    }

    private Vector2 CalcularAtaque()
    {
        float min = nivel - nivel + 1;
        float max = nivel - 2;

        if (tipo == Tipo.animal)
        {
            max += 2; // Ejemplo: animales tienen más ataque máximo
        }

        return new Vector2(min, max);
    }


}
public enum Tipo
{
    indefinido = 0, 
    planta = 1,
    animal = 2
}