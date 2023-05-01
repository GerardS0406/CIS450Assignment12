/*
 * Gerard Lamoureux
 * InstructionsText
 * Assignment12
 * Handles the instructions panel at start of level
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;   
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
}
