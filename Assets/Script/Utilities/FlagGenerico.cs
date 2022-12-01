using UnityEngine;
public class FlagGenerico : MonoBehaviour
{
    public enum TIPO_FLAG
    {
        soyCol_Escudo
    }
    [SerializeField] private TIPO_FLAG m_tipoFlag;
    public TIPO_FLAG Tipo_Flag
    {
        get
        {
            return m_tipoFlag;
        }
    }

}
