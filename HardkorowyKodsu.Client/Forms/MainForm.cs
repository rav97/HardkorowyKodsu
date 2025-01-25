using HardkorowyKodsu.Client.Services;
using HardkorowyKodsu.Client.Services.Interfaces;

namespace HardkorowyKodsu.Client.Forms
{
    public partial class MainForm : Form
    {
        private readonly IDatabaseApiService _apiClient;
        private readonly HashSet<string> validTags;

        public MainForm()
        {
            InitializeComponent();

            string apiBaseUrl = Environment.GetEnvironmentVariable("apiBaseUrl");
            _apiClient = ApiClient.CreateClient(apiBaseUrl);
            validTags = new HashSet<string>() { "table", "view" };
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var tables = await _apiClient.GetTablesAsync();
                var views = await _apiClient.GetViewsAsync();

                TreeNode tablesNode = new TreeNode("Tables") { Tag = "group" };
                TreeNode viewsNode = new TreeNode("Views") { Tag = "group" };

                foreach (var table in tables)
                {
                    TreeNode tableNode = new TreeNode(table) { Tag = "table" };
                    tablesNode.Nodes.Add(tableNode);
                }

                foreach (var view in views)
                {
                    TreeNode viewNode = new TreeNode(view) { Tag = "view" };
                    viewsNode.Nodes.Add(viewNode);
                }

                databaseTreeView.Nodes.Add(tablesNode);
                databaseTreeView.Nodes.Add(viewsNode);

                tablesNode.Expand();
                viewsNode.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured during loading of data: {ex.Message}");
            }
        }

        private async void databaseTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (validTags.Contains(e.Node.Tag.ToString()))
                {
                    var columns = await _apiClient.GetTableColumnsAsync(e.Node.Text);
                    columnsDataGrid.DataSource = columns;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured during loading of columns: {ex.Message}");
            }
        }
    }
}
