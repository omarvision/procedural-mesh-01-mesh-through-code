using UnityEngine;

public class demo : MonoBehaviour
{
    public void Reset()
    {
        FindChild("near far sides").SetActive(true);
        FindChild("near").SetActive(false);
        FindChild("far").SetActive(false);
        FindChild("0").SetActive(false);
        FindChild("1").SetActive(false);
        FindChild("2").SetActive(false);
        FindChild("3").SetActive(false);
        FindChild("4").SetActive(false);
        FindChild("5").SetActive(false);
        FindChild("6").SetActive(false);
        FindChild("7").SetActive(false);

        FindChild("left right sides").SetActive(true);
        FindChild("left").SetActive(false);
        FindChild("right").SetActive(false);
        FindChild("8").SetActive(false);
        FindChild("9").SetActive(false);
        FindChild("10").SetActive(false);
        FindChild("11").SetActive(false);
        FindChild("12").SetActive(false);
        FindChild("13").SetActive(false);
        FindChild("14").SetActive(false);
        FindChild("15").SetActive(false);

        FindChild("bottom top sides").SetActive(true);
        FindChild("bottom").SetActive(false);
        FindChild("top").SetActive(false);
        FindChild("16").SetActive(false);
        FindChild("17").SetActive(false);
        FindChild("18").SetActive(false);
        FindChild("19").SetActive(false);
        FindChild("20").SetActive(false);
        FindChild("21").SetActive(false);
        FindChild("22").SetActive(false);
        FindChild("23").SetActive(false);
    }
    public void NearFar()
    {
        FindChild("near").SetActive(true);
        FindChild("far").SetActive(true);

        FindChild("near far sides").SetActive(true);
        FindChild("left right sides").SetActive(false);
        FindChild("bottom top sides").SetActive(false);        
    }
    public void NearFarPoints()
    {
        FindChild("0").SetActive(true);
        FindChild("1").SetActive(true);
        FindChild("2").SetActive(true);
        FindChild("3").SetActive(true);
        FindChild("4").SetActive(true);
        FindChild("5").SetActive(true);
        FindChild("6").SetActive(true);
        FindChild("7").SetActive(true);
    }
    public void LeftRight()
    {
        FindChild("left").SetActive(true);
        FindChild("right").SetActive(true);

        FindChild("near far sides").SetActive(false);
        FindChild("left right sides").SetActive(true);
        FindChild("bottom top sides").SetActive(false);
    }
    public void LeftRightPoints()
    {
        FindChild("8").SetActive(true);
        FindChild("9").SetActive(true);
        FindChild("10").SetActive(true);
        FindChild("11").SetActive(true);
        FindChild("12").SetActive(true);
        FindChild("13").SetActive(true);
        FindChild("14").SetActive(true);
        FindChild("15").SetActive(true);
    }
    public void BottomTopDesc()
    {
        FindChild("bottom").SetActive(true);
        FindChild("top").SetActive(true);

        FindChild("near far sides").SetActive(false);
        FindChild("left right sides").SetActive(false);
        FindChild("bottom top sides").SetActive(true);
    }
    public void BottomTopPoints()
    {
        FindChild("16").SetActive(true);
        FindChild("17").SetActive(true);
        FindChild("18").SetActive(true);
        FindChild("19").SetActive(true);
        FindChild("20").SetActive(true);
        FindChild("21").SetActive(true);
        FindChild("22").SetActive(true);
        FindChild("23").SetActive(true);
    }

    private GameObject FindChild(string name)
    {
        //level 1
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject lev1 = this.transform.GetChild(i).gameObject;
            if (lev1.name == name)
            {
                return lev1;
            }

            //level 2
            for (int j = 0; j < lev1.transform.childCount; j++)
            {
                GameObject lev2 = lev1.transform.GetChild(j).gameObject;
                if (lev2.name == name)
                {
                    return lev2;
                }

                //level 3
                for (int w = 0; w < lev2.transform.childCount; w++)
                {
                    GameObject lev3 = lev2.transform.GetChild(w).gameObject;
                    if (lev3.name == name)
                    {
                        return lev3;
                    }
                }
            }
        }

        return null;
    }
}
