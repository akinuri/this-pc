using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;

public static class Summary
{

    public static void PopulateListView(ListView listView)
    {
        string? manufacturer = null;
        string? model = null;
        string? sku = null;

        try
        {
            CimSession cimSession = CimSession.Create(null);
            var query = "SELECT * FROM Win32_ComputerSystem";
            var queryOptions = new CimOperationOptions { Timeout = TimeSpan.FromSeconds(2) };
            var results = cimSession.QueryInstances("root/cimv2", "WQL", query, queryOptions);
            CimInstance? result = null;
            if (results.Any())
            {
                result = results.First();
            }
            if (result != null)
            {
                manufacturer = result.CimInstanceProperties["Manufacturer"].Value.ToString();
                model = result.CimInstanceProperties["Model"].Value.ToString();
                sku = result.CimInstanceProperties["SystemSKUNumber"].Value.ToString();
            }
            cimSession.Dispose();
        }
        catch (Exception ex)
        {
            //Logger.error(ex.Message);
        }

        ListViewGroup listViewGroup1 = new ListViewGroup("Device", HorizontalAlignment.Left);
        listViewGroup1.Header = "Device";
        listViewGroup1.Name = "listViewGroup1";
        listView.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });

        ListViewItem listViewItem1 = new ListViewItem(new string[] {"Manufacturer", manufacturer ?? ""}, -1);
        ListViewItem listViewItem2 = new ListViewItem(new string[] {"Model", model ?? "" }, -1);
        ListViewItem listViewItem3 = new ListViewItem(new string[] {"SKU", sku ?? "" }, -1);

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
