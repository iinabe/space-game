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

public class GameSettings : MonoBehaviour
{
    public struct SceneNames
    {
        public const string Menu = "Menu";
        public const string MainScene = "MainScene";
    }

    public DamageData damages;
}
