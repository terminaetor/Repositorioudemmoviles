using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
    public int idCapturar;
    public void Capturar()
    {
        Capturados.singleton.Capturar(idCapturar);
    }
}
