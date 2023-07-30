using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Ookii.Dialogs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace WilmerVRV_DataPrep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        WilmerVRV_tests vrv = new WilmerVRV_tests();
        
        public MainWindow()
        {
            InitializeComponent();
            AddTasks(vrv.wilmerVRVTasks);
        }

        private void AddTasks(Dictionary<string,int[]> taskNameList)
        {
            Style s = (Style)FindResource("lB");

            foreach (string taskName in taskNameList.Keys)
            {
                ListBox newListBox = new ListBox() { Style = s };

                newListBox.Name = taskName;
                //newListBox.Background = Brushes.#FAFAFA;
                newListBox.Width = 500;

                AddTaskComponents(newListBox, taskName);
                TaskListBox.Items.Add(newListBox);
            }
        }
        private void AddTaskComponents(ListBox VRVTask, string taskName)
        {
            Label taskNameLabel = new Label();
            taskNameLabel.Width = 130;
            taskNameLabel.Height = 25;
            taskNameLabel.Content = VRVTask.Name.Replace("_"," ");
            VRVTask.Items.Add(taskNameLabel);

            string[] difficultyLevel = new string[] { "_0", "_1", "_2" }; //easy, medium, hard

            CheckBox cb;
            for (int i = 0; i < 3; i++)
            {
                cb = new CheckBox();
                cb.Foreground = Brushes.Black;
                cb.Height = 20;
                cb.Width = 60;
                cb.Name = "CheckBox_" + taskName + difficultyLevel[i];

                cb.Checked += CheckBoxDifficultyLevel_Checked;
                cb.Unchecked += CheckBoxDifficultyLevel_Unchecked;

                VRVTask.Items.Add(cb);
            }

        }
        
        private void CheckBoxDifficultyLevel_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox cb = sender as CheckBox;
            string[] name = cb.Name.ToString().Split('_');
            int i = Convert.ToInt32(name[2]);

            vrv.wilmerVRVTasks[name[1]][i] = 1;
        }

        private void CheckBoxDifficultyLevel_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            string[] name = cb.Name.ToString().Split('_');
            int i = Convert.ToInt32(name[2]);

            vrv.wilmerVRVTasks[name[1]][i] = 0;
        }

        private void CreatePlaylist_Click(object sender, RoutedEventArgs e)
        {

            object obj = new WilmerVRV_tests();
            Type type = obj.GetType();

            int numberOfTests = Convert.ToInt32(NumberOfTestsTextBox.Text);
            int numberOfPlaylists = Convert.ToInt32(NumberOfPlaylistsTextBox.Text);
            int time = 3;

            //add the selected tests to the list
            List<List<WilmerVRVData>> selectedTasks = new(); 
            foreach (var item in vrv.wilmerVRVTasks) 
            {
                if (item.Value[0] == 0 && item.Value[1] == 0 && item.Value[2] == 0) { continue; }
                string methodName = item.Key.Replace("_", "");

                List<WilmerVRVData> t = new List<WilmerVRVData>();
                if (item.Value[0]  == 1)
                {
                    MethodInfo method = type.GetMethod(methodName);
                    t.AddRange( method.Invoke(obj, new object[] { "easy", numberOfTests, time, true }) as List<WilmerVRVData> );
                }
                if(item.Value[1] == 1)
                {
                    MethodInfo method = type.GetMethod(methodName);
                    t.AddRange(method.Invoke(obj, new object[] { "medium", numberOfTests, time, true }) as List<WilmerVRVData>);
                }
                if (item.Value[2] == 1)
                {
                    MethodInfo method = type.GetMethod(methodName);
                    t.AddRange(method.Invoke(obj, new object[] { "hard", numberOfTests, time, true }) as List<WilmerVRVData>);
                }
                selectedTasks.Add(t);
            }

            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                string outputDir = dialog.SelectedPath;
                Writer.CreateMultipleJasons(selectedTasks, numberOfPlaylists, outputDir);
            }

        }

        private void TestNameLabel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EasyLabel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MediumLabel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HardLabel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
