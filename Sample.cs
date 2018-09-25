public class Startup
{
    public Startup()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        var pageHelper = new PageHelper(list.Count, 1);
        while (pageHelper.NextPage())
        {
            Debug.WriteLine("Page: " + pageHelper.CurrentPage);
            while (pageHelper.NextItem())
            {
                Debug.WriteLine("Record: " + pageHelper.CurrentRecord);
            }
        }
    }
}
