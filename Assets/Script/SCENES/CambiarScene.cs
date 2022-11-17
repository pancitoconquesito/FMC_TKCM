using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarScene : MonoBehaviour
{
    [SerializeField] private string nameStage;
    [SerializeField] private float delay;
    [SerializeField] private bool StartChange;
    [SerializeField] private bool loadNameStage_singleton;
    private void Start()
    {
        if(StartChange) Invoke("changeStageWithOutDATA", delay);
    }
    public void setNameScene(string value)
    {
        nameStage = value;
    }
    public void changeScene()
    {
        if (loadNameStage_singleton) nameStage = referencesMASTER.instancia.m_Data_Singleton.getNextLevel_singleton();
        Invoke("changeStageNow",delay);
    }
    public void changeScene(string _name)
    {
        nameStage = _name;
        Invoke("changeStageNow", delay);
    }
    public void changeScene(float _delay)
    {
        Invoke("changeStageNow", _delay);
    }
    public void changeScene(string _name, float _delay)
    {
        nameStage = _name;
        Invoke("changeStageNow()", _delay);
    }
    private void changeStageNow()
    {
        //if(nameStage=="asdf") nameStage= DATA.instance.save_load_system.m_dataGame.m_DATA_PROGRESS.nameStageSaveRoom;
        if (loadNameStage_singleton && referencesMASTER.instancia.m_Data_Singleton.getNextLevel_singleton()=="") nameStage = "Nivel_1";
        try
        {
            referencesMASTER.instancia.m_Data_Singleton.setCantidadVidaPJ(3);

        }
        catch (System.Exception)
        {

            print("no existe reference master en scene");
        }
        SceneManager.LoadScene(nameStage);
    }
    private void changeStageWithOutDATA()
    {
        SceneManager.LoadScene(nameStage);
    }
}
