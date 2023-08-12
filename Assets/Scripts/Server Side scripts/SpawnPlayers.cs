using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    private void Start()
    {
        GameObject player = PhotonNetwork.Instantiate("Player", spawnPoint.position, Quaternion.identity);

        if (!player.GetPhotonView().IsMine)
            return;
        player.transform.Find("CameraController").gameObject.SetActive(true);
    }
}
