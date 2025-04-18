using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Capturados : MonoBehaviour
{
    public Capturas capturas;
    public static Capturados singleton;
    public int nivelJugador;
    public int nivelAnterior;
    public TextMeshProUGUI nivel;
    public GameObject panelNuevoNivel;

    private void Awake()
    {
        singleton = this;
        string guardado = PlayerPrefs.GetString("capturas");
        if (guardado.Length > 3)
        {
            capturas = JsonUtility.FromJson<Capturas>(guardado);
        }
        else
        {
            capturas = new Capturas();
            Capturar(0);
        }
        ActualizarNivelJugador();
    }

    private void Start()
    {
        panelNuevoNivel.SetActive(false);
    }

    public void Capturar(int id)
    {
        capturas.Capturar(id);
        ACUIDexManager.singleton.ActualizarCajas();
        Guardar();
    }

    public bool VerificarCaptura(int id)
    {
        if (capturas == null || capturas.capturas == null || capturas.capturas.Count < 1)
            return false;
        return capturas.capturas.Contains(id);
    }

    public void Guardar()
    {
        PlayerPrefs.SetString("capturas", JsonUtility.ToJson(capturas));
    }

    public void ActualizarNivelJugador()
    {
        nivelAnterior = nivelJugador;
        nivelJugador = Mathf.RoundToInt(Mathf.Ceil(capturas.capturas.Count / 4f));
        if(nivelJugador > nivelAnterior && !(nivelJugador == 1))
        {
            Debug.Log("Aumentaste de nivel Nuevo nivel: " + nivelJugador);
            panelNuevoNivel.SetActive(true);
            nivel.text = nivelJugador.ToString();

        }
    }

}
[System.Serializable]
public class Capturas
{
    public List<int> capturas = new List<int>();
    public void Capturar(int id)
    {
        if (!capturas.Contains(id))
        {
            capturas.Add(id);
        }
    }

   
}