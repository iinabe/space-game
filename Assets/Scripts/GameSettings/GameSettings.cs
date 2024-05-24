using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageData
{
    public int LaserDamage;
    public int RocketDamage;
    public int BulletDamage;
    public int AsteroidDamage;
}

[System.Serializable]
public class MovementData
{
    public float PlayerSpeed;
    public float RocketSpeed;
    public float ArmorKitSpeed;
    public float AsteroidSpeed;
    public float CoinSpeed;
    public float MedKitSpeed;
    public float LaserSpeed;
    public float TurretSpeed;
}

public class GameSettings : MonoBehaviour
{
    public struct SceneNames
    {
        public const string Menu = "Menu";
        public const string MainScene = "MainScene";
        public const string GameOver = "GameOver";
    }

    public DamageData damages;
    public MovementData movements;
}