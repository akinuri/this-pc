using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;

public static class Summary
{

    public static Dictionary<string, string> GetSystemInfo(string[]? keys = null)
    {
        keys ??= new string[0];
        Dictionary<string, string> info = new Dictionary<string, string>();
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
                foreach (var item in result.CimInstanceProperties)
                {
                    string value = item.Value?.ToString() ?? "";
                    var stringArray = item.Value as string[];
                    if (stringArray != null)
                    {
                        value = string.Join(", ", stringArray);
                    }
                    if (keys.Count() == 0 || keys.Contains(item.Name))
                    {
                        info.Add(item.Name, value);
                    }
                }
            }
            cimSession.Dispose();
        }
        catch (Exception ex)
        {
            //Logger.error(ex.Message);
        }
        return info;
    }

    public static void PopulateListView(ListView listView)
    {
        var summary = GetSystemInfo(new string[3] { "Manufacturer", "Model", "SystemSKUNumber" });

        ListViewGroup listViewGroup1 = new ListViewGroup("Device", HorizontalAlignment.Left);
        listViewGroup1.Header = "Device";
        listViewGroup1.Name = "listViewGroup1";
        listView.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });

        ListViewItem listViewItem1 = new ListViewItem(new string[] {"Manufacturer", summary["Manufacturer"] ?? ""}, -1);
        ListViewItem listViewItem2 = new ListViewItem(new string[] {"Model", summary["Model"] ?? "" }, -1);
        ListViewItem listViewItem3 = new ListViewItem(new string[] {"SKU", summary["SystemSKUNumber"] ?? "" }, -1);

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
