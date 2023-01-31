public class RewardItem
{
    public string itemName;
    public string itemInfo;
    public int itemImg;
    public int itemHp;
    public int itemAtk;
    public float itemparryingDelay;
    public float itemattackingDelay;
    public bool skill_1;
    public bool skill_2;



    public RewardItem(string name, string Info, int Img, int Hp, int atk, float pdelay , float adelay, bool skill1,bool skill2)
    {
        itemName = name;
        itemInfo = Info;
        itemImg = Img;
        itemHp = Hp;
        itemAtk = atk;
        itemparryingDelay = pdelay;
        itemattackingDelay = adelay;
        skill_1 = skill1;
        skill_2 = skill2;
    }
}
