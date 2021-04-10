﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerMenuScene : MonoBehaviour
{
    public GameObject dataBoard;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton ()
    {
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();

        dataBoard.transform.GetChild(2).GetComponent<Text>().text = DataManager.Instance.totalEnemyKilled.ToString();
        dataBoard.transform.GetChild(1).GetComponent<Text>().text = DataManager.Instance.totalShotBullet.ToString();
        dataBoard.SetActive(true);
    }
}
