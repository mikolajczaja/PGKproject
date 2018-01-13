using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{


    public static int EnemyCountLimit;
    public static int ShootingDamage;
    public static float EnemyHealthMultiplier;
    public static int BasePlayerHealth;
    public static int BasePlayerAmmo;


    public void SelectDifficulty(Text difficultyLabel)
    {
        switch (difficultyLabel.text)
        {
            case "Easy":
                {
                    easy();
                }
                break;
            case "Medium":
                {
                    medium();
                }
                break;
            case "Hard":
                {
                    hard();
                }
                break;
        }
    }

    private void easy()
    {
        EnemyCountLimit = 3;
        EnemyHealthMultiplier = 0.5f;
        BasePlayerHealth = 200;
        BasePlayerAmmo = 500;
        ShootingDamage = 50;
    }

    private void medium()
    {
        EnemyCountLimit = 15;
        EnemyHealthMultiplier = 0.66f;
        BasePlayerHealth = 100;
        BasePlayerAmmo = 100;
        ShootingDamage = 40;
    }

    private void hard()
    {
        EnemyCountLimit = 30;
        EnemyHealthMultiplier = 1f;
        BasePlayerHealth = 50;
        BasePlayerAmmo = 20;
        ShootingDamage = 20;
    }

}
