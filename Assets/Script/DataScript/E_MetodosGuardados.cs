public static class E_MetodosGuardados
{
    //private static ISaveLoadSystem m_isaveLoad;

    public static void Save_DATA(DATA_GAME data, ISaveLoadSystem isa)
    {
        //ISaveLoadSystem m_isaveLoad = isa;
        isa.SAVE_DATA_GAME(data);
    }
    public static DATA_GAME Load_DATA(ISaveLoadSystem isa)
    {
        //m_isaveLoad = isa;
        return isa.LOAD_DATA_GAME();
    }
}
