using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleWord : MonoBehaviour
{

    public string wordID;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            bool collected = GameManager.instance.CollectWord(wordID);
            if(collected)
            {
                Debug.Log("ºÒµΩ¡À" + wordID);
                Destroy(gameObject);
            }
           
        }
    }
}
