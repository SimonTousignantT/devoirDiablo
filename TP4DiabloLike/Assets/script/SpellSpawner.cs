using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Spell;
    [SerializeField]
    private GameObject m_Player;
    private Vector3 m_PlayerPos;
    private bool m_InRange = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(m_InRange == true )
        {
            m_PlayerPos = m_Player.transform.position;
            
            
                Instantiate(m_Spell, m_PlayerPos, Quaternion.identity);
            
            m_InRange = false;
        }
        
    }
    public void InRange() 
    {
        m_InRange = true;
    }
}
