using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    #region Singleton

    public static GameManager instance;

    void Awake ()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public int currentKeys, neededKeys = 0;
    public Text keys;
    public HealthManager hM;

    void Start()
    {

    }

    void Update()
    {
        keys.text = currentKeys.ToString();
        if (hM.currentHealth <= 0){
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
    }

    public void AddKeys (int keysToAdd)
    {
        currentKeys += keysToAdd;
    }
}
