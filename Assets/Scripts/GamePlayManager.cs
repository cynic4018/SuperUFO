using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public GameObject originalPipe;
    public float pipeSpaceing = 4f;
    public GameObject canvasGameOver;
    // Start is called before the first frame update
    public int score = 0;
    public Text textScore;
    public Text textBestScore;
    public int best = 0;
    public bool gameOver = false;

    public SoundManager soundManager;

    //pipe i location.
    public int round_i = 0;
    //for check the times that character passing the pipe and remove&put it back to pipePool.  
    public int passingCheck = 0;
    //Amount of the first pipe.
    public int amountFirstPipe = 8;
    // Create the pool that collect all pipes.
    public List<GameObject> pipePool = new List<GameObject>();

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        GeneratePipe();
        GenerateLevel();
        if(PlayerPrefs.HasKey("BEST")){
            best = PlayerPrefs.GetInt("BEST");
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    //Create the first set of pipes then adding to pipe pool.
    public void GeneratePipe(){
        for(int i=0; i<amountFirstPipe; i++){
            pipePool.Add(Instantiate(originalPipe));
        }
    }

    //Set the position of the first set of pipes. 
    public void GenerateLevel(){
        for(int i=0; i<amountFirstPipe; i++){
            pipePool[i].transform.position = new Vector3(i * pipeSpaceing+2, Random.Range(-1f, 1f), 0);
            round_i++;
        }
    }

    //Reassign the position of pipe that we already passing but it isn't the pipe that we are currently pass. 
    public void ReassignPipePos(){
        if(passingCheck!= 0){
            pipePool[passingCheck-1].transform.position = new Vector3(round_i * pipeSpaceing+2, Random.Range(-1f, 1f), 0);
            if(passingCheck == amountFirstPipe){
                passingCheck = 0;
            }
            round_i++;
        }
    }


    public void GameOver(){
        gameOver = true;
        soundManager.DieSoundActive();
        canvasGameOver.SetActive(true);
        textBestScore.text = PlayerPrefs.GetInt("BEST").ToString();
    }

    public void AddScore(){
        if(gameOver){
            return;
        }

        soundManager.ScoreUpSoundActive();
        score++;
        textScore.text = score.ToString();

        if(score > best){
            PlayerPrefs.SetInt("BEST", score);
            PlayerPrefs.Save();
        }
    }

    public void ResetBestScore(){
        PlayerPrefs.SetInt("BEST", 0);
        PlayerPrefs.Save();
    }
}
