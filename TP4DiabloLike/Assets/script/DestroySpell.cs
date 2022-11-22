using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpell : MonoBehaviour
{
    private int m_baseRef = 50;
    private float m_chronos;
     [SerializeField]
    private int m_timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < m_baseRef )
        {
            if(m_chronos > m_timer)
            {
                Destroy(gameObject);
                m_chronos = 0;
            }
            m_chronos = m_chronos + Time.deltaTime;
        }
    }
}
