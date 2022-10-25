using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText_IDIOMA : MonoBehaviour
{
    [SerializeField] private SO_text_IDIOMAS[] textos;
    private void Start()
    {
        updateText();
    }
    public void updateText()
    {
        GLOBAL_TYPES.IDIOMA m_idioma = DATA.instance.getIdioma_TYPE();
        //DATA.instance.save_load_system.m_dataGame.m_DATA_CONFIG_GAME.IDIOMA;
        //print("IDIOMA : "+ m_idioma);
        switch (m_idioma)
        {
            case GLOBAL_TYPES.IDIOMA.ES:
                {
                    for (int i = 0; i < textos.Length; i++) textos[i].textMesh.text = textos[i].texto_ESPANOL;
                    break;
                }
            case GLOBAL_TYPES.IDIOMA.EN:
                {
                    for (int i = 0; i < textos.Length; i++) textos[i].textMesh.text = textos[i].texto_INGLES;
                    break;
                }
        }
    }
}
