using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Photon.Pun;

public class TankInputs : MonoBehaviour
{
    [Header("Variables")]
    
    PhotonView view;

    #region Properties
    [Header("Properties")]
    private Vector3 aimPos;
    public Vector3 AimPos
    {
        get { return aimPos; }
    }
    private Vector3 aimNormal;
    public Vector3 AimNormal
    {
        get { return aimNormal; }
    }

    private float forwardInput;
    public float ForwardInput
    {
        get { return forwardInput; }
    }
    private float rotInput;
    public float RotInput
    {
        get { return rotInput; }
    }
    #endregion
    private void Start()
    {
        view = GetComponent<PhotonView>();
       
        
    }
    void Update()
    {
        if (view.IsMine)
        {
            HandleInputs(); 
        }
    }
    protected virtual void HandleInputs()
    {
            forwardInput = Input.GetAxis("Vertical");
            rotInput = Input.GetAxis("Horizontal");   
    }
}
