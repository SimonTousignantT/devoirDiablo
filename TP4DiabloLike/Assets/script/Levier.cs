using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    [SerializeField]
   private GameObject levier;
    private bool m_collide = false;
    private bool inactive = true ;
    private Vector3 m_socle;
    private Vector3 m_rotateAxe;
    [SerializeField]
    private Pont m_pont;
    [SerializeField]
    AudioClip m_sound;
    // Start is called before the first frame update
    void Start()
    {
        m_rotateAxe = new Vector3(1, 0, 0);
        m_socle = levier.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ///abaisse le levier et envoie un orde d'activation au pont levie quand le joueur rentre en contact avc le levier
        if (m_collide == true)
        {
            gameObject.transform.RotateAround(m_socle,m_rotateAxe , 90);
            m_collide = false;
            m_pont.ActivateBridge();
            gameObject.GetComponent<AudioSource>().PlayOneShot(m_sound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (inactive == true)
        {
            if (collision.collider.tag == "Player")
            {
                m_collide = true;
                inactive = false;
            }
        }
    }
}
