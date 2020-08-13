using System.Collections;
using System;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour {

    private static string weaponDefinitionPath = "Json/WeaponDefinitions";

    private static System.Random random;

    void Start() {

        TextAsset jsonTextFile = Resources.Load<TextAsset>(weaponDefinitionPath);

        WeaponDefinitions weaponDefinitions = JsonUtility.FromJson<WeaponDefinitions>(jsonTextFile.text);
        
        random = new System.Random();

        for (int i = 0; i < 10; i++) {
            Debug.Log(generateRandomWeapon(weaponDefinitions.weaponDefinitions[random.Next(0, weaponDefinitions.weaponDefinitions.Length)]).getWeaponDetails());
        }
    }


    Weapon generateRandomWeapon(WeaponDefinition weaponDefinition) {
        return new Weapon(weaponDefinition.name, random.NextDouble() * (weaponDefinition.maximumDamage - weaponDefinition.minimumDamage) + weaponDefinition.minimumDamage, weaponDefinition);
    }
}
