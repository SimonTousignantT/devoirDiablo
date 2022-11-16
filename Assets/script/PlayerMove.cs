using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMove : MonoBehaviour
{
    private Ray m_LastRay;
    [SerializeField]
    private Camera m_MainCamera;
    Vector3 m_newPose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            m_LastRay = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(m_LastRay, out hitInfo))
            {

                m_newPose = hitInfo.point;


            }
        }
        GetComponent<NavMeshAgent>().SetDestination(m_newPose);
    }
}
