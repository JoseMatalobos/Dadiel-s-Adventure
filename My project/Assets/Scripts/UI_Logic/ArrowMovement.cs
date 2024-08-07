using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Transform pos1, pos2, pos3, pos4;
    public AudioClip arrowSfx, acceptSfx;
    AudioSource asr, asrMusic;

    CharSelectManagement charSelectManagement;

    private void Awake()
    {
        asr = GetComponent<AudioSource>();
        asrMusic = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    void Start()
    {
        charSelectManagement = GameObject.Find("CharSelectedManager").GetComponent<CharSelectManagement>();

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
            asr.PlayOneShot(acceptSfx);
        } else if (Input.GetKeyDown(KeyCode.Return) && this.transform.position == pos2.position) 
        {
            charSelectManagement.charSelected = "Raninja";
            asr.PlayOneShot(acceptSfx);
        }
        else if (Input.GetKeyDown(KeyCode.Return) && this.transform.position == pos3.position)
        {
            charSelectManagement.charSelected = "Pinka";
            asr.PlayOneShot(acceptSfx);
        }
        else if (Input.GetKeyDown(KeyCode.Return) && this.transform.position == pos4.position)
        {
            charSelectManagement.charSelected = "Turo";
            asr.PlayOneShot(acceptSfx);
        }
    }

    void Update()
    {
        ArrowMove();
        SelectChar();
    }
}
