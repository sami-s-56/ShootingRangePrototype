using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponList")]
public class WeaponsList : ScriptableObject
{
    public static int selectedPos;
    public List<Weapons> weapons;
}
