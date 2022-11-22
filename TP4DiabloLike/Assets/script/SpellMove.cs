using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
public class SpellMove : MonoBehaviour
{
    private Ray m_LastRay;
    [SerializeField]
    private Camera m_MainCamera;
    [SerializeField]
    SpellSpawner m_spellCast;
    Vector3 m_SpiderPos;
    [SerializeField]
    GameObject m_Player;
    Vector3 m_playerDestination;
    bool m_IsNotInRangeX = false;
    bool m_IsNotInRangeXN = false;
    bool m_IsNotInRangeZ = false;
    bool m_IsNotInRangeZN = false;
 
    [SerializeField]
    private float m_timer = 2;
    private bool m_ClockStart = false;
    [SerializeField]
    private int m_range = 15;
    private bool m_allFalse;
    private bool m_inRange = true;
    private bool m_haveClic = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        m_LastRay = m_MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(m_LastRay, out hitInfo))
        {
            if (hitInfo.collider.tag == "spider")
            {
                m_SpiderPos = hitInfo.collider.transform.position;
                //m_SpiderPos = hitInfo.transform.position;
                //m_SpiderPos = hitInfo.point;
               
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    m_haveClic = true;
                    m_allFalse = true;
                    m_playerDestination = m_SpiderPos;
                   
                    if (m_Player.transform.position.x < m_SpiderPos.x - m_range)
                    {
                        m_IsNotInRangeXN = true;
                        m_allFalse = false;
                    }
                    if (m_Player.transform.position.x > m_SpiderPos.x + m_range)
                    {
                        m_IsNotInRangeX = true;
                        m_allFalse = false;
                    }
                   if (m_Player.transform.position.z > m_SpiderPos.z + m_range)
                    {
                        m_IsNotInRangeZ = true;
                        m_allFalse = false;
                    }
                    if (m_Player.transform.position.z < m_SpiderPos.z - m_range)
                    {
                        m_IsNotInRangeZN = true;
                        m_allFalse = false;
                    }
                   
                    if (m_allFalse == true)
                    {
                        m_spellCast.InRange();
                    }
                }
            }
        }
       

        if (m_IsNotInRangeX == true)
        {
            
            m_playerDestination.x = m_SpiderPos.x + m_range;
          
            m_inRange = false;
            if (m_Player.transform.position.x <= m_SpiderPos.x + m_range)
            {
                m_IsNotInRangeX = false;
            }
        }
        if (m_IsNotInRangeXN == true)
        {
           
            m_playerDestination.x = m_SpiderPos.x - m_range;
          
            m_inRange = false;
            if (m_Player.transform.position.x >= m_SpiderPos.x - m_range)
            {
                m_IsNotInRangeXN = false;
            }

        }
        if (m_IsNotInRangeZ == true)
        {
           
            m_playerDestination.z = m_SpiderPos.z + m_range;
          
            m_inRange = false;
            if (m_Player.transform.position.z <= m_SpiderPos.z + m_range)
            {
                m_IsNotInRangeZ = false;
            }

        }
        if (m_IsNotInRangeZN == true)
        {
            
            m_playerDestination.z = m_SpiderPos.z - m_range;
    
            m_inRange = false;
            if (m_Player.transform.position.z >= m_SpiderPos.z - m_range)
            {
                m_IsNotInRangeZN = false;
            }

        }
        if(m_inRange == false)
        {

            m_Player.GetComponent<NavMeshAgent>().SetDestination(m_playerDestination);

            if(m_IsNotInRangeZN == false)
            {
                if(m_IsNotInRangeZ == false)
                {
                    if(m_IsNotInRangeXN== false)
                    {
                        if(m_IsNotInRangeX == false)
                        {
                            m_inRange = true;
                            if(m_haveClic == true )
                            {
                                m_spellCast.InRange();
                                m_haveClic = false;
                            }
                        }
                    }
                }
            }
        }


        GetComponent<NavMeshAgent>().SetDestination(m_SpiderPos);
    }
    public void NativePlayerMove()
    {
        m_IsNotInRangeZ = false;
        m_IsNotInRangeZN = false;
        m_IsNotInRangeX = false;
        m_IsNotInRangeXN = false;
    }
}
