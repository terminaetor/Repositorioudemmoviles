using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Previsualizador : MonoBehaviour
{
    public GameObject creado;
    public Pokedex pokedex;
    public TextMeshProUGUI nombreCriaturaTexto;
    public static Previsualizador singleton;

    private void Awake()
    {
        singleton = this;
    }
    public void Previsualizar(int id)
    {
        Limpiar();
        Criatura criatura = pokedex.GetCriaturaPorID(id);
        if (criatura != null)
        {
            creado = Instantiate(criatura.prefab, transform.position, transform.rotation);
            nombreCriaturaTexto.text = criatura.nombre;
        }

    }

    public void Limpiar()
    {
        if (creado != null)
        {
            Destroy(creado);
        }
    }
}
