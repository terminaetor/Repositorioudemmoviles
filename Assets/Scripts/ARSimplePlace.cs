using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSimplePlace : MonoBehaviour
{
    public Pokedex pokedex;
    public Criatura criatura;
    public int id;
    public GameObject criaturaToPlace;
    public GameObject island;

    public Camera arCamera;

    public float islandHeight;
    public float criaturaHeight;
    public bool placed;

    private void Awake()
    {
        id = pokedex.criaturaEnemigaActivaID;
        criatura = pokedex.GetCriaturaPorID(id);
    }

    private void Start()
    {

        placed = false;
        islandHeight = 0.08f;
        criaturaHeight = 0.2f;
        criaturaToPlace = criatura.prefab;
        criaturaToPlace.transform.localScale = Vector3.one*0.2f;
    }
    void Update()
    {
        if (!placed && Input.GetMouseButtonDown(0))
        {
            //calcular una posicion a un metro y medio de la camara
            Vector3 spawnPos = arCamera.transform.position + arCamera.transform.forward * 1.5f;
            Instantiate(island, spawnPos, Quaternion.identity);

            //calcular la posicion de la criatura encima de la isla
            Vector3 criaturaPos = spawnPos + new Vector3(0, (islandHeight/2f) + (criaturaHeight/2f), 0);
            Instantiate(criaturaToPlace, criaturaPos, Quaternion.identity);
            
            placed = true;
        }
    }
}
