
public class Stats
{ 
    private float strength;
    private float speed;
    private float dexterity;
    private float stamina;
    private float intellect;
    private float recovery;
    private float reflex;

    public Stats(float str = 0, float spd = 0, float dex = 0, float stm = 0, float intl = 0, float rec = 0, float refl = 0)
    {
        Strength = str;
        Speed = spd;
        Dexterity = dex;
        Stamina = stm;
        Intellect = intl;
        Recovery = rec;
        Reflex = refl;
    }

    public float Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    public float Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; } 
    }

    public float Dexterity 
    {
        get { return dexterity; }
        set { dexterity = value; }
    }

    public float Intellect 
    {
        get { return intellect; }
        set { intellect = value; }
    }

    public float Recovery
    {
        get { return recovery; }
        set { recovery = value; }
    }

    public float Reflex 
    {
        get { return reflex; }
        set { reflex = value; }
    }
}