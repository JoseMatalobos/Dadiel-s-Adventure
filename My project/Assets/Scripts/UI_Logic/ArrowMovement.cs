using System.Collections;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Transform pos1, pos2, pos3, pos4;
    public AudioClip arrowSfx, acceptSfx;

    AudioSource asr, asrMusic;

    CharSelectManagement charSelectManagement;
    AudioSourceScript audioSourceScript;
    ScenesManagement scenesManagement;

    private void Awake()
    {
        asr = GetComponent<AudioSource>();
    }

    void Start()
    {
        charSelectManagement = GameObject.Find("CharSelectedManager").GetComponent<CharSelectManagement>();
        audioSourceScript = GameObject.Find("Audio Source").GetComponent<AudioSourceScript>();
        asrMusic = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        scenesManagement = GameObject.Find("SceneManager").GetComponent<ScenesManagement>();

        InitialPosition();
    }

    public void InitialPosition() 
    {
        this.gameObject.transform.position = pos1.transform.position;
    }

    void ArrowMove() 
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (this.transform.position == pos1.position)
            {
                this.transform.position = pos2.position;
                asr.PlayOneShot(arrowSfx);
                asr.pitch = 1f;
            }
            else if (this.transform.position == pos2.position)
            {
                this.transform.position = pos3.position;
                asr.PlayOneShot(arrowSfx);
                asr.pitch = 1f;
            }
            else if (this.transform.position == pos3.position)
            {
                this.transform.position = pos4.position;
                asr.PlayOneShot(arrowSfx);
                asr.pitch = 1f;
            }
            else if (this.transform.position == pos4.position)
            {
                this.transform.position = pos1.position;
                asr.PlayOneShot(arrowSfx);
                asr.pitch = 1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (this.transform.position == pos1.position)
            {
                this.transform.position = pos4.position;
                asr.PlayOneShot(arrowSfx);
                asr.pitch = 1.1f;
            }
            else if (this.transform.position == pos2.position)
            {
                this.transform.position = pos1.position;
                asr.PlayOneShot(arrowSfx);
                asr.pitch = 1.1f;
            }
            else if (this.transform.position == pos3.position)
            {
                this.transform.position = pos2.position;
                asr.PlayOneShot(arrowSfx);
                asr.pitch = 1.1f;
            }
            else if (this.transform.position == pos4.position)
            {
                this.transform.position = pos3.position;
                asr.PlayOneShot(arrowSfx);
                asr.pitch = 1.1f;
            }
        }
    }

    public void SelectChar() 
    {
        if (Input.GetKeyDown(KeyCode.Return) && this.transform.position == pos1.position)
        {
            charSelectManagement.charSelected = "Mascaro";
            audioSourceScript.StopMusic();
            asr.PlayOneShot(acceptSfx);
            StartCoroutine(WaitAndLoadScene(60f, "World1"));
            scenesManagement.LoadScene("World1");
        } 
        else if (Input.GetKeyDown(KeyCode.Return) && this.transform.position == pos2.position) 
        {
            charSelectManagement.charSelected = "Raninja";
            audioSourceScript.StopMusic();
            asr.PlayOneShot(acceptSfx);
            StartCoroutine(WaitAndLoadScene(60f, "World1"));
            scenesManagement.LoadScene("World1");
        }
        else if (Input.GetKeyDown(KeyCode.Return) && this.transform.position == pos3.position)
        {
            charSelectManagement.charSelected = "Pinka";
            audioSourceScript.StopMusic();
            asr.PlayOneShot(acceptSfx);
            StartCoroutine(WaitAndLoadScene(60f, "World1"));
            scenesManagement.LoadScene("World1");
        }
        else if (Input.GetKeyDown(KeyCode.Return) && this.transform.position == pos4.position)
        {
            charSelectManagement.charSelected = "Turo";
            audioSourceScript.StopMusic();
            asr.PlayOneShot(acceptSfx);
            StartCoroutine(WaitAndLoadScene(60f, "World1"));
            scenesManagement.LoadScene("World1");
        }
    }

    private IEnumerator WaitAndLoadScene(float waitTime, string sceneName)
    {
        Debug.Log("Esperando " + waitTime + " segundos...");
        yield return new WaitForSeconds(60f);

        scenesManagement.LoadScene(sceneName);
    }

    void Update()
    {
        ArrowMove();
        SelectChar();
    }
}
