using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    float totalBones=18; int collectedBones=0;
    public RectTransform progressBar;


    public static GameManager instance;

    public PlayerSc player;
    public CamFollower camFollow;
    public CleanPlace cleanPlace;
    public Transform exitBtn,rotateUI;

    public RotateBone rotateBone;
    public CleanSc clean;
    public PolishSc polish;

    Vector3 lastCamPos;


    public TextMeshProUGUI percentProgress;

    public Transform posMusuemSkeleton;
    public SkeletonSc skeleton;

    public Animator camAnim;
    public Transform camMusuemPos;


    public TextMeshProUGUI coinsTxt;
    int _coins; public int coins
    {
        get => _coins;
        set
        {
            _coins = value;
            coinsTxt.text = coins.ToString("00");
            coinsTxt.transform.parent.DOComplete();
            coinsTxt.transform.parent.DOPunchScale(Vector3.one * .15f, .1f);

            PlayerPrefs.SetInt("Coins", coins);
        }
    }


    public Gradient clothGradiant;

    public UpgradeSystem upgradeSystem;

    public Transform nextBtn;



    public void SetPercentProgress(string p)
    {
        percentProgress.text = p;
    }

    private void Awake()
    {
        instance = this;

		
		
    }
    private void Start()
    {
        UpdateProgressBar();
        coins = PlayerPrefs.GetInt("Coins");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Replay();
        }
    }

    public void SkeletonComplete()
    {
        StartCoroutine(coro());
        IEnumerator coro()
        {
            yield return new WaitForSeconds(1f);
            player.controller.SetState(false);
            camFollow.following = skeleton.transform;
            camFollow.SetFollowingState(false);
            camAnim.SetBool("Musuem", true);

            yield return new WaitForSeconds(1f);

            skeleton.ToMusuem();
            
            camFollow.transform.DOMove(camMusuemPos.position, 1.2f).OnComplete(() =>
            {
                
                camFollow.SetFollowingState(true);
            });
        }

        
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void NewBoneCollected()
    {
        collectedBones++;
        UpdateProgressBar();
    }
    void UpdateProgressBar()
    {
        progressBar.DOLocalMoveX(-progressBar.sizeDelta.x + (progressBar.sizeDelta.x * (collectedBones / totalBones)), .1f);
    }



    public void ToCleanPos()
    {
        cleanPlace.Enter();
        camFollow.SetFollowingState(false);
        player.transform.DOMove(cleanPlace.playerWaitPos.position, 1f);

        lastCamPos = camFollow.transform.position;
        camFollow.transform.DOMove(cleanPlace.camPos.position, 1f).SetEase(Ease.OutQuart);
        camFollow.transform.DORotate(cleanPlace.camPos.eulerAngles, 1f);

        player.controller.SetState(false);

        TriggerFunctions.instance.inCleanPlace = false;

        exitBtn.DOScale(Vector3.one, .5f);
        rotateUI.DOScale(Vector3.one, .5f);
        percentProgress.transform.DOScale(Vector3.one,.5f);

        rotateBone.working = true;
        clean.working = true;

        if (cleanPlace.boneInTable==null)
        {
            player.GetBoneToCleaning();
        }

        SetPercentProgress("START CLEANING");
    }
    public void ToIdlePos()
    {
        camFollow.transform.DOMove(lastCamPos, 1.5f).OnComplete(()=> camFollow.SetFollowingState(true));
        camFollow.transform.DORotate(camFollow.initRot, 1f);

        player.controller.SetState(true);
        exitBtn.DOScale(Vector3.zero, .5f);
        rotateUI.DOScale(Vector3.zero, .5f);
        percentProgress.transform.DOScale(Vector3.zero, .5f);

        rotateBone.working = false;
        clean.working = false;
    }

    public void ToPolishing()
    {
        clean.working = false;
        polish.currentBone = cleanPlace.boneInTable.texture;
        polish.working = true;
        clean.tool.DOMove(clean.initPos, .4f);
        clean.tool.transform.up = (clean.initUp);
        //cleanPlace.boneInTable.coll.convex = false;
    }
    public void ToCleaning()
    {
        polish.working = false;
        clean.working = true;
        
        polish.tool.DOMove(polish.initPos, .4f);
        polish.tool.transform.up = (polish.initUp);
        //cleanPlace.boneInTable.coll.convex = false;
    }

    public void Won()
    {
        nextBtn.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack);
        //
        //WON
        // level = PlayerPrefs.GetInt("Level").ToString()


        //
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        PlayerPrefs.SetInt("prevLevel", -1);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
