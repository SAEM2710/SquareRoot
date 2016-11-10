using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*enum EventType
{
    TV,
    Door
};*/

public class SEvent : MonoBehaviour
{
    /*[SerializeField]*/ //public EventType m_etEvent;

    /*public EventType etEvent
    {
        get
        {
            return m_etEvent;
        }
        set
        {
            m_etEvent = value;
        }
    }*/

    //[SerializeField] private SpriteRenderer m_srTVTexte;

    // Use this for initialization
    void Start ()
    {
        //m_srTVTexte.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    /*void OnTriggerEnter2D(Collider2D _c2dCollider)
    {
        if (_c2dCollider.CompareTag("Player"))
        {
            switch(m_etEvent)
            {
                case EventType.TV:
                    m_srTVTexte.enabled = true;
                    break;
                case EventType.Door:
                    m_srTVTexte.enabled = true;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D _c2dCollider)
    {
        switch (m_etEvent)
        {
            case EventType.TV:
                m_srTVTexte.enabled = false;
                break;
        }
    }*/
}
