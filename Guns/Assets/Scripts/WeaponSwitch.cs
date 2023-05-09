using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    [SerializeField] private int currentWeaponIndex = 0;
    [SerializeField] private List<GameObject> weapons;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon(currentWeaponIndex);
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeaponIndex = currentWeaponIndex;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentWeaponIndex >= weapons.Count - 1)
            {
                currentWeaponIndex = 0;
            }
            else
            {
                currentWeaponIndex++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeaponIndex <= 0)
            {
                currentWeaponIndex = weapons.Count - 1;
            }
            else
            {
                currentWeaponIndex--;
            }
        }

        if (previousWeaponIndex != currentWeaponIndex)
        {
            SelectWeapon(currentWeaponIndex);
        }
    }

    private void SelectWeapon(int weaponIndex)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == weaponIndex)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}
