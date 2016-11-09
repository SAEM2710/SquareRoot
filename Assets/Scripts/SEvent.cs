﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

enum EventType
{
    TV
};

public class SEvent : MonoBehaviour
{
    [SerializeField] private EventType m_etEvent;
    [SerializeField] private SpriteRenderer m_srTVTexte;

    // Use this for initialization
    void Start ()
    {
        m_srTVTexte.enabled = false;
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
    }
}
