using Microsoft.Win32;
using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using WinFormApp;
using XmlHandler;

namespace WpfApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Получение файла из проводника.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</param>
		private void GetXmlTreePath(object sender, RoutedEventArgs e)
		{
			// Настройки проводника.
			OpenFileDialog folderBrowser = new OpenFileDialog();
			folderBrowser.Filter = "XML Files (*.xml)|*.xml";
			folderBrowser.Title = "Get an XML File";
			folderBrowser.ValidateNames = false;
			folderBrowser.CheckFileExists = true;
			folderBrowser.CheckPathExists = true;

			if ((bool)folderBrowser.ShowDialog())
			{
				XmlPathText.Text = folderBrowser.FileName;
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
			XmlTreeView.Items.Clear();

			// Путь к документу.
			var uri = string.IsNullOrEmpty(url)
				? ConfigurationManager.AppSettings["xmldata"]
				: url;

			var res = new XmlHandler.XmlHandler(uri);

			// Получение тегов из словаря.
			var tags = Object_Dictionary.Tag_id.Select(item => item.Key).ToList();

			foreach (var tag in tags)   // Добавление всех PK по тегам.
			{
				var treeItem = new TreeViewItem();
				treeItem.Header = tag;

				XmlTreeView.Items.Add(treeItem); // Родительский узел.

				var allId = res.GetObjectsId(tag);

				allId.ForEach(item =>
				{
					var subItem = new TreeViewItem();
					subItem.Header = item;
					treeItem.Items.Add(subItem); // Наследник.
				});

			}
		}

		/// <summary>
		/// Выбор узла дерева.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</param>
		private void SolutionTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var SelectedItem = XmlTreeView.SelectedItem as TreeViewItem;
			XmlTreeView.ContextMenu = XmlTreeView.Resources["SolutionContext"] as System.Windows.Controls.ContextMenu;
		}

		/// <summary>
		/// Сохранение узла в отдельном документа.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</param>
		private void SaveNodeInFile(object sender, RoutedEventArgs e)
		{
			var selectedNode = XmlTreeView.Tag as TreeViewItem;

			if (selectedNode != null && selectedNode.Items.Count == 0 && selectedNode.Parent != null)
			{
				var res = new XmlHandler.XmlHandler(ConfigurationManager.AppSettings["xmldata"]);

				var treeitem = (TreeViewItem)GetSelectedTreeViewItemParent(selectedNode);

				var xmlObj = res.GetObjectXml(selectedNode.Header.ToString(), treeitem.Header.ToString());

				SaveFile(xmlObj);
			}
			else
			{
				MessageBox.Show(ErrorMessageText.WrongNodeSelect, ErrorMessageText.Warning);
			}
		}

		/// <summary>
		/// Получение Родительского узла.
		/// </summary>
		/// <param name="item">Потомок.</param>
		/// <returns>Родительский узел.</returns>
		public ItemsControl GetSelectedTreeViewItemParent(TreeViewItem item)
		{
			DependencyObject parent = VisualTreeHelper.GetParent(item);

			while (!(parent is TreeViewItem || parent is TreeView))
			{
				parent = VisualTreeHelper.GetParent(parent);
			}

			return parent as ItemsControl;
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
		/// Получение тега от выделенного узла.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</param>
		private void TreeViewItem_OnItemSelected(object sender, RoutedEventArgs e)
		{
			XmlTreeView.Tag = e.OriginalSource;
		}

		/// <summary>
		/// Вывод документа в консоль.
		/// </summary>
		/// <param name="sender">Ссылка на объект, вызвавший событие.</param>
		/// <param name="e">Объект события.</para
		private void SHowNodeInConsole(object sender, RoutedEventArgs e)
		{
			var selectedNode = XmlTreeView.Tag as TreeViewItem;

			if (selectedNode != null && selectedNode.Items.Count == 0 && selectedNode.Parent != null)
			{
				var res = new XmlHandler.XmlHandler(ConfigurationManager.AppSettings["xmldata"]);

				var treeitem = (TreeViewItem)GetSelectedTreeViewItemParent(selectedNode);

				var xmlObj = res.GetObjectXml(selectedNode.Header.ToString(), treeitem.Header.ToString());

				Console.WriteLine(xmlObj.ToString());
			}
			else
			{
				MessageBox.Show(ErrorMessageText.WrongNodeSelect, ErrorMessageText.Warning);
			}
		}
    }
}
