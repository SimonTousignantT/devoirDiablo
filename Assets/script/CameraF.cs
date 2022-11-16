using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraF : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    float m_playerZ;
    float m_playerX;
    [SerializeField]
    Camera m_camera;
    [SerializeField]
    int m_offsetY = 35;
    [SerializeField]
    int m_offsetX = 18;
    [SerializeField]
    int m_offsetZ = 18;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_playerZ = player.transform.position.z;
        m_playerX = player.transform.position.x;

        m_camera.transform.position = new Vector3(m_playerX + m_offsetX, m_offsetY, m_playerZ + m_offsetZ);

        
    }
}
