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
using System.Windows.Shapes;

namespace WilmerVRV_DataPrep
{
    /// <summary>
    /// Interaction logic for PracticeScene.xaml
    /// </summary>
    public partial class PracticeScene : Window
    {
        public static List<List<WilmerVRVData>> selectedPracticeTasks = new();
        WilmerVRV_Practice vrv_practice = new WilmerVRV_Practice();
        public PracticeScene()
        {
            InitializeComponent();
            AddTasks(vrv_practice.wilmerVRVPracticeTasks);
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            CreatePracticePlaylist();

            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                string outputDir = dialog.SelectedPath;
                Writer.CreateMultipleJasons(outputDir);
            }
            this.Close();
        }

        private void CreatePracticePlaylist()
        {
            selectedPracticeTasks = new();
            object obj = new WilmerVRV_tests();
            Type type = obj.GetType();

            string[] orderedKey = new string[] {
            "Practice_RoomLight",
            "Practice_Towel",
            "Practice_Bottle",
            };

            for (int i = 0; i < orderedKey.Length; i++)
            {
                if (vrv_practice.wilmerVRVPracticeTasks[orderedKey[i]] == 0) { continue; }
                string methodName = orderedKey[i].Replace("_", "");

                List<WilmerVRVData> t = new List<WilmerVRVData>();

                MethodInfo method = type.GetMethod(methodName);
                t.AddRange(method.Invoke(obj, new object[] { "easy", MainWindow.numberOfTests, MainWindow.time, true }) as List<WilmerVRVData>);

                selectedPracticeTasks.Add(t);
            }
        }

        private void AddTasks(Dictionary<string, int> taskNameList)
        {
            Style s = (Style)FindResource("lB");

            foreach (string taskName in taskNameList.Keys)
            {
                ListBox newListBox = new ListBox() { Style = s };

                newListBox.Name = taskName;
                newListBox.Width = 500;

                AddTaskComponents(newListBox, taskName, 1);
                TaskListBox.Items.Add(newListBox);
            }
        }

        private void AddTaskComponents(ListBox VRTask, string taskName, int numLevels)
        {
            Label taskNameLabel = new Label();
            taskNameLabel.Width = 130;
            taskNameLabel.Height = 24;
            taskNameLabel.Content = VRTask.Name.Replace("_", " ");
            taskNameLabel.FontSize = 11;
            VRTask.Items.Add(taskNameLabel);

            CheckBox cb;
            for (int i = 0; i < numLevels; i++)
            {
                cb = new CheckBox();
                cb.Foreground = Brushes.Black;
                cb.Height = 24;
                cb.Width = 60;
                cb.Name = "CheckBox__" + taskName;

                cb.Checked += CheckBoxDifficultyLevel_Checked;
                cb.Unchecked += CheckBoxDifficultyLevel_Unchecked;
                VRTask.Items.Add(cb);
            }

        }

        private void CheckBoxDifficultyLevel_Checked(object sender, RoutedEventArgs e)
        {

            CheckBox cb = sender as CheckBox;
            string[] name = cb.Name.ToString().Split("__");
            vrv_practice.wilmerVRVPracticeTasks[name[1]] = 1;
        }

        private void CheckBoxDifficultyLevel_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            string[] name = cb.Name.ToString().Split("__");

            vrv_practice.wilmerVRVPracticeTasks[name[1]] = 0;
        }

        bool selectAll_ = true;
        private void TestNameBtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectAll_)
            {
                foreach (ListBox lb in TaskListBox.Items)
                {
                    for (int i = 1; i < lb.Items.Count; i++)
                    {
                        CheckBox tmp = (CheckBox)lb.Items[i];
                        tmp.IsChecked = true;
                    }
                }
                selectAll_ = false;
            }
            else
            {
                foreach (ListBox lb in TaskListBox.Items)
                {
                    for (int i = 1; i < lb.Items.Count; i++)
                    {
                        CheckBox tmp = (CheckBox)lb.Items[i];
                        tmp.IsChecked = false;
                    }
                }
                selectAll_ = true;
            }

        }
    }
}
