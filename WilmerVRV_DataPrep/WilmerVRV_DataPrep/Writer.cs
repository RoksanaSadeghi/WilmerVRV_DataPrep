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

        public static void CreateMultipleJasons(List<List<WilmerVRVData>> playlist, int numOfPlaylists, string outputDir)
        {
            try
            {
                for (int i = 0; i < numOfPlaylists; i++)
                {
                    string outputFile = Path.Combine(outputDir, (i+1).ToString().PadLeft(3, '0'));
                    List<WilmerVRVData> p = MergeLists(RandomizeOrder(playlist));
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
            catch (Exception ex) { MessageBox.Show("ERROR: The output didn't created.\n"+ex.ToString()); }


        }
        
        private static void CreateAJason(List<WilmerVRVData> playlist, string outputFile)
        {
            ExperimentList experimentList_ = new ExperimentList { experiments_list = playlist };
            string json = JsonSerializer.Serialize(experimentList_);
            json = json.Replace("\\u0027", "'");
            File.WriteAllText(outputFile + ".json", json);

        }
        private static List<List<WilmerVRVData>> RandomizeOrder(List<List<WilmerVRVData>> playlist)
        {
            return playlist.OrderBy(_=>rand_.Next()).ToList();
        }

        private static List<WilmerVRVData> MergeLists(List<List<WilmerVRVData>> playlist)
        {
            List<WilmerVRVData> mergedList = new List<WilmerVRVData>();
            mergedList.AddRange(WilmerVRV_tests.PracticeRoomLight());
            mergedList.AddRange(WilmerVRV_tests.PracticeTowel());
            mergedList.AddRange(WilmerVRV_tests.PracticeBottle());
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

            mergedList.AddRange(WilmerVRV_tests.Ball());
            mergedList.AddRange(WilmerVRV_tests.Bottle());
            mergedList.AddRange(WilmerVRV_tests.Candle());
            mergedList.AddRange(WilmerVRV_tests.Car());
            mergedList.AddRange(WilmerVRV_tests.ComputerScreen());
            mergedList.AddRange(WilmerVRV_tests.Cursor());
            mergedList.AddRange(WilmerVRV_tests.FlickerBrightness());
            mergedList.AddRange(WilmerVRV_tests.FlickerFrequency());
            mergedList.AddRange(WilmerVRV_tests.HandMovement());
            mergedList.AddRange(WilmerVRV_tests.LightBehindScreen());
            mergedList.AddRange(WilmerVRV_tests.Pill());
            mergedList.AddRange(WilmerVRV_tests.PlaceSetting());
            mergedList.AddRange(WilmerVRV_tests.RoomLight());
            mergedList.AddRange(WilmerVRV_tests.Smudge());
            mergedList.AddRange(WilmerVRV_tests.Tie());
            mergedList.AddRange(WilmerVRV_tests.Towel());
            mergedList.AddRange(WilmerVRV_tests.TubeOfCream());
            mergedList.AddRange(WilmerVRV_tests.VerticalLine());
            mergedList.AddRange(WilmerVRV_tests.WindowBlinds());
            
            return mergedList;
        }

        

    }
}
