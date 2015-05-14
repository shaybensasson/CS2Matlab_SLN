using System;
using Assets;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System.IO;


public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    private PlayerControllerInternal m_Internal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Continues animation even if we loose focus
        Application.runInBackground = true;
        
        m_Internal = new PlayerControllerInternal(writeToDebug: true, usingUnityLog: true);
        m_Internal.MessageRecieved += InternalOnMessageRecieved;
        m_Internal.Start();
    }

    private void InternalOnMessageRecieved(object sender, MessageRecievedEventArgs ea)
    {
        Vector3 movement = new Vector3(ea.WParam, 0.0f, ea.LParam);

        rb.AddForce(movement);
    }


    void FixedUpdate()
    {
        //Debug.Log("in fixed update");

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce( movement);
    }



    void OnDestroy()
    {
        if (m_Internal != null)
        {
            m_Internal.MessageRecieved -= InternalOnMessageRecieved;
            m_Internal.Dispose();

            m_Internal = null;
        }

    }

}