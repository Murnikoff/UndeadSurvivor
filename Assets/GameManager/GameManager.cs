using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    public float gameTime;
    public float maxGameTime = 2 * 10f;

    public int level;
    public int exp;
    public int kill;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };

    public int health;
    public int maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;

        if (exp == nextExp[level]) {
            level++;
            exp = 0;
        }
    }
}
