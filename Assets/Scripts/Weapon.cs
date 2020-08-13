using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {
    
    public string name { get; set; }

    public double damage { get; private set; }

    public WeaponDefinition weaponDefinition { get; private set; }

    public Weapon(string name, double damage, WeaponDefinition weaponDefinition) {
        this.name = name;
        this.damage = damage;
        this.weaponDefinition = weaponDefinition;
    }

    public string getWeaponDetails() {
        return "Name: " + this.name + ", Damage: " + this.damage + ", Weapon Definition: { " + this.weaponDefinition.getWeaponDetails() + " }";
    }
}
