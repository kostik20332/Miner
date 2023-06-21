using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElickInCapsuls : MonoBehaviour
{
    public GameObject elickEmpthyCapsulePrefab;
    public GameObject elickFromBoxPrefab;
    public GameObject elickFromBoxLastPrefab;
    public GameObject elickFromLiftPrefab;
    public GameObject elickTrackFirstPrefab;
    public GameObject elickTrackLastPrefab;
    public GameObject elickCapsuleInTrackPrefab;
    private GameObject elickCapsule;
    private GameObject elickCapsuleInTrack;
    private GameObject elickFromBox;
    public GameObject backGround;
    public GameObject elickStorage1;
    public GameObject elickStorage2;
    private GameObject elickStorage3;
    public GameObject lift;
    public GameObject track;
    public GameObject numbers;
    public GameObject wheel1;
    public GameObject wheel2;
    public GameObject wheel3;
    private bool liftMovingUp = true;
    public static bool liftAllowToMove = true;
    public static bool liftAnimating = false;
    public static bool liftAllowToAnimating = false;
    private bool animating = false;
    public static bool trackAnimating = false;
    public static bool trackDirectionIsRight = true;
    private bool allowedToMove = false;
    private bool face = true;
    private float liftSpeed = 200f;
    private float trackSpeed = 200f;
    private float trackWheelRotatingSpeed = 8f;
    private float levelCorrection = 0f;
    private ElickStorage storage1Script;
    private ElickStorage storage2Script;
    private ElickStorage storage3Script;
    public Image providerElickLevel;
    public TMP_Text capsulsInContainer1AmountText;
    public TMP_Text capsulsInContainer2AmountText;
    public TMP_Text capsulsInLiftAmountText;
    public TMP_Text capsulsAfterLiftAmountText;
    public TMP_Text capsulsInTrackAmountText;
    public static int capsulsInContainerAmount = 0;
    public static int[] capsulsInContainersAmount = new int[2];
    public static int capsulsInLiftAmount = 0;
    public static int trackMovingDirection = 1;
    public static int liftPositionForAnimating = 0;
    public static int liftMovingDirection = -1;
    public static int capsuleDestroiedAmount = 0;
    public static int capsuleAfterLiftAmount = 0;
    public static int capsuleInTrackAmount = 0;
    public static int capsuleSpawnedInTrackAmount = 0;

    private double elickStoragesSize = 2000;
    private double elickStorageSize = 1000;
    private double elickStoragesFillAmount = 0;
    private double elickStorage1FillAmount = 0;
    private double elickStorage2FillAmount = 0;
    private double elickStorage3FillAmount = 0;
    private double elickStorageFillPercent;
    private double elick1StorageFillPercent;
    private double elick2StorageFillPercent;
    private double elick3StorageFillPercent;
    private int elickStoragesAmount = 2;
    public TMP_Text storageFillAmountText;
    public TMP_Text storageSizeText;

    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            capsulsInContainersAmount[i] = 9;
        }
        //script = elickStorage.GetComponent<ElicMining>();
        storage1Script = elickStorage1.GetComponent<ElickStorage>();
        storage2Script = elickStorage2.GetComponent<ElickStorage>();
        StartCoroutine(CapsuleSpawn());
        StartCoroutine(ProviderElickSpawn());
    }

    void FixedUpdate()
    {
        elickStoragesFillAmount = elickStorage1FillAmount + elickStorage2FillAmount + elickStorage3FillAmount;
        storageFillAmountText.text = "" + (float)Math.Round(elickStoragesFillAmount, 1) + "/";
        storageSizeText.text = "" + (float)Math.Round(elickStoragesSize, 1);

        if(elickStoragesAmount == 1)
        {
            if (elick1StorageFillPercent <= 1.0)
            {
                if ((elickStorageSize - elickStorage1FillAmount) > 3.0)
                {
                    elickStorage1FillAmount += 3.0;
                }
                else
                {
                    elickStorage1FillAmount += (elickStorageSize - elickStorage1FillAmount);
                }
            }
            elick1StorageFillPercent = elickStorage1FillAmount / elickStorageSize;
            storage1Script.elickLevel.fillAmount = (float)elick1StorageFillPercent;
        }
        else if (elickStoragesAmount == 2)
        {
            if (elick1StorageFillPercent < 1)
            {
                if ((elickStorageSize - elickStorage1FillAmount) > 3.0)
                {
                    elickStorage1FillAmount += 3.0;
                }
                else
                {
                    elickStorage1FillAmount += (elickStorageSize - elickStorage1FillAmount);
                }
                elick1StorageFillPercent = elickStorage1FillAmount / elickStorageSize;
                storage1Script.elickLevel.fillAmount = (float)elick1StorageFillPercent;
            }
            else if (elick1StorageFillPercent >= 1)
            {
                if ((elickStorageSize - elickStorage2FillAmount) > 3.0)
                {
                    elickStorage2FillAmount += 3.0;
                }
                else
                {
                    elickStorage2FillAmount += (elickStorageSize - elickStorage2FillAmount);
                }
                elick1StorageFillPercent = elickStorage2FillAmount / elickStorageSize;
                storage2Script.elickLevel.fillAmount = (float)elick1StorageFillPercent;
            }

        }



        capsulsInContainer1AmountText.text = "" + capsulsInContainersAmount[0];
        capsulsInContainer2AmountText.text = "" + capsulsInContainersAmount[1];

        capsulsInLiftAmountText.text = "" + capsulsInLiftAmount;
        capsulsAfterLiftAmountText.text = "" + capsuleAfterLiftAmount;
        capsulsInTrackAmountText.text = "" + capsuleInTrackAmount;

        //управление лифтом
        //if(lift.transform.position.y <= 681f)
        //{
        //    liftMovingUp = true;
        //    if (!animating && capsulsInContainerAmount >= 10)
        //    {
        //        animating = true;
        //        allowedToMove = false;
        //        StartCoroutine(Animating(831f, -570f, 0, elickFromBoxPrefab));
        //    }
        //    else if(animating && capsuleDestroiedAmount >= 10)
        //    {
        //        animating = false;
        //        allowedToMove = true;
        //    }
        //    else if(!animating && capsulsInContainerAmount < 10)
        //    {
        //        allowedToMove = false;
        //    }
        //}
        //else if(lift.transform.position.y >= 1719f)
        //{
        //    liftMovingUp = false;

        //    if (!animating)
        //    {
        //        animating = true;
        //        allowedToMove = false;
        //        StartCoroutine(Animating(525f, 520f, 1, elickFromLiftPrefab));
        //    }
        //    else if (animating && capsuleDestroiedAmount >= 10)
        //    {
        //        animating = false;
        //        allowedToMove = true;
        //    }
        //    else if (!animating && capsuleAfterLiftAmount < 10)
        //    {
        //        allowedToMove = false;
        //    }
        //}
        //else if(lift.transform.position.y >= 700f && lift.transform.position.y <= 1400f)
        //{
        //    capsuleDestroiedAmount = 0;
        //}
        if (liftAnimating)
        {
            switch (liftPositionForAnimating)
            {
                case 3:
                    StartCoroutine(Animating(525f, 520f, 1, elickFromLiftPrefab, elickFromBoxLastPrefab));
                    break;
                case 2:
                    
                    break;
                case 1:
                    StartCoroutine(Animating(831f, -230f, -1, elickFromBoxPrefab, elickFromBoxLastPrefab));
                    break;
                case 0:
                    StartCoroutine(Animating(831f, -570f, 0, elickFromBoxPrefab, elickFromBoxLastPrefab));
                    break;
            }
        }

        if (liftAllowToMove)
        {
            switch (liftMovingDirection)
            {
                case 1:
                    lift.transform.Translate(Vector3.up * Time.deltaTime * trackSpeed, Space.World);
                    break;
                case -1:
                    lift.transform.Translate(Vector3.down * Time.deltaTime * trackSpeed, Space.World);
                    break;
            }
        }

        //if (liftMovingUp && !animating && allowedToMove)
        //{
        //    lift.transform.Translate(Vector3.up * Time.deltaTime * liftSpeed, Space.World);
        //}
        //else if(!liftMovingUp && !animating && allowedToMove)
        //{
        //    lift.transform.Translate(Vector3.down * Time.deltaTime * liftSpeed, Space.World);
        //}

        if(trackDirectionIsRight != face)
        {
            TrackFlip();
        }

        if (capsuleSpawnedInTrackAmount < capsuleInTrackAmount)
        {
            for(int i = capsuleSpawnedInTrackAmount; i < capsuleInTrackAmount; i++)
            {
                elickCapsuleInTrack = Instantiate(elickCapsuleInTrackPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
                elickCapsuleInTrack.transform.SetParent(track.transform, false);
                levelCorrection = (((i - 1) / 10) % 2);
                elickCapsuleInTrack.transform.position = new Vector3((track.transform.position.x + 19.5f + (12f * (((i) % 10) - (1 * levelCorrection))) + levelCorrection * 6f), (track.transform.position.y - 33.5f + (10f * ((i) / 10))), 0f);
            }
            capsuleSpawnedInTrackAmount = capsuleInTrackAmount;
        }

        switch (trackMovingDirection)
        {
            case 1:
                track.transform.Translate(Vector3.right * Time.deltaTime * trackSpeed, Space.World);
                wheel1.transform.Rotate(0f, 0f, trackWheelRotatingSpeed, Space.Self);
                wheel2.transform.Rotate(0f, 0f, trackWheelRotatingSpeed, Space.Self);
                wheel3.transform.Rotate(0f, 0f, trackWheelRotatingSpeed, Space.Self);
                break;
            case 0:
                if (!trackAnimating)
                {
                    if (face)
                    {

                        trackMovingDirection = 1;

                    }
                    else
                    {
                        if(capsuleAfterLiftAmount >= 10f)
                        {
                            trackAnimating = true;
                            StartCoroutine(TrackAnimating(273f, 520f, 1, elickTrackFirstPrefab, elickTrackLastPrefab));
                        }
                    }
                }
                break;
            case -1:
                track.transform.Translate(Vector3.left * Time.deltaTime * trackSpeed, Space.World);
                wheel1.transform.Rotate(0f, 0f, trackWheelRotatingSpeed, Space.Self);
                wheel2.transform.Rotate(0f, 0f, trackWheelRotatingSpeed, Space.Self);
                wheel3.transform.Rotate(0f, 0f, trackWheelRotatingSpeed, Space.Self);
                break;
        }
    }

    IEnumerator CapsuleSpawn()
    {
        while (true)
        {
            elickCapsule = Instantiate(elickEmpthyCapsulePrefab, new Vector3(1410f, -500.2f, 0f), Quaternion.identity);
            elickCapsule.transform.SetParent(backGround.transform, false);
            yield return new WaitForSeconds(2.5f);
        }
    }
    
    IEnumerator ProviderElickSpawn()
    {
        while(providerElickLevel.fillAmount < 1f)
        {
            providerElickLevel.fillAmount += 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    IEnumerator Animating(float x, float y, int variant, GameObject capsulePrefab, GameObject capsuleLastPrefab)
    {
        liftAnimating = false;
        for (int i = 0; i < 9; i++)
        {
            elickFromBox = Instantiate(capsulePrefab, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 43));
            elickFromBox.transform.SetParent(backGround.transform, false);
            switch (variant)
            {
                case -1:
                    capsulsInContainersAmount[1]--;
                    break;
                case 0:
                    capsulsInContainersAmount[0]--;
                    break;
                case 1:
                    capsulsInLiftAmount--; 
                    break;
                case 2:
                    capsuleAfterLiftAmount--;
                    break;
            }
            yield return new WaitForSeconds(0.4f);
        }
        switch (variant)
        {
            case -1:
                capsulsInContainersAmount[1]--;
                break;
            case 0:
                capsulsInContainersAmount[0]--;
                break;
            case 1:
                capsulsInLiftAmount--;
                break;
            case 2:
                capsuleAfterLiftAmount--;
                break;
        }
        elickFromBox = Instantiate(capsuleLastPrefab, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 43));
        elickFromBox.transform.SetParent(backGround.transform, false);
    }

    IEnumerator TrackAnimating(float x, float y, int variant, GameObject capsuleFirst9Prefab, GameObject capsuleLastPrefab)
    {
        for (int i = 0; i < 9; i++)
        {
            elickFromBox = Instantiate(capsuleFirst9Prefab, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 43));
            elickFromBox.transform.SetParent(backGround.transform, false);
            switch (variant)
            {
                case 1:
                    capsuleAfterLiftAmount--;
                    break;
                case 2:
                    capsuleInTrackAmount--;
                    break; 
            }
            yield return new WaitForSeconds(0.4f);
        }
        switch (variant)
        {
            case 1:
                capsuleAfterLiftAmount--;
                break;
            case 2:
                capsuleInTrackAmount--;
                break;
        }
        elickFromBox = Instantiate(capsuleLastPrefab, new Vector3(x, y, 0f), Quaternion.Euler(0, 0, 43));
        elickFromBox.transform.SetParent(backGround.transform, false);
    }

    void TrackFlip()
    {
        face = !face;
        Vector3 Scaler = track.transform.localScale;
        Scaler.x *= -1;
        track.transform.localScale = Scaler;
        Scaler = numbers.transform.localScale;
        Scaler.x *= -1;
        numbers.transform.localScale = Scaler;
    }
}
