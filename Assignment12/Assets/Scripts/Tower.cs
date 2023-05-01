/*
 * Gerard Lamoureux
 * Tower
 * Assignment12
 * Handles Base Tower
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour, ITower
{
    private int damage = 20;

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
    }

    public void Upgrade()
    {
        damage = (int)(damage * 1.1f);
        transform.localScale = new Vector2(transform.localScale.x * 1.1f, transform.localScale.y * 1.1f);
        GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
    }

    public void Attack()
    {
        GameController.enemy.TakeDamage(damage);
    }
}
