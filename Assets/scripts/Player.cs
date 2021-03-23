using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Player : MonoBehaviour
{
    public int position, score, record, life;
    public float speed;
    public GameObject player;
    public Transform playerPos;
    public Animation boom;
    public GameObject cam, life1, life2, life3, life4, life5;
    public Text scoreTxt, recordTxt;
    public AudioSource block,  redaudio, greenaudio, purpleaudio, coin;
    public GameObject overImg;
    private bool showad = false;


    public void restart()
    {
        SceneManager.LoadScene(0);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void showads()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
            showad = true;
        }
    }
    void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3944791", false);
        }
        showad = false;
        overImg.SetActive(false);
        Time.timeScale = 1;
        position = 0;
        score = 0;
        life = 5;
       
        /*if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", 0);
        */
        if (!PlayerPrefs.HasKey("record"))
        {
            PlayerPrefs.SetInt("record", 0);
        }
       
        PlayerPrefs.GetInt("score", score);
        PlayerPrefs.GetInt("record", record);
        scoreTxt.text = "score: " + 0f;
        recordTxt.text = "record: " + record;


    }
    public void GameOver()
    {
        overImg.SetActive(true);
        Time.timeScale = 0;
        if (score > record)
            {
                record = score;
                PlayerPrefs.SetInt("record", score);
                PlayerPrefs.Save();
            }
    }
    private void Update()
    {
        if (life <= 0)
        {
            GameOver();
        }
        if (showad == true)
        {
            overImg.SetActive(false);
            Time.timeScale = 1;
            life = 5;
           this.gameObject.transform.position = new  Vector3(0, 0, 0.4f);
            showad = false;
        }
        switch (life)
        {
            case 5:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                life4.SetActive(true);
                life5.SetActive(true);
                break;
            case 4:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                life4.SetActive(true);
                life5.SetActive(false);
                break;
            case 3:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                life4.SetActive(false);
                life5.SetActive(false);
                break;
            case 2:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(false);
                life4.SetActive(false);
                life5.SetActive(false);
                break;
            case 1: 
                life1.SetActive(true);
                life2.SetActive(false);
                life3.SetActive(false);
                life4.SetActive(false);
                life5.SetActive(false);
                break;
            case 0:  
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                life4.SetActive(false);
                life5.SetActive(false);
                break;
            case -1:
                GameOver();
                break;
        }
            
    }
    void FixedUpdate()
    {
        
        if (position == 1 && transform.position.x != 3)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (position == -1 && transform.position.x != -3)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (this.gameObject.transform.position.x >= 5f || this.gameObject.transform.position.x <= -5f) 
        {
            life = 0;
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            position = 1;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            position = -1;
        }
    }
    public void Right()
    {
        if (transform.position.x != 3)
        {
            position = 1;
        }
        
    }
    public void Left()
    {
        if (transform.position.x != 3) { 
        position = -1;
    }     
    }
    public void RightUp()
    {
        position = 0;
    }
    public void LeftUp()
    {
        position = 0;
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "greenCube")
        {
            player.transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
            greenaudio.Play();
        }
        if (trigger.gameObject.tag == "redCube")
        {
            player.transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, transform.localScale.z + 0.2f);
            redaudio.Play();
        }
        if (trigger.gameObject.tag == "purpleCube")
        {
            player.transform.localScale = new Vector3(1f,1f,1f);
            purpleaudio.Play();
        }
        if (trigger.gameObject.tag == "score")
        {
            score++;
            scoreTxt.text ="score: " + score;
            coin.Play();
        }
        if (trigger.gameObject.tag == "block")
        {
            life--;
            block.Play();
            if (cam.gameObject.transform.eulerAngles.z == 0f)
            {
                boom.Play("boom");
                
            } 
            if(cam.gameObject.transform.eulerAngles.z >= 180f || cam.gameObject.transform.eulerAngles.z <= -180f)
            {

                boom.Play("boomBack");
            }

        }
    }



} 
           
