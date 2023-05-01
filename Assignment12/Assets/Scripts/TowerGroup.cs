/*
 * Gerard Lamoureux
 * TowerGroup
 * Assignment12
 * Handles A Group of Towers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGroup : ITower
{
    private List<ITower> towers = new List<ITower>();

    public void AddTower(ITower tower)
    {
        towers.Add(tower);
    }

    public void RemoveTower(ITower tower)
    {
        towers.Remove(tower);
    }

    public void Upgrade()
    {
        foreach(ITower tower in towers)
        {
            tower.Upgrade();
        }
    }

    public void Attack()
    {
        foreach(ITower tower in towers)
        {
            tower.Attack();
        }
    }
}
