/*
 * Gerard Lamoureux
 * GameController
 * Assignment12
 * Handles Overall Game
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private TowerGroup allTowers = new TowerGroup();

    private TowerGroup individualTowerGroups = new TowerGroup();

    private TowerGroup individualTowers = new TowerGroup();

    public GameObject EndGamePanel;

    public TextMeshProUGUI enemyHealth;

    public GameObject towerPrefab;

    public static Enemy enemy = new Enemy();

    public static GameController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EndGamePanel.SetActive(false);
        allTowers.AddTower(individualTowerGroups);
        allTowers.AddTower(individualTowers);
        allTowers.AddTower(FindObjectOfType<Tower>());
        StartCoroutine(TowerAttack());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        enemyHealth.text = "Enemy Health: " + enemy.health;
    }

    IEnumerator TowerAttack()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            allTowers.Attack();
        }
    }

    public void SpawnNewTowerGroup()
    {
        TowerGroup towerGroup = new TowerGroup();
        Vector2 randPos = new Vector2(Random.Range(-6f, 6f), Random.Range(-2f, 2f));
        GameObject go = Instantiate(towerPrefab, randPos + new Vector2(-0.5f, 0), Quaternion.identity);
        go.GetComponent<SpriteRenderer>().color = Color.red;
        towerGroup.AddTower(go.GetComponent<Tower>());
        go = Instantiate(towerPrefab, randPos + new Vector2(0.5f,0), Quaternion.identity);
        go.GetComponent<SpriteRenderer>().color = Color.red;
        towerGroup.AddTower(go.GetComponent<Tower>());
        individualTowerGroups.AddTower(towerGroup);
    }

    public void SpawnNewTower()
    {
        GameObject go = Instantiate(towerPrefab, new Vector2(Random.Range(-7f, 7f), Random.Range(-2f, 2f)), Quaternion.identity);
        go.GetComponent<SpriteRenderer>().color = Color.green;
        individualTowers.AddTower(go.GetComponent<Tower>());
    }

    public void UpgradeTowerGroup()
    {
        individualTowerGroups.Upgrade();
    }

    public void UpgradeTower()
    {
        individualTowers.Upgrade();
    }

    public void UpgradeAllTowers()
    {
        allTowers.Upgrade();
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        EndGamePanel.SetActive(true);
    }
}
