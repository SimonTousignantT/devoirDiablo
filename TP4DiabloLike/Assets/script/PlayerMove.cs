using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMove : MonoBehaviour
{
    private Ray m_LastRay;
    [SerializeField]
    private Camera m_MainCamera;
    private Vector3 m_newPose;
    [SerializeField]
    private CastMove m_spellMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /// debut du script du click gauche
        if (Input.GetMouseButtonDown(0))
        {

            m_LastRay = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(m_LastRay, out hitInfo) )
            {

                m_newPose = hitInfo.point;
                /// envoie a un scrit une instruction pour areté le deplacement auto quand on est pas a porté d'un enemie
                /// question d'etre capable de changer de trajectoire
           
               
                /// empeche le player de se deplacer si la target est une araigner
                if ((hitInfo.collider.tag != "Spider" ) && (hitInfo.collider.tag != "Barrel"))
                {
                    m_spellMove.NativePlayerMove();
                    //fait deplacer le joueur lorsqu'il n'y a pas de target
                    GetComponent<NavMeshAgent>().SetDestination(m_newPose);
                }
            }
        }
       
        
    }
}
