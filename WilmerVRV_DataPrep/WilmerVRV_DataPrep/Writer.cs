using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace WilmerVRV_DataPrep
{
    class Writer
    {
        static Random rand_ = new Random();

        public static void CreateMultipleJasons(string outputDir)
        {
            try
            {
                List<WilmerVRVData> testp = MergeLists();
                if (testp.Count == 0)
                {
                    string errorMessageTxt = "Please select a task!";
                    string captionError = "Failed";
                    MessageBoxButton buttonOK = MessageBoxButton.OK;
                    MessageBoxImage iconError = MessageBoxImage.Error;
                    MessageBoxResult error_;

                    error_ = MessageBox.Show(errorMessageTxt, captionError, buttonOK, iconError, MessageBoxResult.Yes);

                    return;
                }
                for (int i = 0; i < MainWindow.numberOfPlaylists; i++)
                {
                    string outputFile = Path.Combine(outputDir, (i + 1).ToString().PadLeft(3, '0'));
                    List<WilmerVRVData> p = MergeLists();
                    CreateAJason(p, outputFile);
                }

                //create the default one for the demo
                string defaultFile = Path.Combine(outputDir, "default");
                List<WilmerVRVData> default_p = DefaultJason();
                CreateAJason(default_p, defaultFile);

                string messageBoxText = "Finished: Output file(s) are created in the requested directory.\n" + outputDir;
                string caption = "Successful";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.None;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            }
            catch (Exception ex) { MessageBox.Show("ERROR: The output didn't created.\n" + ex.ToString()); }
        }

        private static void CreateAJason(List<WilmerVRVData> playlist, string outputFile)
        {
            ExperimentList experimentList_ = new ExperimentList { experiments_list = playlist };
            string json = JsonSerializer.Serialize(experimentList_);
            json = json.Replace("\\u0027", "'");
            File.WriteAllText(outputFile + ".json", json);

        }
        private static List<List<WilmerVRVData>> RandomizeOrder()
        {
            return MainWindow.selectedTasks.OrderBy(_ => rand_.Next()).ToList();
        }

        private static List<WilmerVRVData> MergeLists()
        {
            List<WilmerVRVData> mergedList = new List<WilmerVRVData>();

            List<List<WilmerVRVData>> practice = PracticeScene.selectedPracticeTasks;
            List<List<WilmerVRVData>> playlist = RandomizeOrder();
            foreach (var item in practice)
            {
                mergedList.AddRange(item);
            }
            foreach (var item in playlist)
            {
                mergedList.AddRange(item);
            }
            return mergedList;
        }

        private static List<WilmerVRVData> DefaultJason()
        {
            List<WilmerVRVData> mergedList = new List<WilmerVRVData>();
            mergedList.AddRange(WilmerVRV_tests.PracticeRoomLight());
            mergedList.AddRange(WilmerVRV_tests.PracticeTowel());
            mergedList.AddRange(WilmerVRV_tests.PracticeBottle());

            mergedList.AddRange(WilmerVRV_tests.Ball("easy"));
            mergedList.AddRange(WilmerVRV_tests.Ball("medium"));
            mergedList.AddRange(WilmerVRV_tests.Ball("hard"));

            mergedList.AddRange(WilmerVRV_tests.Bottle("easy"));
            mergedList.AddRange(WilmerVRV_tests.Bottle("medium"));
            mergedList.AddRange(WilmerVRV_tests.Bottle("hard"));

            mergedList.AddRange(WilmerVRV_tests.Candle("easy"));
            mergedList.AddRange(WilmerVRV_tests.Candle("medium"));
            mergedList.AddRange(WilmerVRV_tests.Candle("hard"));

            mergedList.AddRange(WilmerVRV_tests.Car("easy"));
            mergedList.AddRange(WilmerVRV_tests.Car("medium"));
            mergedList.AddRange(WilmerVRV_tests.Car("hard"));

            mergedList.AddRange(WilmerVRV_tests.ComputerScreen("easy"));
            mergedList.AddRange(WilmerVRV_tests.ComputerScreen("medium"));
            mergedList.AddRange(WilmerVRV_tests.ComputerScreen("hard"));

            mergedList.AddRange(WilmerVRV_tests.Cursor("easy"));
            mergedList.AddRange(WilmerVRV_tests.Cursor("medium"));
            mergedList.AddRange(WilmerVRV_tests.Cursor("hard"));

            mergedList.AddRange(WilmerVRV_tests.FlickerBrightness("easy"));
            mergedList.AddRange(WilmerVRV_tests.FlickerBrightness("medium"));
            mergedList.AddRange(WilmerVRV_tests.FlickerBrightness("hard"));

            mergedList.AddRange(WilmerVRV_tests.FlickerFrequency("easy"));
            mergedList.AddRange(WilmerVRV_tests.FlickerFrequency("medium"));
            mergedList.AddRange(WilmerVRV_tests.FlickerFrequency("hard"));

            mergedList.AddRange(WilmerVRV_tests.HandMovement("easy"));
            mergedList.AddRange(WilmerVRV_tests.HandMovement("medium"));
            mergedList.AddRange(WilmerVRV_tests.HandMovement("hard"));

            mergedList.AddRange(WilmerVRV_tests.LightBehindScreen("easy"));
            mergedList.AddRange(WilmerVRV_tests.LightBehindScreen("medium"));
            mergedList.AddRange(WilmerVRV_tests.LightBehindScreen("hard"));

            mergedList.AddRange(WilmerVRV_tests.Pill("east"));
            mergedList.AddRange(WilmerVRV_tests.Pill("medium"));
            mergedList.AddRange(WilmerVRV_tests.Pill("hard"));

            mergedList.AddRange(WilmerVRV_tests.PlaceSetting("easy"));
            mergedList.AddRange(WilmerVRV_tests.PlaceSetting("medium"));
            mergedList.AddRange(WilmerVRV_tests.PlaceSetting("hard"));

            mergedList.AddRange(WilmerVRV_tests.RoomLight("easy"));
            mergedList.AddRange(WilmerVRV_tests.RoomLight("medium"));
            mergedList.AddRange(WilmerVRV_tests.RoomLight("hard"));

            mergedList.AddRange(WilmerVRV_tests.Smudge("easy"));
            mergedList.AddRange(WilmerVRV_tests.Smudge("medium"));
            mergedList.AddRange(WilmerVRV_tests.Smudge("hard"));

            mergedList.AddRange(WilmerVRV_tests.Tie("easy"));
            mergedList.AddRange(WilmerVRV_tests.Tie("medium"));
            mergedList.AddRange(WilmerVRV_tests.Tie("hard"));

            mergedList.AddRange(WilmerVRV_tests.Towel("easy"));
            mergedList.AddRange(WilmerVRV_tests.Towel("medium"));
            mergedList.AddRange(WilmerVRV_tests.Towel("hard"));
            
            mergedList.AddRange(WilmerVRV_tests.TubeOfCream("easy"));
            mergedList.AddRange(WilmerVRV_tests.TubeOfCream("medium"));
            mergedList.AddRange(WilmerVRV_tests.TubeOfCream("hard"));
            
            mergedList.AddRange(WilmerVRV_tests.VerticalLine("easy"));
            mergedList.AddRange(WilmerVRV_tests.VerticalLine("medium"));
            mergedList.AddRange(WilmerVRV_tests.VerticalLine("hard"));

            mergedList.AddRange(WilmerVRV_tests.WindowBlinds("easy"));
            mergedList.AddRange(WilmerVRV_tests.WindowBlinds("medium"));
            mergedList.AddRange(WilmerVRV_tests.WindowBlinds("hard"));

            return mergedList;
        }

        

    }
}
