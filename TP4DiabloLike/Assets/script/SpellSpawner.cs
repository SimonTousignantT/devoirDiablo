using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Spell;
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private Camera m_MainCamera;
    private Vector3 m_PlayerPos;
    private bool m_InRange = false;
    private Vector3 m_SpiderPos;
    private Ray m_LastRay;
    private Vector3 m_spellDirection;
     [SerializeField]
    private int m_castRange = 3;
    private Animator m_animation;
    private float m_chronos = 0;
    [SerializeField]
    private float m_animationTimer = 0.1f;
    private bool m_attack = false;
    [SerializeField]
    AudioClip m_spellSound;
    [SerializeField]
    private AudioSource m_source;

    // Start is called before the first frame update
    void Start()
    {
        m_animation = m_player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (m_InRange == true)
        {
            // fexecute l'animation
            m_animation.SetBool("Attack",true);
            ///le sort aparais a un certain offset pour evité que le spell empeche le player de se mouvoir du a une collision non voulue
            m_PlayerPos = m_player.transform.position;
           
                    if(m_SpiderPos.x > m_PlayerPos.x)
                    {
                        m_spellDirection.x = m_PlayerPos.x + m_castRange ;
                    }
                    if(m_SpiderPos.x < m_PlayerPos.x)
                    {
                        m_spellDirection.x = m_PlayerPos.x - m_castRange;
                    }
                    if (m_SpiderPos.z > m_PlayerPos.z)
                    {
                        m_spellDirection.z = m_PlayerPos.z + m_castRange;
                    }
                    if (m_SpiderPos.z < m_PlayerPos.z)
                    {
                        m_spellDirection.z = m_PlayerPos.z - m_castRange;
                    }

                    /// lance le sort
                    Instantiate(m_Spell,  m_spellDirection , Quaternion.identity).GetComponent<NavMeshAgent>().destination = m_SpiderPos;
                    m_source.PlayOneShot(m_spellSound);
                
          
            m_InRange = false;
            m_attack = true;
        }
        /// fait en sorte que  l'annimation  se desactive apre sont execution
        if(m_attack == true)
        {
            if (m_chronos > m_animationTimer)
            {
                m_animation.SetBool("Attack",false);
                m_chronos = 0;
                m_attack = false;
            }
            m_chronos = m_chronos + Time.deltaTime;
        }
       
    }
    public void InRange(Vector3 spiderPos) 
    {
        Debug.Log("sa instancie");
        // lance le sort depuis un au scrit qui gere le mouvement quand on a pas la range
        m_InRange = true;
        m_SpiderPos = spiderPos;
        
    }
}
