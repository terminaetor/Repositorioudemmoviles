using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACUIInventario : MonoBehaviour
{
    public ACDexManager _acDexManager;// Objeto que instancia a ACDexManager para usar la lista donde estan los datos de las criaturas
    public GameObject _criatura;
    public GameObject cajaPrefab; //Variable para añadir caja base donde va a estar los datos de criatura
    public Transform contenedor;// transform donde se van a instanciar en la escena las cajas
    private List<ACUICriaturaCaja> cajasCriaturas = new List<ACUICriaturaCaja>();//Lista donde se añaden todas las cajas

    

    
}
