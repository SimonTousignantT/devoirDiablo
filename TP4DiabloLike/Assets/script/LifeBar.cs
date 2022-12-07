using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LifeBar : MonoBehaviour
{
    [SerializeField]
    private InterpolationGameOver m_gameOver;
    [SerializeField]
    private float m_damageAmount = 25;
    private float m_health = 100f;
    private float m_maxHealth = 100f;
    private float m_chronos = 0;
    [SerializeField]
    private float m_timer = 7;
    private Animator m_animation;
    public Image m_healthBarImage;
    [SerializeField]
    private GameObject m_player;
    private Vector3 m_lastPos;
    private bool m_posDeadIsGet = false;
    private bool m_collide = false;
    private float m_chronos2 = 0;
    [SerializeField]
    private float m_attackSpeedEnemie = 1;
    [SerializeField]
    AudioClip m_dyingMan;
    [SerializeField]
    private AudioSource m_source;
    private bool m_isMyFirstDead = true;

    // Start is called before the first frame update
    void Start()
    {
        m_animation = m_player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       //gere l'afichage de la bars de vie
        m_healthBarImage.fillAmount = m_health / m_maxHealth;
        ///si le joueur n'a plu de vie il meur et une interpolation se fait et une animation de mort est activé, 
        ///fix sa position ou il est mort pour l'empecher de bouger et change sont layer pour que persone ne puisse le deplacer
        ///apres un certain temp la scene change.
        if (m_health < 1)
        {
            if(m_isMyFirstDead == true)
            {
                m_source.PlayOneShot(m_dyingMan);
                m_isMyFirstDead = false;
            }
            
            if (m_posDeadIsGet == false)
            {
                m_lastPos = m_player.transform.position;
                m_posDeadIsGet = true;
                m_player.layer = LayerMask.NameToLayer("Cadavre");
                m_animation.SetBool("Dead", true);
            }

            m_gameOver.GameOver();

            m_player.transform.position = m_lastPos;
            if (m_chronos > m_timer)
            {
                SceneManager.LoadScene("GameOver");
                m_chronos = 0;
            }
            m_chronos = m_chronos + Time.deltaTime;
         
        }
        if (m_collide == true)
        {
            m_chronos2 = m_chronos2 + Time.deltaTime;
            if(m_chronos2 > m_attackSpeedEnemie)
            {
                m_health = m_health - m_damageAmount;
                m_chronos2 = 0;
            }
            
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        ///si le player a une collision avec une araigner il prend du degas.
          if (collision.gameObject.CompareTag("Spider"))
          {

            m_collide = true;
          
          }
    }
    private void OnCollisionExit(Collision collision)
    {
        m_collide = false;
    }
}
