using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LoadWinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        /// quand le joueur atein la sorti lance le menue de victoire
        if (collision.collider.tag == "Player")
        {
            SceneManager.LoadScene("FinDeLaDemo");
        }
    }
}
