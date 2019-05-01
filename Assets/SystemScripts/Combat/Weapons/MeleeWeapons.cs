using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapons : MonoBehaviour, IWeapon
{
    public List<BaseStat> Stats { get; set; }

    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }
}
