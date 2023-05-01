/*
 * Gerard Lamoureux
 * Enemy
 * Assignment12
 * Handles enemy damage
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10000;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            GameController.Instance.EndGame();
        }
    }
}
