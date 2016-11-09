using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SEvent : MonoBehaviour
{
    [SerializeField]
    private Text m_tText;

    [SerializeField]
    private string m_sString;

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
            m_tText.text = m_sString;
        }
    }

    void OnTriggerExit2D(Collider2D _c2dCollider)
    {
        if (_c2dCollider.CompareTag("Player"))
        {
            m_tText.text = "";
        }
    }
}
