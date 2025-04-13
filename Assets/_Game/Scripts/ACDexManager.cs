using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ACDexManager : MonoBehaviour
{
    private string _filePath;
    public ACCriaturas _acCriaturas = new ACCriaturas();
    public List<GameObject> criaturasExistentes = new List<GameObject>();

    void Start()
    {
        _filePath = Application.persistentDataPath + "/Dex.json";//Determina direccion en donde se guarda el json que tiene los datos guardados
        CargarDex();
        SincronizarEscena();
    }

    public void SincronizarEscena()
    {
        foreach (GameObject go in criaturasExistentes)
        {
            if (go == null) continue;
            ACCriatura criatura = go.GetComponent<ACCriatura>();

            if (criatura != null)
            {
                ACDatos _datos = criatura.datos;
                if (!_acCriaturas.acCriaturas.Exists(p => p.id == _datos.id))
                {
                    _acCriaturas.acCriaturas.Add(_datos);
                    Debug.Log($"Se añadió {_datos.nombre} a la Pokédex.");
                }
            }

        }

        GuardarDex();

        foreach (var p in _acCriaturas.acCriaturas)
        {
            Debug.Log($"ID: {p.id}, Nombre: {p.nombre}, Atrapado: {p.atrapado}");
        }

    }
    public void CargarDex()
    {
        if(File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);//si existe el archivo se lee la informacion
            _acCriaturas = JsonUtility.FromJson<ACCriaturas>(json);//Recoger info json
            Debug.Log("Json existe");
        }
        else
        {
            _acCriaturas = new ACCriaturas();
            Debug.Log("Json  no existe");
            GuardarDex();
        }
    }

     public void GuardarDex()
    {
        string json = JsonUtility.ToJson(_acCriaturas, true);//Convertir informacion a json
        File.WriteAllText(_filePath, json);//Funcion que guarda el json
        Debug.Log("Existiendo");
    }
}
