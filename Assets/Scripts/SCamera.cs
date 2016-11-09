using UnityEngine;
using System.Collections;

public class SCamera : MonoBehaviour
{
    #region Visible Variables

    [SerializeField] private float m_fCameraHeight;
    [SerializeField] private float m_fCameraDepth;

    #endregion

    private GameObject m_goPlayer;
    private GameObject m_goSeparation;

    // Use this for initialization
    void Start()
    {
        m_goPlayer = GameObject.FindGameObjectWithTag("Player");
        m_goSeparation = GameObject.FindGameObjectWithTag("Separation");
    }

    // Update is called once per frame
    void Update()
    {
        PlacementCamera();
    }

    void PlacementCamera()
    {
        //Debug.Log("Separation visible : " + m_goSeparation.GetComponent<Renderer>().isVisible);
        //if (!m_goSeparation.GetComponent<Renderer>().isVisible)
        //{
            Vector3 v3CameraPosition = new Vector3();
            v3CameraPosition = m_goPlayer.transform.position;
            v3CameraPosition.y = m_fCameraHeight;
            v3CameraPosition.z = m_fCameraDepth;
            transform.position = v3CameraPosition;
        //}
    }

     /*bool SafeFrameCheck()
     {
                 
         Vector3 screenPos = _cameraRef.WorldToScreenPoint(Player.Instance.xform.position);
         float ratio = screenPos.y / _cameraRef.pixelHeight;
         
         if(ratio < 0f) // if we're below our safe frame
             return false;
         
         if(ratio > .7f) // if we're above our safe frame, return false        
             return false;    
 
         return true;      // we're inside our safe frame.
     }*/
}
