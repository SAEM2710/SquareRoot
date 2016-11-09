using UnityEngine;
using System.Collections;
using UnityEngine.UI;

enum EventType
{
    TV
};

public class SEvent : MonoBehaviour
{
    [SerializeField] private EventType m_etEvent; 

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D _c2dCollider)
    {
        if (_c2dCollider.CompareTag("Player"))
        {
            switch(m_etEvent)
            {
                case EventType.TV:
                    Debug.Log("enter tv");
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D _c2dCollider)
    {
        switch (m_etEvent)
        {
            case EventType.TV:
                Debug.Log("exit tv");
                break;
        }
    }
}
