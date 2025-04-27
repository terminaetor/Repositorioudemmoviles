using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehaviour : MonoBehaviour
{
    public CriaturaInstanciada _playerCriatura;
    public CriaturaInstanciada _enemyCriatura;
    public Pokedex pokedex;
    public int id;
    public GameObject _ScenePlayer;
    // Start is called before the first frame update
    
    void Start()
    {
        //_playerCriatura.criaturaBase;

        if (_playerCriatura != null && _playerCriatura.criaturaBase != null)
        {
            _ScenePlayer = Instantiate(_playerCriatura.criaturaBase.prefab, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AtaquePlayer()
    {
        if(_playerCriatura.vida > 0)
        {
            if(_enemyCriatura.vida <= _playerCriatura.ataque)
            {
                CombateSecuenciaPlayer();
            }
            else if(_enemyCriatura.ataque >= _playerCriatura.vida)
            {
                CombateSecuenciaEnemy();
            }
        }
    }

    void CombateSecuenciaPlayer()
    {
        //_enemyCriatura.baseDatos.CalcularVida = _enemyCriatura.vida - Random.Range(2, 4);
    }

    void CombateSecuenciaEnemy()
    {
        //_enemyCriatura.vida = _enemyCriatura - _playerCriatura;
    }
}
