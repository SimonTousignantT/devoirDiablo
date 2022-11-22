using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraF : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private float m_playerZ;
    private float m_playerX;
    [SerializeField]
    private Camera m_camera;
    [SerializeField]
    private int m_offsetY = 45;
    [SerializeField]
    private int m_offsetX = 15;
    [SerializeField]
    private int m_offsetZ = 15;
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
