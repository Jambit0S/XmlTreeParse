﻿using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
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
		/// Сохранения объекта в виде документа.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</param>
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selectedNode = XmlTreeView.SelectedNode;

			if (selectedNode != null && selectedNode.Nodes.Count == 0 && selectedNode.Parent != null)
			{
				var res = new XmlHandler.XmlHandler(ConfigurationManager.AppSettings["xmldata"]);

				var xmlObj = res.GetObjectXml(selectedNode.Text, selectedNode.Parent.Text);

				SaveFile(xmlObj);
			}
			else
			{
				MessageBox.Show(ErrorMessageText.WrongNodeSelect, ErrorMessageText.Warning);
			}
		}

		/// <summary>
		/// Сохранение XML-документа.
		/// </summary>
		/// <param name="element">Xml-объект.</param>
		private void SaveFile(XElement element)
		{
			// Настройки проводника.
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "XML Files (*.xml)|*.xml";
			saveFileDialog1.Title = "Save an XML File";
			saveFileDialog1.ShowDialog();

			if (saveFileDialog1.FileName != "")
			{
				XmlSave.Save(element, saveFileDialog1.FileName);
			}
			else
			{
				MessageBox.Show(ErrorMessageText.ErrorMessageExplorerSaveFile, ErrorMessageText.Error);
			}
		}

		/// <summary>
		/// Выбор XML-документа через проводник.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</param>
		private void ButtonOpenFileExplorer_Click(object sender, EventArgs e)
		{
			// Настройки проводника.
			OpenFileDialog folderBrowser = new OpenFileDialog();			
			folderBrowser.Filter = "XML Files (*.xml)|*.xml";
			folderBrowser.Title = "Get an XML File";
			folderBrowser.ValidateNames = false;
			folderBrowser.CheckFileExists = true;
			folderBrowser.CheckPathExists = true;

			if (folderBrowser.ShowDialog() == DialogResult.OK)
			{
				TextBoxPath.Text = folderBrowser.FileName;
				ShowTree(folderBrowser.FileName);
			}
			else
			{
				MessageBox.Show(ErrorMessageText.ErrorMessageExplorerGetFile, ErrorMessageText.Error);
			}
		}

		/// <summary>
		/// Демонстранция дерева.
		/// </summary>
		private void ShowTree(string url)
		{
			XmlTreeView.Nodes.Clear();

			// Путь к документу.
			var uri = string.IsNullOrEmpty(url)
				? ConfigurationManager.AppSettings["xmldata"]
				: url;

			var result = new XmlHandler.XmlHandler(uri);

			// Получение тегов из словаря.
			var tags = Object_Dictionary.Tag_id.Select(item => item.Key).ToList();

			foreach (var tag in tags)	// Добавление всех PK по тегам.
			{
				var guid = Guid.NewGuid().ToString();

				XmlTreeView.Nodes.Add(guid, tag); // Родительский узел.

				var allId = result.GetObjectsId(tag);

				allId.ForEach(item =>
				{
					XmlTreeView.Nodes.Find(guid, false).First().Nodes.Add(item); // Наследник.
				});
			}
		}

		/// <summary>
		/// Вывод документа в консоль.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</para
		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selectedNode = XmlTreeView.SelectedNode;

			if (selectedNode != null && selectedNode.Nodes.Count == 0 && selectedNode.Parent != null)
			{
				var res = new XmlHandler.XmlHandler(ConfigurationManager.AppSettings["xmldata"]);

				var xmlObj = res.GetObjectXml(selectedNode.Text, selectedNode.Parent.Text);

				Console.WriteLine(xmlObj.ToString());
			}
			else
			{
				MessageBox.Show(ErrorMessageText.WrongNodeSelect, ErrorMessageText.Warning);
			}
		}
	}
}
