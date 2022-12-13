using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static SaveData saveData;
    [SerializeField] ulong Enter;
    string SavePath => Path.Combine(Application.persistentDataPath, "save.data");
    [SerializeField] GameObject SkillTreeMenu;
    [SerializeField] GameObject MainScreen;
    public int multicastValue = 0;
    #region berserker
    //skill tree buttons
    [SerializeField] GameObject two_right;
    [SerializeField] GameObject two_left;
    [SerializeField] GameObject three_right;
    [SerializeField] GameObject three_left;
    //skill tree bars
    [SerializeField] GameObject bar12r;
    [SerializeField] GameObject bar12l;
    [SerializeField] GameObject bar23r;
    [SerializeField] GameObject bar23l;
    //skill tree fx
    [SerializeField] GameObject btn1fx;
    [SerializeField] GameObject btn2lfx;
    [SerializeField] GameObject btn2rfx;
    [SerializeField] GameObject btn3lfx;
    [SerializeField] GameObject btn3rfx;
    #endregion

    #region Mage
    //skill tree buttons
    [SerializeField] GameObject mtwo_right;
    [SerializeField] GameObject mtwo_left;
    [SerializeField] GameObject mthree_right;
    [SerializeField] GameObject mthree_left;
    //skill tree bars
    [SerializeField] GameObject mbar12r;
    [SerializeField] GameObject mbar12l;
    [SerializeField] GameObject mbar23r;
    [SerializeField] GameObject mbar23l;
    //skill tree fx
    [SerializeField] GameObject mbtn1fx;
    [SerializeField] GameObject mbtn2lfx;
    [SerializeField] GameObject mbtn2rfx;
    [SerializeField] GameObject mbtn3lfx;
    [SerializeField] GameObject mbtn3rfx;
    #endregion

    #region ranger
    //skill tree buttons
    [SerializeField] GameObject rtwo_right;
    [SerializeField] GameObject rtwo_left;
    [SerializeField] GameObject rthree_right;
    [SerializeField] GameObject rthree_left;
    //skill tree bars
    [SerializeField] GameObject rbar12r;
    [SerializeField] GameObject rbar12l;
    [SerializeField] GameObject rbar23r;
    [SerializeField] GameObject rbar23l;
    //skill tree fx
    [SerializeField] GameObject rbtn1fx;
    [SerializeField] GameObject rbtn2lfx;
    [SerializeField] GameObject rbtn2rfx;
    [SerializeField] GameObject rbtn3lfx;
    [SerializeField] GameObject rbtn3rfx;
    #endregion

    private void Awake()
    {
        if (saveData == null)
            Load();
        else
            Save();
    }

    private void Save()
    {
        FileStream file = null;
        try
        {
            if (!Directory.Exists(Application.persistentDataPath))
                Directory.CreateDirectory(Application.persistentDataPath);
            file = File.Create(SavePath);
            var bf = new BinaryFormatter();
            bf.Serialize(file, saveData);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }

    private void Load()
    {
        FileStream file = null;
        try
        {
            file = File.Open(SavePath, FileMode.Open);
            var bf = new BinaryFormatter();
            saveData = (SaveData)bf.Deserialize(file);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            saveData = new SaveData();
        }
        finally
        {
            if (file != null)
                file.Close();
        }
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnUpgradeButtonClick()
    {
        MainScreen.SetActive(false);
        SkillTreeMenu.SetActive(true);
    }

    public void OnQuitButtonClick()
    {        
        Application.Quit();
    }
    #region Berserker tree
    public void OnUpgrade1ButtonClick()
    {
        btn1fx.SetActive(true);
        two_right.SetActive(true);
        two_left.SetActive(true);
        bar12l.SetActive(true);
        bar12r.SetActive(true);
    }
    public void OnUpgrade2rightButtonClick()
    {
        btn2rfx.SetActive(true);
        three_right.SetActive(true);
        bar23r.SetActive(true);
    }
    public void OnUpgrade2leftButtonClick()
    {
        btn2lfx.SetActive(true);
        three_left.SetActive(true);
        bar23l.SetActive(true);
    }
    public void OnUpgrade3leftButtonClick()
    {
        btn3lfx.SetActive(true);
        
    }
    public void OnUpgrade3rightButtonClick()
    {
        btn3rfx.SetActive(true);
        
    }
    #endregion

    #region Mage tree
    public void OnMage1ButtonClick()
    {
        mbtn1fx.SetActive(true);
        mtwo_right.SetActive(true);
        mtwo_left.SetActive(true);
        mbar12l.SetActive(true);
        mbar12r.SetActive(true);
    }
    public void OnMage2rightButtonClick()
    {
        mbtn2rfx.SetActive(true);
        mthree_right.SetActive(true);
        mbar23r.SetActive(true);
        multicastValue = 35;
    }
    public void OnMage2leftButtonClick()
    {
        mbtn2lfx.SetActive(true);
        mthree_left.SetActive(true);
        mbar23l.SetActive(true);
    }
    public void OnMage3leftButtonClick()
    {
        mbtn3lfx.SetActive(true);
        multicastValue = 70;
    }
    public void OnMage3rightButtonClick()
    {
        mbtn3rfx.SetActive(true);
    }
    #endregion

    #region Ranger tree
    public void OnRanger1ButtonClick()
    {
        rbtn1fx.SetActive(true);
        rtwo_right.SetActive(true);
        rtwo_left.SetActive(true);
        rbar12l.SetActive(true);
        rbar12r.SetActive(true);
    }
    public void OnRanger2rightButtonClick()
    {
        rbtn2rfx.SetActive(true);
        rthree_right.SetActive(true);
        rbar23r.SetActive(true);
    }
    public void OnRanger2leftButtonClick()
    {
        rbtn2lfx.SetActive(true);
        rthree_left.SetActive(true);
        rbar23l.SetActive(true);
    }
    public void OnRanger3leftButtonClick()
    {
        rbtn3lfx.SetActive(true);

    }
    public void OnRanger3rightButtonClick()
    {
        rbtn3rfx.SetActive(true);

    }
    #endregion

    public void OnReturnButtonClick()
    {
        MainScreen.SetActive(true);
        SkillTreeMenu.SetActive(false);
    }
}
