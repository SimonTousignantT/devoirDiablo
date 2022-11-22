using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pont : MonoBehaviour
{
    [SerializeField]
    private float m_pontVitesse = 0.2f;
    [SerializeField]
    private int m_angleAbaissage = 82 ;
    [SerializeField]
    private GameObject m_socle;
    private Vector3 m_soclePos;
    private Vector3 m_rotateAxe;
    private float m_chronos = 0;
    private bool m_bridgeIsActivate = false;
    private int m_angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_rotateAxe = new Vector3(0, 0, 1);
        m_soclePos = m_socle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bridgeIsActivate == true)
        {
            if(m_chronos > m_pontVitesse)
            {
                gameObject.transform.RotateAround(m_soclePos, m_rotateAxe, 1);
                m_chronos = 0;
                m_angle++;
                if (m_angle > m_angleAbaissage)
                {
                   
                    m_bridgeIsActivate = false;
                }
            }
            m_chronos += Time.deltaTime;
        }
        
    }
    public void ActivateBridge()
    {
        m_bridgeIsActivate = true;

    }
}
