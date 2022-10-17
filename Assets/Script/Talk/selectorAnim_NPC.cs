using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class selectorAnim_NPC : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    private int valorNPC;
    public TYPE_NPC.NPC_NAME m_npc;
    void Start()
    {
        m_animator.SetInteger("valorNPC", TYPE_NPC.getInt_NPC(m_npc));//prmover a tipo de dato
        m_animator.SetTrigger("loadNPC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
