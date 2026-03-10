using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    #region ver

    public int startingHealth, currentHealth, oldHealth, currentGold, healAmount;
    public Text lives, gold;
    public PlayerController thePlayer;

    public bool isRespawning, isFadeToBlack, isFadeFromBlack;
    private Vector3 respawnPoint;
    public float respawnLength, fadeSpeed, waitForFade;
    public Image blackScreen;
    public GameObject respawnEffect;

    #endregion 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;

        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = currentHealth.ToString();
        gold.text = currentGold.ToString();

        oldHealth = currentHealth;

        if (currentGold >= healAmount){
            AddHealth();
        }

        if (isFadeToBlack){
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 1f){
                isFadeToBlack = false;
            }
        }

        if (isFadeFromBlack){
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f){
                isFadeFromBlack = false;
            }
        }
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < oldHealth){
            Respawn();
        }
    }

    public void AddGold(int goldToAdd)
    {
        currentGold += goldToAdd;
    }

    public void AddHealth()
    {
            currentHealth += 1;
            currentGold -= healAmount;
    }

    public void Respawn()
    {
        if (!isRespawning){
            StartCoroutine("RespawnCo");
        }
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(respawnLength);

        isFadeToBlack = true;

        yield return new WaitForSeconds(waitForFade);

        isFadeToBlack = false;
        isFadeFromBlack = true;

        isRespawning = false;

        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = respawnPoint;
        Instantiate(respawnEffect, thePlayer.transform.position, thePlayer.transform.rotation);
        startingHealth = currentHealth;
        currentHealth = startingHealth;
    }
}
