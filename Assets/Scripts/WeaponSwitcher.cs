using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int _currentWeaponIndex;

    void Start()
    {
        this._currentWeaponIndex = 0;
        this.SwitcherForWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        this.SwitchWeaponEvent();
    }

    private void SwitchWeaponEvent()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.SwitcherForWeapons();
        }
    }

    private void SwitcherForWeapons()
    {

        for (int iterWeaponIndex = 0; iterWeaponIndex < this.transform.childCount; iterWeaponIndex++)
        {
            this.transform.GetChild(iterWeaponIndex).gameObject.SetActive(_currentWeaponIndex
                                                                          == iterWeaponIndex);
        }

        _currentWeaponIndex = (_currentWeaponIndex + 1) % this.transform.childCount;
    }
}
