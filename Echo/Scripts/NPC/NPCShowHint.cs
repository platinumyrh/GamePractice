using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShowHint : MonoBehaviour
{

    public GameObject hintText; // Reference to the hint text GameObject
    // Start is called before the first frame update
    void Start()
    {
        hintText.SetActive(false); // Ensure the hint text is initially hidden
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hintText != null)
        {
            hintText.SetActive(true); // Show hint when player enters
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hintText != null)
        {
            hintText.SetActive(false); // Hide hint when player leaves
        }
    }
}

