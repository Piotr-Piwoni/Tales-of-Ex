using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateUnlock : MonoBehaviour
{
    /*public int currentKeys;
    public Text keys;*/

    bool gotAllKeys;
    public Animator myAnim;
    public GateUnlock gate;
    public GameManager gM;
    public GameObject openEffect, openEffect2;


    void Start()
    {
        //keys.text = currentKeys.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gM.currentKeys == gM.neededKeys){
            StartCoroutine("GateCo");
        }
    }

   /* public void AddKeys (int keysToAdd)
    {
        currentKeys += keysToAdd;
        //myAnim.SetBool("GotAllKeys", gotAllKeys);

        if ( currentKeys == 2){
            gate.gameObject.SetActive(false);
            currentKeys = 0;
        }
    } */

    /*private void OnTiggerEnter(Collider other)
    {
        if (other.tag == "Player" && gM.currentKeys == 2){
            StartCoroutine("GateCo");

        }
    } */

    public IEnumerator GateCo()
    {
        gM.currentKeys = 0;
        myAnim.SetBool("GotAllKeys", gotAllKeys);
        yield return new WaitForSeconds(1.56f);
        Instantiate(openEffect, transform.position, transform.rotation);
        Instantiate(openEffect2, transform.position, transform.rotation);
        gate.gameObject.SetActive(false);
    } 
}
