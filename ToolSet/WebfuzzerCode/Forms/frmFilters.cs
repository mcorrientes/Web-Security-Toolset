using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace usertools.WebFuzzer.Forms
{
    public partial class frmFilters : Form
    {
        private List<FuzzerFilter> filters;
        public List<FuzzerFilter> Filters
        {
            get { return filters; }
            set { filters = value; }
        }

        public frmFilters()
        {
            InitializeComponent();
            filters = new List<FuzzerFilter>();
        }

        private void frmFilters_Load(object sender, EventArgs e)
        {
            comboBoxConditionType.SelectedIndex = 0;
            comboBoxFilterType.SelectedIndex = 0;
        }

        public void LoadFiltersToGui(List<FuzzerFilter> Filters)
        {
            foreach (FuzzerFilter Filter in Filters)
                AddFilterToGui(Filter);
        }

        public void LoadDefaultFilters()
        {
            FuzzerFilter Filter = new FuzzerFilter();
            Filter.Name = "Internal Server Error";
            Filter.ConditionValue = "500";
            Filter.FilterType = FuzzerFilter.FilterTypes.Include;
            Filter.ConditionType = FuzzerFilter.ConditionTypes.ResponseStatusCode;
            filters.Add(Filter);

            AddFilterToGui(Filter);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
            if (listViewFilters.SelectedIndices.Count == 0)
                return;

            FuzzerFilter Filter = new FuzzerFilter();
            Filter.Name = textBoxFilterName.Text;
            Filter.ConditionValue = textBoxRegex.Text;
            if (comboBoxFilterType.SelectedIndex == 0)
                Filter.FilterType = FuzzerFilter.FilterTypes.Exclude;
            else
                Filter.FilterType = FuzzerFilter.FilterTypes.Include;

            if (comboBoxConditionType.SelectedIndex == 0)
                Filter.ConditionType = FuzzerFilter.ConditionTypes.ResponseStatusCode;
            else if (comboBoxConditionType.SelectedIndex == 1)
                Filter.ConditionType = FuzzerFilter.ConditionTypes.ResponseHTML;
            else if (comboBoxConditionType.SelectedIndex == 2)
                Filter.ConditionType = FuzzerFilter.ConditionTypes.ResponseHeaders;
            filters.Add(Filter);

            AddFilterToGui(Filter);
        }

        private void AddFilterToGui(FuzzerFilter Filter)
        {
            ListViewItem Item = new ListViewItem();
            Item.Text = Filter.Name;
            Item.SubItems.Add(Filter.FilterType.ToString());
            Item.SubItems.Add(Filter.ConditionType.ToString());
            Item.SubItems.Add(Filter.ConditionValue);
            listViewFilters.Items.Add(Item);
        }

        private void buttonDeleteFilter_Click(object sender, EventArgs e)
        {
            if (listViewFilters.SelectedIndices.Count == 0)
                return;

            int FilterIndex = listViewFilters.SelectedIndices[0];
            listViewFilters.Items.RemoveAt(FilterIndex);
            filters.RemoveAt(FilterIndex);
        }

        private void listViewFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Enable = listViewFilters.SelectedIndices.Count > 0;
            buttonDeleteFilter.Enabled = Enable;
        }
    }
}
