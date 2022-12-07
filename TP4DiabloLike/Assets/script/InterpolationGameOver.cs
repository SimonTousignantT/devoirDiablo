using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterpolationGameOver : MonoBehaviour
{
    private bool m_gameOver = false;
    public Image image;
    private float m_transparence = 0;
    Color m_color = Color.black;
    private float m_chronos = 0;
    [SerializeField]
    private float m_timer = 0.1f;
    private float m_speedShadow = 0.2f ;
    private float m_interpolation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /// crée une interpolation pour asombrir l'image sur le temp a la mort du player
        if(m_gameOver == true)
        {
        
          
            if(m_chronos > m_timer)
            {
               
                Debug.Log("sa rentre");
                image = GetComponent<Image>();
                m_color = Color.Lerp(Color.clear, Color.black, m_interpolation);
               m_interpolation = m_interpolation + m_speedShadow ;
                image.color = m_color;
               
                m_chronos = 0;
            }
            m_chronos = m_chronos + Time.deltaTime;
         
        }
    }
    public void GameOver()
    {
        m_gameOver = true;
    }
}
