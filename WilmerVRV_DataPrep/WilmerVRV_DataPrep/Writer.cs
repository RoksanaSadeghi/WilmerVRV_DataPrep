using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace WilmerVRV_DataPrep
{
    class Writer
    {
        static Random rand_ = new Random();

        public static void CreateMultipleJasons(List<List<WilmerVRVData>> playlist, int numOfPlaylists, string outputDir)
        {
            for (int i = 0; i < numOfPlaylists; i++)
            {
                string outputFile = Path.Combine(outputDir,i.ToString());
                List<WilmerVRVData> p = MergeLists(RandomizeOrder(playlist));
                CreateAJason(p, outputFile);
            }

        }
        
        private static void CreateAJason(List<WilmerVRVData> playlist, string outputFile)
        {
            ExperimentList experimentList_ = new ExperimentList { experiments_list = playlist };
            string json = JsonSerializer.Serialize(experimentList_);
            json = json.Replace("\\u0027", "'");
            File.WriteAllText(outputFile, json);
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

        

    }
}
