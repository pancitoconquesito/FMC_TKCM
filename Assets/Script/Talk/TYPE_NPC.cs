using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TYPE_NPC
{
    public enum NPC_NAME
    {
        test,
        largarto
    }

    internal static int getInt_NPC(NPC_NAME m_npc)
    {
        int retorno = 0;
        switch (m_npc)
        {
            case TYPE_NPC.NPC_NAME.test:
                {
                    retorno = 0;
                    break;
                }
            case TYPE_NPC.NPC_NAME.largarto:
                {
                    retorno = 1;
                    break;
                }
        }
        return retorno;
    }
}
