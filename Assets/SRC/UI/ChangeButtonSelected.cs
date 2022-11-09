using UnityEngine;
using UnityEngine.EventSystems;
public class ChangeButtonSelected : MonoBehaviour
{
    [SerializeField] private GameObject m_GO_Selected;
    public void setGO_Selected()
    {
        EventSystem.current.SetSelectedGameObject(m_GO_Selected);
    }
    public void setGO_Selected(GameObject obj)
    {
        EventSystem.current.SetSelectedGameObject(obj);
    }
    private GameObject lastButtonSelected=null;
    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            //print("NULOOOOOOOOO!!!");
            if(lastButtonSelected!=null)
                EventSystem.current.SetSelectedGameObject(lastButtonSelected);
            else
                EventSystem.current.SetSelectedGameObject(m_GO_Selected);
        }
        else lastButtonSelected = EventSystem.current.currentSelectedGameObject;
    }
}
