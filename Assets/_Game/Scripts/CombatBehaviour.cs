using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehaviour : MonoBehaviour
{
    public CriaturaInstanciada _playerCriatura;
    public CriaturaInstanciada _enemyCriatura;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void AtaquePlayer() Termporalmente comentalizado
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
    }*/

    void CombateSecuenciaPlayer()
    {
        //_enemyCriatura.vida = _enemyCriatura - _playerCriatura;
    }

    void CombateSecuenciaEnemy()
    {
        //_enemyCriatura.vida = _enemyCriatura - _playerCriatura;
    }
}
