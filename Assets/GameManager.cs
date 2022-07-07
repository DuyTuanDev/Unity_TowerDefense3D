using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;

    public GameObject[] Bullets;
    public float panSpeed = 30f;
    public int indexEn;
    public int money = 200;
    public int currentMoney;
    public int currentLv;


    // public Button btnBatDau;
    public GameObject panelMenu;
    public int hpPlayer = 20;
    public bool isGameOver = false;
    public Text textTitle;
    public Text textDiemCao;
    public float speedEn = 1.75f;
    // public float speed;
    public GameObject panelHuongDan;


    public Button btnTiepTuc;
    public Joystick Joystick;
    void Start()
    {
        slideAudio.value = PlayerPrefs.GetFloat("AmLuong");
        instance = this;
        this.indexEn = -1;
        Time.timeScale = 0;
        if(PlayerPrefs.GetInt("choiMoi") == 1){
            panelMenu.SetActive(false);
            
            PlayerPrefs.SetInt("choiMoi", 0);
            Time.timeScale = 1;
        
        }
        else{
            btnTiepTuc.interactable = false;
        }
        currentMoney = money;
        currentLv = 1;
    }
    
    public void btnHuongDan(){
        audioSource.PlayOneShot(click);
        panelHuongDan.SetActive(true);
    }
    public void btnAnHuongDan(){
        audioSource.PlayOneShot(click);
        panelHuongDan.SetActive(false);
    }
    public void AudioPlay(){
        audioSource.PlayOneShot(click);
    }
    // Update is called once per frame
    public Text btnBullets;
    void Update()
    {
        if(indexEn == 0){
            btnBullets.text = "Đang chọn";
        }
        else{
            btnBullets.text = "Click chọn >";
        }
        audioSource.volume = slideAudio.value;
        // currentMoney = money;
        PlayerPrefs.SetFloat("AmLuong", audioSource.volume);
        
        if(!isGameOver){
            if(hpPlayer <= 0){
                Time.timeScale = 0;
                isGameOver = true;
                panelMenu.SetActive(true);
                textTitle.text = "GameOver";
            }
            else if(SpawnEnemy.instance.lever >= 21){
                Time.timeScale = 0;
                isGameOver = true;
                panelMenu.SetActive(true);
                textTitle.text = "Chiến Thắng\nLiên hệ: P.D Tuấn để nhận thưởng. (Nhớ chụp ảnh)";
            }
            else{
                textTitle.text = "MENU \nBy: Tuấn Đẹp Trai";
            }
                
        }
        else{
            btnTiepTuc.interactable = false;
        }
        textDiemCao.text = "Số tiền cao nhất: " + PlayerPrefs.GetInt("DiemCao") + "\nLv cao nhất: " + PlayerPrefs.GetInt("currentLv");
        if(PlayerPrefs.GetInt("DiemCao") < currentMoney){
            PlayerPrefs.SetInt("DiemCao", currentMoney);
        }
        if(PlayerPrefs.GetInt("currentLv") < currentLv){
            PlayerPrefs.SetInt("currentLv", currentLv);
            if(currentLv > 20){
                PlayerPrefs.SetInt("currentLv", 20);
            }
        }
    }
    public AudioSource audioSource;
    public AudioClip dat;
    public AudioClip click;
    public Slider slideAudio;

    public void SpawnBullets(Vector3 tranphom){
        if(indexEn == -1){
            return;
        }
        // audioClip.Play();
        audioSource.PlayOneShot(dat);
        Instantiate(Bullets[indexEn], tranphom, Bullets[indexEn].transform.rotation);
    }
    public void SetIndex(){
        audioSource.PlayOneShot(click);
        this.indexEn = 0;
    }
    public void SetIndex1(){
        this.indexEn = 1;
        
    }
    public void TiepTucBtn(){
        panelMenu.SetActive(false);
        audioSource.PlayOneShot(click);
        Time.timeScale = 1;
    }
    public void ChoiMoiBtn(){
        isGameOver = false;
        audioSource.PlayOneShot(click);
        PlayerPrefs.SetInt("choiMoi", 1);
        // this.indexEn = -1;
        // money = 500;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scene1");
        // SceneManager.LoadScene("Scene1");
        // LoadAssetAsync 
        
        // Time.timeScale = 1;
    }
    public void PauseBtn(){
        audioSource.PlayOneShot(click);
        panelMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitBtn(){
        audioSource.PlayOneShot(click);
        PlayerPrefs.SetInt("choiMoi", 2);
        Application.Quit();
    }
    
}
