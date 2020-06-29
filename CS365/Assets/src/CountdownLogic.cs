using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownLogic : MonoBehaviour
{
    public List<Sprite> CountdownSprites;
    public List<AudioClip> CountdownSounds;

    public GameObject countdownObj;
    public GameObject player;

    public float scaleMin;
    public float scaleMax;

    public Timer timer;

    public Image flashTransition;
    public float transitionTime = 0.25f;

    private float counter;
    private int countState;

    private float transitionTimer;

    private Image spr;
    private Transform countdownTrans;
    private AudioSource countdownAudio;

    // Start is called before the first frame update
    void Start()
    {
        spr = countdownObj.GetComponent<Image>();
        countdownTrans = countdownObj.GetComponent<Transform>();
        countdownAudio = GetComponent<AudioSource>();

        counter = 1.0f;
        countState = 4;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        float transitionAlpha;
        if (transitionTimer < transitionTime)
        {
            transitionTimer += Time.deltaTime;
            transitionAlpha = 1 - 4.0f * transitionTimer;
        }
        else
            transitionAlpha = 0.0f;

        flashTransition.color = new Vector4(flashTransition.color.r, flashTransition.color.g, flashTransition.color.b, transitionAlpha);

        float alpha = 0.0f;

        if (counter < 0.25f)
            alpha = 4.0f * counter;
        else if (counter < 1.0f)
            alpha = 1.0f - (counter - 0.25f) * (1.0f / 0.75f);
        else
        {
            countState--;

            if (countState < 0)
            {
                spr.color = new Vector4(spr.color.r, spr.color.g, spr.color.b, 0.0f);
                enabled = false;
                return;
            }

            spr.sprite = CountdownSprites[countState];
            countdownAudio.clip = CountdownSounds[countState];
            countdownAudio.Play();

            if (countState == 0)
            {
                player.GetComponent<Ball>().isActive = true;
                player.GetComponent<Rigidbody>().isKinematic = false;
                timer.TimerStart();
            }

            counter = 0.0f;
        }

        Texture2D myTex = CountdownSprites[countState].texture;
        float textureAspectRatio = (float)myTex.width / (float)myTex.height;
        float currScale = counter - 1;
        currScale = (scaleMax - scaleMin) * currScale * currScale * currScale * currScale + scaleMin;
        countdownTrans.localScale = new Vector2(textureAspectRatio * currScale, currScale);

        spr.color = new Vector4(spr.color.r, spr.color.g, spr.color.b, alpha);
    }
}
