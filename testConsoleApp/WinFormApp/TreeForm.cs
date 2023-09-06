using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XmlHandler;

namespace WinFormApp
{
	public partial class TreeForm : Form
	{
		public TreeForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Загрузка дерева.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</param>
		private void TreeForm_Load(object sender, EventArgs e)
		{
			var res = new XmlHandler.XmlHandler(ConfigurationManager.AppSettings["xmldata"]);

			var tags = Object_Dictionary.Tag_id.Select(item => item.Key).ToList();

			foreach (var tag in tags)
			{
				var guid = Guid.NewGuid().ToString();

				XmlTreeView.Nodes.Add(guid, tag);

				var allId = res.GetObjectsId(tag);

				allId.ForEach(item =>
				{
					XmlTreeView.Nodes.Find(guid, false).First().Nodes.Add(item);
				});
			}
		}

		/// <summary>
		/// Сохранения объекта в виде документа.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</param>
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selectedNode = XmlTreeView.SelectedNode;

			if (selectedNode != null && selectedNode.Nodes.Count == 0)
			{
				//Путь к новому файлу лежит в конфигурации проекта.
				var res = new XmlHandler.XmlHandler(ConfigurationManager.AppSettings["xmldata"]);

				var xmlObj = res.GetObjectXml(selectedNode.Text, selectedNode.Parent.Text);

				XmlSave.Save(xmlObj);
			}
			else
			{
				MessageBox.Show(ErrorMessageText.WrongNodeSelect, ErrorMessageText.Warning);
			}
		}
	}
}
