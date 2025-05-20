using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehaviour : MonoBehaviour
{
    public Criatura _playerCriatura;
    public Criatura _enemyCriatura;
    public Pokedex pokedex;
    public float vidaenemigo;
    public float vidaplayer;
    public int idcreatura;
    public Transform _ScenePlayer;
    public Transform _sceneEnemy;
    public int idenemy;
    bool _combatiendo = true;

    private void Awake() {
        idcreatura = pokedex.criaturaActivaID;
        idenemy = pokedex.criaturaEnemigaActivaID;
        _playerCriatura = pokedex.GetCriaturaPorID(idcreatura);
        _enemyCriatura = pokedex.GetCriaturaPorID(idenemy);
        vidaenemigo = _enemyCriatura.vida;
        vidaplayer = _playerCriatura.vida;
    }

    private void Start() {
        StartCoroutine(Combate());
        Instantiate(_playerCriatura.prefab, _ScenePlayer.position, _ScenePlayer.rotation);
        Instantiate(_enemyCriatura.prefab, _sceneEnemy.position, _sceneEnemy.rotation);
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
        print(">> Le cause " + d + " de da�o, queda en " + vidaenemigo);
        if (vidaenemigo <= 0) {

            Victoria();
            _combatiendo = false;
        }
    }

    void AtaqueEnemigo() {
        float d = Random.Range(_enemyCriatura.ataque.x, _enemyCriatura.ataque.y);
        vidaplayer -= d;
        print("---> Te causaron " + d + "de da�o, queda en " + vidaplayer);
        if (vidaplayer <= 0) {
            
            Derrota();
            _combatiendo = false;
        }
    }

    void Victoria() {
        Debug.Log("GANASTE");
    }

    void Derrota() {
        print("perdiste");
    }

}
