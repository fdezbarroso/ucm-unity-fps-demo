using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxLife = 100;

    private int _life = 0;

    private void Start()
    {
        _life = _maxLife;
    }

    public void Damage(int damage)
    {
        Debug.Log("Damage: " + damage);
        _life -= damage;

        if (_life <= 0)
        {
            Debug.Log("Death");
            Destroy(gameObject);
        }
    }
}
