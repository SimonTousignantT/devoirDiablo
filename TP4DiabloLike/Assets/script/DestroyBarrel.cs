using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
public class DestroyBarrel : MonoBehaviour
{
    [SerializeField]
    private GameObject m_trash;
    private Vector3 m_barrelPos;
    private bool m_destroy = false;
    

    [SerializeField]
    AudioClip m_destroyBarrel;
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /// detruit le barril et crée des dechet a sont emplacement
        m_barrelPos = transform.position;
        if(m_destroy == true)
        {
            Debug.Log("je suis entré");
            Instantiate(m_trash, m_barrelPos, Quaternion.identity);
            
            gameObject.GetComponent<AudioSource>().PlayOneShot(m_destroyBarrel);

            Destroy(gameObject.GetComponent<MeshRenderer>());
            Destroy(gameObject.GetComponent<BoxCollider>());

            m_destroy = false;
        }
    }
    public void OnCollisionEnter(Collision collision)
    { /// il est detrui en rentrant en contact avec un sort du player
        if (collision.collider.tag == "PlayerSpell")///marche pas
        {
           
            m_destroy = true;

            Destroy(collision.gameObject);
            

        }
    }
}
