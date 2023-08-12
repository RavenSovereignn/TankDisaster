using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Score : MonoBehaviour
{
    PhotonView view;
    public Text scoreText;
    public int scoreNumber;
    [SerializeField]
    private float _myScore;

    
    private void Awake()
    {
        scoreNumber = 0;
        scoreText = GameObject.Find("ScoreUIMain").GetComponent<Text>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void myScore()
    {
        
        _myScore = scoreNumber;
        scoreText.text = _myScore.ToString();

        if(view.IsMine)
        {
            view.RPC(nameof(ScoreUI), RpcTarget.Others, _myScore);
        }
        
    }
    [PunRPC]
    public void ScoreUI(float score)
    {
         
        _myScore = score;
        scoreText.text = _myScore.ToString();
        Debug.Log(_myScore);
    }
}
