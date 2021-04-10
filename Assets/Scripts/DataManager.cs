using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;

    EasyFileSave myFile;


    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "Atılan Kurşun Sayısı: " + shotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }

        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "Öldürülen Düşman Sayısı: " + enemyKilled.ToString();
            WinProcess();
        }
    }


    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }
    

    public void SaveData()
    {
        totalEnemyKilled += enemyKilled;
        totalShotBullet += shotBullet;
        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);

        myFile.Save();
    }


    public void LoadData()
    {
        if(myFile.Load())
        {
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
            totalShotBullet = myFile.GetInt("totalShotBullet");
        }
    }

    public void WinProcess()
    {
        if(EnemyKilled >= 5)
        {
            print("KAZANDIN MORUK !!!");
        }

    }

    public void LoseProcess()
    {
        print("KAYBETTİN YAVRU LUTFEN TEKRAR DENEYİNİZ.");
    }
}
