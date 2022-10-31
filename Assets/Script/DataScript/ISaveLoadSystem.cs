using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveLoadSystem 
{
    public void SAVE_DATA_GAME(DATA_GAME dataGame);
    public DATA_GAME LOAD_DATA_GAME();

}
