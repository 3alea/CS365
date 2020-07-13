using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneShowcaseCameraLogic : MonoBehaviour
{
    public Transform lookAtPos;
    public float cameraRadius;
    public float cameraHeight;
    public float cameraRotationSpeed;

    public QuoteManager mQuoteMgr;
    public Image flashTransition;
    public float transitionTime = 0.75f;

    private float cameraAngle;
    private Transform tr;
    private bool inTransition;

    private float waitTimer;

    // Start is called before the first frame update
    void Start()
    {
        inTransition = false;
        cameraAngle = 0.0f;
        waitTimer = 0.0f;
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.localPosition = new Vector3(cameraRadius * Mathf.Cos(cameraAngle) + lookAtPos.localPosition.x, cameraHeight, cameraRadius * Mathf.Sin(cameraAngle) + lookAtPos.localPosition.z);
        tr.LookAt(lookAtPos);

        cameraAngle += Time.deltaTime * cameraRotationSpeed;

        if (Input.anyKey)
        {
            inTransition = true;
            mQuoteMgr.TerminateFade();
        }

        if (inTransition)
        {
            if (waitTimer >= transitionTime)
            {
                flashTransition.color = new Color(flashTransition.color.r, flashTransition.color.g, flashTransition.color.b, 1.0f);

                FocusedCamera camLogic = GetComponent<FocusedCamera>();
                BoulderLevelCamera boulderCamLogic = GetComponent<BoulderLevelCamera>();

                if (camLogic != null)
                    camLogic.enabled = true;
                else if (boulderCamLogic != null)
                    boulderCamLogic.enabled = true;

                GetComponent<CountdownLogic>().enabled = true;
                this.enabled = false;
            }
            else
            {
                waitTimer += Time.deltaTime;

                float alpha = Mathf.Lerp(0.0f, 1.0f, (1.0f / transitionTime) * waitTimer);
                flashTransition.color = new Color(flashTransition.color.r, flashTransition.color.g, flashTransition.color.b, alpha);
            }

        }
    }
}
