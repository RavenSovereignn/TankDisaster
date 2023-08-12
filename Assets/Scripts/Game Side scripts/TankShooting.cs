using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Photon.Pun;

public class TankShooting : MonoBehaviour
{
    [Header ("References")]
    public GameObject warheadObj;
    public Transform turretAttackPoint;


    [Header("Properties")]
    public float shootForce;

    public float timeBetweenShooting;
    public float shootSpeed;
    public float reloadTime;

    public bool shooting;
    public bool readyToShoot;
    public bool reloading;
    public bool noWarhead;

    public bool allowInvoke = true;

    PhotonView view;

    private void Awake()
    {
        readyToShoot = true;
        noWarhead = false;
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(view.IsMine)
        {
            MyInput();
        }
       
    }

    private void MyInput()
    {
        shooting = Input.GetKey(KeyCode.Mouse0);
        if(readyToShoot && shooting && !reloading && !noWarhead)
        {
            Shoot();
        }

        if(readyToShoot && shooting && !reloading && noWarhead)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        GameObject currentWarhead = Instantiate(warheadObj, turretAttackPoint.position, Quaternion.identity);
        currentWarhead.transform.forward = turretAttackPoint.position.normalized;

        currentWarhead.GetComponent<Rigidbody>().AddForce(turretAttackPoint.forward * shootForce, ForceMode.Impulse);
        
        noWarhead = true;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        
    }
    private void ReloadFinished()
    {
        noWarhead = false;
        reloading = false;
    }
}
