using UnityEngine;
public class Col_NekoEsfera : ItemsCol
{
    [Header("-- ColNeko Params --")]
    [SerializeField] private CambiarScene m_CambiarScene;
    [SerializeField] private float delayTransicion;
    [SerializeField] private float delayChangeStage;
    [SerializeField] private Collider2D m_Collider2D;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        //print("hijo");
        m_Collider2D.enabled = false;
        referencesMASTER.instancia.m_movementPJ.getNekoEsfera();
        Invoke("transicion", delayTransicion);
        Invoke("changeStage", delayChangeStage);
        //setNekoEsfera(int idPrefab)
        DATA.instance.save_load_system.setNekoEsfera(m_so_item.ID_ITEM);

        base.OnTriggerEnter2D(collision);
    }
    private void transicion()
    {
        referencesMASTER.instancia.m_anim_UI_transicion.SetTrigger("negro");
    }
    private void changeStage()
    {
        playBackgorundMusic m_playBackgorundMusic = GameObject.FindGameObjectWithTag("Data_Singleton").transform.GetChild(0).transform.GetComponent<playBackgorundMusic>();
        m_playBackgorundMusic.setIndexBakcground(m_playBackgorundMusic.parseNameBackground(playBackgorundMusic.NAME_BACKGROUND.nivel));
        m_playBackgorundMusic.startBackground_and_Stop();
        //print("changeStage");
        m_CambiarScene.changeScene();
    }
}
