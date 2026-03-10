using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    //public GameManager gM;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player"){
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
        /*if (gM.currentKeys == 1 && other.name == "Player"){
            SceneManager.LoadScene(2);
        }*/

    }
}
