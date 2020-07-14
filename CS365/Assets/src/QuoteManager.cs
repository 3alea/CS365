using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Original script by Ibai Abaunza, ask him for help
/// </summary>
public class QuoteManager : MonoBehaviour
{
    public Text mQuoteText; //text with quote
    public Text mPersonText; //text with person 
    public Image mBackGround; //background of the quote

    public float mFadeSpeed;

    private Color mTexCol;  //variable to set for the text
    private Color mPersCol; //variable to set for the text
    private Color mFadeOutCol;
    private bool mFadeIn;
    private bool mFadeEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        ResetQuote();
    }

    // Update is called once per frame
    void Update()
    {
        if (mFadeEnded) return;

        if (mFadeIn)
        {
            mTexCol.a = Mathf.Lerp(mTexCol.a, 1.0f, mFadeSpeed); //change color to quote
            mQuoteText.color = mTexCol;

            if (mTexCol.a > 0.95f) //if we finished fading quote
                mPersCol.a = Mathf.Lerp(mPersCol.a, 1.0f, mFadeSpeed); //fade name 

            mPersonText.color = mPersCol; //change actual name color

            if (mTexCol.a > 0.95f && mPersCol.a > 0.95f)
            {
                mFadeIn = false;
            }
        }
        else
        {
            mFadeOutCol.a = Mathf.Lerp(mFadeOutCol.a, 0.0f, mFadeSpeed);
            mPersonText.color = new Color(1.0f, 1.0f, 1.0f, mFadeOutCol.a); //change actual name color
            mQuoteText.color = new Color(1.0f, 1.0f, 1.0f, mFadeOutCol.a);
            mBackGround.color = mFadeOutCol;
        }
    }

    public void TerminateFade()
    {
        mFadeEnded = true;

        mPersonText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        mQuoteText.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        mBackGround.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    public void ResetQuote()
    {
        mTexCol = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        mPersCol = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        mFadeOutCol = mBackGround.color;
        mFadeIn = true;
        mFadeEnded = false;
    }
}
