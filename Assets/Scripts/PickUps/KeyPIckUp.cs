using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPIckUp : MonoBehaviour
{
    public int value;
    public GameObject pickUpEffect;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.name == "Player"){

            FindObjectOfType<GameManager>().AddKeys(value);
            
            Instantiate(pickUpEffect, transform.position, transform.rotation);

            Destroy(gameObject);
            
        }
    }
}
