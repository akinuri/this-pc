using System.Text.RegularExpressions;

public static class Summary
{

    public static void PopulateListView(ListView listView)
    {
        ListViewGroup listViewGroup1 = new ListViewGroup("Device", HorizontalAlignment.Left);
        listViewGroup1.Header = "Device";
        listViewGroup1.Name = "listViewGroup1";
        listView.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });

        ListViewItem listViewItem1 = new ListViewItem(new string[] {"Manufacturer", "LENOVO"}, -1);
        ListViewItem listViewItem2 = new ListViewItem(new string[] {"Model", "80SR"}, -1);
        ListViewItem listViewItem3 = new ListViewItem(new string[] {"SKU", "LENOVO_MT_80SR_BU_idea_FM_Lenovo ideapad 510-15ISK"}, -1);

        listViewItem1.Group = listViewGroup1;
        listViewItem2.Group = listViewGroup1;
        listViewItem3.Group = listViewGroup1;

        listView.Items.AddRange(new ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
        });
    }

}
