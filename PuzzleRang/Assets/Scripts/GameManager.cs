using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    // TO BE ABLE TO USE GAME MANAGER AND TEXTMESHPROUGUI IN OTHER SCENES
    public static GameManager Instance {get; private set;}

    public Button playButton;
    public Button settingsButton;
    public Button exitButton;
    public Button backButton;

    // For Background / Menu Music
    private AudioSource backgroundMusic;

    // For AudioClips
    private AudioSource[] sfxAudioSources;
    public AudioClip[] sFXAudioClips;

    public Slider musicSlider;
    public Slider sFXSlider;
    
    public TextMeshProUGUI musicVolume;
    public TextMeshProUGUI sFXVolume;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    public GameObject titleScreen;
    public GameObject settingsScreen;

    public bool isGameActive;
    private float time;
    private int score;

    // Start is called before the first frame update
    // ------ TO BE ABLE TO USE GAME MANAGER AND TEXTMESHPROUGUI IN OTHER SCENES ------
    private void Awake()
    {
        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Only one instance allowed
        }
    }

    void Start(){

        //Initialise the AudioSources for background music and SFX
        backgroundMusic = GetComponent<AudioSource>();
        sfxAudioSources = new AudioSource[sFXAudioClips.Length];

        // Use AddComponent to add new AudioSources 
        for (int i = 0; i < sFXAudioClips.Length; i++){
            sfxAudioSources[i] = gameObject.AddComponent<AudioSource>();
        }
        
        //Set initial volume and add listeners
        backgroundMusic.volume = musicSlider.value;
        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);

        UpdateSFXVolume(sFXSlider.value);
        sFXSlider.onValueChanged.AddListener(UpdateSFXVolume);
    }

    public void StartGame(){
        score = 0;
        time = 0;
        isGameActive = true;
        UpdateScore();
        titleScreen.SetActive(false);
        SceneManager.LoadScene("Day of the Deer");
    }

    // Update is called once per frame
    void Update(){
        UpdateTime();
    }

    public void UpdateTime(){
        if (isGameActive){
            time += Time.deltaTime;
            timerText.SetText("Time: " + Mathf.Round(time));
        }
    }

    public void UpdateScore(){
        score++;
        scoreText.text = "Score: " + score;
    }

    public void Settings(){
        titleScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void Exit(){
        //UnityEditor.EditorApplication.isPlaying = false;
        /* 
        UnityEditor keyward causes issues with uilding webGL
        */
        Application.Quit();
    }

    public void Back(){
        titleScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }


    // ----------------   FOR AUDIO   -------------------

    // Play specific sound effect by index without needing the clip set on the AudioSource
    public void PlaySFXByIndex(int index)
    {
        if (index >= 0 && index < sFXAudioClips.Length)
        {
            sfxAudioSources[index].PlayOneShot(sFXAudioClips[index]);
        }
    }

    // Background Music 
    public void UpdateMusicVolume(float volume){
        backgroundMusic.volume = volume;
        UpdateMusicVolumeText(volume);
    }

    public void UpdateMusicVolumeText(float volume){
        musicVolume.text = "Music:  " + (Mathf.Round(volume * 100f));
    }

    // SFX Volume
    public void UpdateSFXVolume(float volume){

        // For every audio in the array 
        foreach (var audio in sfxAudioSources){
            // Make sure it isn't the background music
            if (audio != backgroundMusic){
                // Set the Volume
                audio.volume = volume;
            }
        }

        UpdateSFXVolumeText(volume);
    }

    public void UpdateSFXVolumeText(float volume){
        sFXVolume.text = "SFX:  " + (Mathf.Round(volume * 100f));
    }
}
