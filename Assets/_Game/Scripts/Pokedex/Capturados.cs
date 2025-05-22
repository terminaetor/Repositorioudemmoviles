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
    public TextMeshProUGUI nAtrapados;
    public GameObject panelNuevoNivel;
    public int cantidadObtenida;
    public SeleccionadorCriaturas seleccion;

    public void Awake()
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
            seleccion.idActivo = 1;
            seleccion.SeleccionarCriaturaPorID();
            Capturar(1);
            
        }
        ActualizarNivelJugador();
        cantidadObtenida = capturas.capturas.Count;
        nAtrapados.text = cantidadObtenida.ToString();
    }

    private void Start()
    {
        panelNuevoNivel.SetActive(false);
    }

    public void Capturar(int id)
    {
        capturas.Capturar(id);
        //MensajeCaptura.singleton.MostrarMensaje(id);
        ACUIDexManager.singleton.ActualizarCajas();
        

        Guardar();
    }

    public bool VerificarCaptura(int id)
    {
        if (capturas == null || capturas.capturas == null || capturas.capturas.Count < 1)
            return false;
        cantidadObtenida = capturas.capturas.Count;
        nAtrapados.text = cantidadObtenida.ToString();
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
            nivel.text = nivelJugador.ToString();
            StartCoroutine(MensajeNuevoNivel(5f));

        }
    }

    IEnumerator MensajeNuevoNivel(float time) 
    {
        
        panelNuevoNivel.SetActive(true);
        
        yield return new WaitForSeconds(time);
        panelNuevoNivel.SetActive(false);
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
            Debug.Log("Capturaste a " + id);
            Capturados.singleton.Guardar();
        }
    }

   
}