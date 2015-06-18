using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    //Is this the player character?
    public bool player = false;

    public int currentHealth = 10;
    public int maxHealth = 10;
    public int scoreWorth = 1;

    //Slider to display health
    public Slider healthSlider;
    public GameObject deathEffect;
    public Vector3 deathEffectOffset;

    //Time until respawn
    public float respawnTime = 0;

    private GameStats gameStats;
    private SpawnItems spawnItems;

    void Update()
    {
        if (currentHealth <= 0)
            Die();

        //If there is a health slider...
        if (healthSlider)
        {
            //...Set slider value
            healthSlider.value = (float)currentHealth / (float)maxHealth;
        }

        gameStats = GameObject.FindWithTag("GameController").GetComponent<GameStats>();
        if (!player)
            spawnItems = GameObject.FindWithTag("GameController").GetComponent<SpawnItems>();
    }

    //Adds health amount, up to the max health
    public void AddHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    //Removes health by amount, down to zero
    public void RemoveHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;
    }

    void Die()
    {
        //Show death effects
        if (deathEffect)
        {
            GameObject flash = Instantiate(deathEffect, transform.position + deathEffectOffset, transform.rotation) as GameObject;
            Destroy(flash, 2f);
        }

        //If this is the player...
        if (player)
        {
            gameObject.SetActive(false); //Deactive gameobject
            gameStats.SetPlayerDead(); 

            PlayerPrefs.SetInt("totalDeaths", PlayerPrefs.GetInt("totalDeaths") + 1); //Update totalDeaths statistic
        }
        else //If this is not the player (is an enemy)...
        {
            //Add score
            gameStats.AddScore(scoreWorth);

            //Spawn items
            spawnItems.Spawn(transform.position);

            //If respawnTime is not zero, Invoke respawn method after respawnTime
            if(respawnTime > 0)
                Invoke("Respawn", respawnTime);

            //Disable gameobject
            gameObject.SetActive(false); 

            PlayerPrefs.SetInt("totalKills", PlayerPrefs.GetInt("totalKills") + 1);
        }
    }

    //Reset variables, and enable gameObject
    void Respawn()
    {
        currentHealth = maxHealth;

        gameObject.SetActive(true);
    }
}
