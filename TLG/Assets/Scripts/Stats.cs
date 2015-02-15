
public class Stats
{
    private float stamina;
    private float strength;
    private float speed;
    private float dexterity;
    private float intellect;
    private float recovery;
    private float reflex;

    public Stats()
    {
        Stamina = 1;
        Strength = 1;
        Speed = 1;
        Dexterity = 1;
        Intellect = 1;
        Recovery = 1;
        Reflex = 1;
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