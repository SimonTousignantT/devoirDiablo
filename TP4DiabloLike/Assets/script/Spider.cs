using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
public class Spider : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;
    private bool m_attack = false;
    private float m_chronos = 0;
    private bool m_isDead = false;
    [SerializeField]
    private float m_timer = 1;
    private Vector3 m_deadPos;
    private bool m_haveRotate = false;
    [SerializeField]
    AudioClip m_dyingSpider;
  
    private bool m_isMyFirstDead = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /// envois lenemie direct sur le joueur
        if(m_isDead == false)
        {
            GetComponent<NavMeshAgent>().SetDestination(m_player.transform.position);
        }
        
       
        /// si laraigner rencontre un sort du player la tourne sur le dos pour faire genre quelle agonise , et la fait disparetre sont cadavre apres un certain temp
        if(m_isDead == true)
        {
            if (m_isMyFirstDead == true)
            {
                GetComponent<AudioSource>().PlayOneShot(m_dyingSpider,20f);
                m_isMyFirstDead = false;
            }
            
            if (m_haveRotate == false)
            {
                gameObject.transform.Rotate(180, 0, 0);
                m_haveRotate = true;
                m_deadPos.y = gameObject.transform.position.y + 2;
            }
           
            transform.position = m_deadPos;
            
            m_chronos = m_chronos + Time.deltaTime;


            Destroy(gameObject.GetComponent<NavMeshAgent>());
            
           

            if (m_chronos > m_timer )
            {
                Destroy(gameObject);
                m_chronos = 0;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "PlayerSpell")
        {
            Destroy(collision.gameObject);
            m_deadPos = this.gameObject.transform.position;
            gameObject.tag = "Player"; 
            
            m_isDead = true;
            
          
        }
    }
}
