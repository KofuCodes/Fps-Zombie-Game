using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasue : MonoBehaviour
{
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the active state of the GameObject
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
