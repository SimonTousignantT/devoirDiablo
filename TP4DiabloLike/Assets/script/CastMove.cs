using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
public class CastMove : MonoBehaviour
{
    [SerializeField]
    private Camera m_MainCamera;
    [SerializeField]
    SpellSpawner m_spellCast;

    Vector3 m_targetPos;
    [SerializeField]
    private float m_timer = 2;
    [SerializeField]
    private int m_range = 15;
    [SerializeField]
    GameObject m_Player;
    private Ray m_LastRay;
    Vector3 m_playerDestination;
    bool m_IsNotInRangeX = false;
    bool m_IsNotInRangeXN = false;
    bool m_IsNotInRangeZ = false;
    bool m_IsNotInRangeZN = false;
 
    private bool m_allFalse;
    private bool m_inRange = true;
    private bool m_haveClic = false;
    Vector3 m_target;
    [SerializeField]
    GameObject m_spell;

    // Start is called before the first frame update
    void Start()
    {
        
        //m_target = target;
        //m_SpiderPos = m_target; marche pas
    }
   
    // Update is called once per frame
    void Update()
    {
       
        m_LastRay = m_MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(m_LastRay, out hitInfo))
        {
            if (hitInfo.collider.tag == "Spider" || hitInfo.collider.tag == "Barrel")
            {
                m_targetPos = hitInfo.collider.transform.position;
                
               
               
                /// determine si le joueur a la porté pour lancer le sort
                if (Input.GetKeyDown(KeyCode.Mouse0))/// ajouté le clic droit ici si vous voullez avoir une commande d'attack clic droit dissocié de vos mouvement
                {
                    m_haveClic = true;
                   
                    m_allFalse = true;
                    m_playerDestination = m_targetPos;
                    
                    

                    if (m_Player.transform.position.x < m_targetPos.x - m_range)
                    {
                        m_IsNotInRangeXN = true;
                        m_allFalse = false;
                        
                    }


                    else if (m_Player.transform.position.x > m_targetPos.x + m_range)
                    {
                        m_IsNotInRangeX = true;
                        m_allFalse = false;
                        
                    }


                    if (m_Player.transform.position.z > m_targetPos.z + m_range)
                    {
                        
                        m_IsNotInRangeZ = true;
                        m_allFalse = false;
                    }


                   else if (m_Player.transform.position.z < m_targetPos.z - m_range)
                    {
                      
                        m_IsNotInRangeZN = true;
                        m_allFalse = false;
                    }
                    if (m_allFalse == true)
                    {
                        Debug.Log("je suis a porté");
                        m_spellCast.InRange(m_targetPos);
                    }
                }
            }
        }

        /// si le player na pas la range determine la position qu'il devrait avoir pour avoir la range et deplace le joueur a cette position
        if (m_IsNotInRangeX == true)
        {
            m_inRange = false;
            if (m_Player.transform.position.x <= m_targetPos.x + m_range)
            {
                m_IsNotInRangeX = false;
            }
        }
        else if (m_IsNotInRangeXN == true)
        {
            m_inRange = false;
            if (m_Player.transform.position.x >= m_targetPos.x - m_range)
            {
                m_IsNotInRangeXN = false;
            }
        }
        if (m_IsNotInRangeZ == true)
        {
            m_inRange = false;
            if (m_Player.transform.position.z <= m_targetPos.z + m_range)
            {
                m_IsNotInRangeZ = false;
            }
        }
        else if (m_IsNotInRangeZN == true)
        {
            m_inRange = false;
            if (m_Player.transform.position.z >= m_targetPos.z - m_range)
            {
                m_IsNotInRangeZN = false;
            }
        }
        if (m_inRange == false)
        {
            GetComponent<NavMeshAgent>().SetDestination(m_targetPos);
             GetComponent<NavMeshAgent>().stoppingDistance = m_range;
            
          
            
            ///lance le sort une fois le deplacement auto terminé/// 
            ///atention!!!! le sort na peut etre pas de cible veuillez lui en donner une en survolant avec votre souri une cible
            if (m_IsNotInRangeZN == false)
            {
                if (m_IsNotInRangeZ == false)
                {
                    if (m_IsNotInRangeXN == false)
                    {
                        if (m_IsNotInRangeX == false)
                        {
                            m_inRange = true;
                            if (m_haveClic == true)
                            {
                                /// instancie le sort avec la direction de la target(spiderPos) position

                               
                                Debug.Log("jetai pas mais la je suis a porté");
                                m_spellCast.InRange(m_targetPos);
                                m_haveClic = false;
                              
                            }
                        }
                    }
                }
            }
        }

     

    }
    public void NativePlayerMove()
    {
        ////quand on veut se deplacer sans target on peut anuler le deplacement auto cité plus aut en pleine action
        m_IsNotInRangeZ = false;
        m_IsNotInRangeZN = false;
        m_IsNotInRangeX = false;
        m_IsNotInRangeXN = false;
        Debug.Log("baseMove");
        GetComponent<NavMeshAgent>().stoppingDistance = 0;
    }
   

}
