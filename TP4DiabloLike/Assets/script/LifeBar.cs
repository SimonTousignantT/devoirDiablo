using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LifeBar : MonoBehaviour
{
    [SerializeField]
    float m_damageAmount = 25;
    public float m_health = 100f;
    public float m_maxHealth = 100f;
  
    public Image m_healthBarImage;
 
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_healthBarImage.fillAmount = m_health / m_maxHealth;
        if (m_health < 1)
        {
           
            SceneManager.LoadScene("GameOver");
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
          if (collision.gameObject.CompareTag("spider"))
          {
          
            m_health = m_health - m_damageAmount;
          
          }
    }
   
}
