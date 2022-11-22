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
    Vector3 m_deadPos;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(m_player.transform.position);
        
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("walkSpider");
            animator.SetBool("walkSpider", true);
        if(m_isDead == true)
        {
            GetComponent<NavMeshAgent>().SetDestination(m_deadPos);
            m_chronos = m_chronos + Time.deltaTime;
         
          
            gameObject.transform.Rotate(90, 0, 0);
            if (m_chronos > m_timer )
            {
                Destroy(gameObject);
                m_chronos = 0;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "playerSpell")
        {
            Destroy(collision.gameObject);
            m_deadPos = this.gameObject.transform.position;
           
            
            m_isDead = true;
            
          
        }
    }
 
}
