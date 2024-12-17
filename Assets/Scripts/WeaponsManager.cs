using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField]
    private int _initialWeaponIndex = 0;
    [SerializeField]
    private Shoot[] _weapons = null;

    private int _currentWeaponIndex = 0;

    private void Start()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].gameObject.SetActive(false);
        }

        _weapons[_initialWeaponIndex].gameObject.SetActive(true);
        _currentWeaponIndex = _initialWeaponIndex;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
        }
    }

    private void ChangeWeapon(int index)
    {
        if (_currentWeaponIndex != index)
        {
            _weapons[_currentWeaponIndex].gameObject.SetActive(false);
            _weapons[index].gameObject.SetActive(true);
            _currentWeaponIndex = index;
        }
    }
}
