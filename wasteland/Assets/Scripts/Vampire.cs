using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour
{

    public VampireHand vampireHand;
    public int vampireDamage;

    public void Start()
    {
        vampireHand.damage = vampireDamage;
    }
}
