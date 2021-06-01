using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons")]
public class Weapons : ScriptableObject
{
    public string weaponName, caliber;
    public int range, firepower, capacity, recoil;
   

}
