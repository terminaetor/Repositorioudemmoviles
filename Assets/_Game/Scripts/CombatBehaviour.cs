using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatBehaviour : MonoBehaviour
{
    public Capturados capturados;
    public Capturas captura;
    public Criatura _playerCriatura;
    public Criatura _enemyCriatura;
    public GameObject ganaste, perdiste;
    public Pokedex pokedex;
    public float vidaenemigo;
    public float vidaplayer;
    public int idcreatura;
    public Transform _ScenePlayer;
    public Transform _sceneEnemy;
    private Animator anim1;
    private Animator anim2;
    public int idenemy;
    bool _combatiendo = true;
    private GameObject instanciaPlayer;
    private GameObject instanciaEnemy;
    public Image healthbarenemy;
    public Image healthbarplayer;
    public TMP_Text nombreplayer;
    public TMP_Text nombreenemigo;

    private void Awake() {
        
        idcreatura = pokedex.criaturaActivaID;
        idenemy = pokedex.criaturaEnemigaActivaID;
        _playerCriatura = pokedex.GetCriaturaPorID(idcreatura);
        _enemyCriatura = pokedex.GetCriaturaPorID(idenemy);
        vidaenemigo = _enemyCriatura.vida;
        vidaplayer = _playerCriatura.vida;
    }

    private void Start() {
        captura = capturados.capturas;
        instanciaPlayer = Instantiate(_playerCriatura.prefab, _ScenePlayer.position, _ScenePlayer.rotation);
        instanciaEnemy = Instantiate(_enemyCriatura.prefab, _sceneEnemy.position, _sceneEnemy.rotation);
        nombreplayer.text = _playerCriatura.nombre;
        nombreenemigo.text = _enemyCriatura.nombre;
        Transform playerAnim = instanciaPlayer.transform.Find("anim");
        Transform enemyAnim = instanciaEnemy.transform.Find("anim");

        if (playerAnim != null)
            anim1 = playerAnim.GetComponent<Animator>();
        else
            Debug.LogWarning("No se encontró 'anim' en el prefab del jugador");

        if (enemyAnim != null)
            anim2 = enemyAnim.GetComponent<Animator>();
        else
            Debug.LogWarning("No se encontró 'anim' en el prefab del enemigo");
        
        StartCoroutine(Combate());
    }

    public IEnumerator Combate() {
        bool _turnoJugador = Random.Range(0, 100) < 50;
        while (_combatiendo) {
            if (_turnoJugador) {
                AtaqueJugador();
            } else {
                AtaqueEnemigo();
            }
            _turnoJugador = !_turnoJugador;
            yield return new WaitForSeconds(3);
        }
    }

    void AtaqueJugador() {
        float d = Random.Range(_playerCriatura.ataque.x,_playerCriatura.ataque.y);
        vidaenemigo -= d;
        anim2.SetBool("isAttack", false);
        anim1.SetBool("isAttack", true);
        print(">> Le cause " + d + " de da�o, queda en " + vidaenemigo);
        healthbarenemy.fillAmount = vidaenemigo / _enemyCriatura.vida;
        Debug.Log("la barra de vida esta" + healthbarenemy.fillAmount);
        if (vidaenemigo <= 0) {
            Victoria();
            _combatiendo = false;
        }
    }

    void AtaqueEnemigo() {
        float d = Random.Range(_enemyCriatura.ataque.x, _enemyCriatura.ataque.y);
        vidaplayer -= d;
        anim1.SetBool("isAttack", false);
        anim2.SetBool("isAttack", true);
        print("---> Te causaron " + d + "de da�o, queda en " + vidaplayer);
        healthbarplayer.fillAmount = vidaplayer / _playerCriatura.vida;
        if (vidaplayer <= 0) {

            Derrota();
            _combatiendo = false;
        }
    }

    void Victoria() {
        Debug.Log("GANASTE");
        anim1.SetBool("isAttack", false);
        Ocultar();
        captura.Capturar(idenemy);
        ganaste.SetActive(true);
    }

    void Derrota() {
        print("perdiste");
        anim2.SetBool("isAttack", false);
        Ocultar();
        perdiste.SetActive(true);
    }

    void Ocultar()
    {
        instanciaEnemy.SetActive(false);
        instanciaPlayer.SetActive(false);
        nombreenemigo.text = " ";
        nombreplayer.text = " ";
    }

    public void MostrarCaptura()
    {
        MensajeCaptura.singleton.MostrarMensaje(idenemy);
    }

}
