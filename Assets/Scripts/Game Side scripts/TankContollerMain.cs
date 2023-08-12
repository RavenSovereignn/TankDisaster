using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TankContollerMain : MonoBehaviour
{
    [Header("Variables")]
    public float tankSpeed = 15f;
    public float tankRotSpeed = 20f;
    public float turretRotSpeed = 40f;
    private float yRot;

    public Transform turretTransform;
    public float turretLagSpeed = 0.5f;

    private Rigidbody rb;
    private TankInputs tankInputs;

    public GameObject tankCamera;

    PhotonView view;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        tankInputs = GetComponent<TankInputs>();
        view = GetComponent<PhotonView>();
        //tankCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (view.IsMine)
        {
            if (rb && tankInputs)
            {
                HandleMovement();
                //HandleTurret();
            }
        }
    }
    private void Update()
    {
        if (view.IsMine)
        {
            HandleTurret();
        }  
    }

    protected virtual void HandleMovement()
    {
        
        
            //Move tank forward
            Vector3 wantedPos = transform.position + (transform.forward * tankInputs.ForwardInput * tankSpeed * Time.deltaTime);
            rb.MovePosition(wantedPos);

            //Tank Rotation
            Quaternion wantedRot = transform.rotation * Quaternion.Euler(Vector3.up * (tankRotSpeed * tankInputs.RotInput * Time.deltaTime));
            rb.MoveRotation(wantedRot);
        
    }

    protected virtual void HandleTurret()
    {
        if(turretTransform)
        {
            
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * turretRotSpeed;

            yRot += mouseX;

            turretTransform.Rotate(0, yRot, 0);
        }
    }

}
