using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Spider;
    [SerializeField]
    private GameObject m_Player;
    private Vector3 m_PlayerPos;
    private Vector3 m_NextPosSpawn;
    [SerializeField]
    private int m_offset = 50;
    [SerializeField]
    private int m_SpiderSpawnFrequence = 60;
    [SerializeField]
    private int m_NBSpider = 3;
    private bool m_spiderZIsSpawn = false;
    private int m_spiderXIsSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
      /// les araigner se dirige automatiquement sur le player une fois qu'il sont instancier alors le les fait spawn a partir d'ici 
      /// je prend la position du joueur et apres avoir parcourue une certaine distance je spawn de
       m_PlayerPos = m_Player.transform.position;
        m_NextPosSpawn.x = m_PlayerPos.x;
        m_NextPosSpawn.z = m_PlayerPos.z;
    }

    // Update is called once per frame
    void Update()
    {
        m_PlayerPos = m_Player.transform.position;
        if (m_PlayerPos.x < m_NextPosSpawn.x)
        {

            m_NextPosSpawn.x -= m_SpiderSpawnFrequence;
            if (m_spiderXIsSpawn != 3)/// parce que le 3 ses la zone du boss XD
            {
                for (int i = 0; i <= m_NBSpider; i++)
                {
                    Instantiate(m_Spider, new Vector3(m_PlayerPos.x - m_offset, m_PlayerPos.y, m_PlayerPos.z), Quaternion.identity);
                }
                m_spiderXIsSpawn++;
            }
            
        }
        if (m_PlayerPos.z > m_NextPosSpawn.z)
        {

            m_NextPosSpawn.z += m_SpiderSpawnFrequence;
            if (m_spiderZIsSpawn == false)
            {


                for (int i = 0; i <= m_NBSpider; i++)
                {


                    Instantiate(m_Spider, new Vector3(m_PlayerPos.x, m_PlayerPos.y, m_PlayerPos.z + m_offset), Quaternion.identity);
                   



                }
                m_spiderZIsSpawn = true;
            }

        }

    }
}
