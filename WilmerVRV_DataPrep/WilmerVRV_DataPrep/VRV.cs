using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilmerVRV_DataPrep
{

    public class ExperimentList
    {
        public List<WilmerVRVData> experiments_list { get; set; }
    }
    public class WilmerVRVData// : IEquatable<WilmerVRVData>
    {
        public string sceneName { get; set; }
        public string sceneTitle { get; set; }
        public int sceneIndex { get; set; }
        public int presentationTime { get; set; }
        public Option_dict option_dict { get; set; }
    }

    public class Option_dict
    {
        public string[] key_strings { get; set; }
        public Option_dict_Value[] value_strings { get; set; }
    }

    public class Option_dict_Value// : IEquatable<Option_dict_Value>
    {
        public string ToggleName { get; set; }
        public string PrettyName { get; set; }
    }


    public class WilmerVRV_tests
    {

        public Dictionary<string, int[]> wilmerVRVTasks = new Dictionary<string, int[]>()
        {
            { "Ball",new int[]{0, 0, 0 } },
            { "Bottle", new int[]{0, 0, 0 } },
            { "Candle", new int[]{0, 0, 0 } },
            { "Car", new int[]{0, 0, 0 } },
            { "Computer_Screen", new int[]{0, 0, 0 } },
            { "Cursor", new int[]{0, 0, 0 } },
            { "Flicker_Frequency", new int[]{0, 0, 0 } },
            { "Flicker_Brightness", new int[]{0, 0, 0 } },
            { "Hand_Movement", new int[]{0, 0, 0 } },
            { "Light_Behind_Screen", new int[]{0, 0, 0 } },
            { "Pill", new int[]{0, 0, 0 } },
            { "Place_Setting", new int[]{0, 0, 0 } },
            { "Room_Light", new int[]{0, 0, 0 } },
            { "Smudge", new int[]{0, 0, 0 } },
            { "Tie", new int[]{0, 0, 0 } },
            { "Towel", new int[]{0, 0, 0 } },
            { "Tube_Of_Cream", new int[]{0, 0, 0 } },
            { "Vertical_Line", new int[]{0, 0, 0 } },
            { "Window_Blinds", new int[]{0, 0, 0 } }

        };

        public static List<WilmerVRVData> Ball(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Slow Object Speed";
                    level_PrettyName = "Slow (2s)";
                    break;

                case "medium":
                    level_ToggleName = "Medium Object Speed";
                    level_PrettyName = "Medium (1s)";
                    break;

                case "hard":
                    level_ToggleName = "Fast Object Speed";
                    level_PrettyName = "Fast (0.5s)";
                    break;

                default:
                    level_ToggleName = "Slow Object Speed";
                    level_PrettyName = "Slow (2s)";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "17-rolling-ball",
                        sceneTitle = "Soccer Ball",
                        sceneIndex = 17,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "17-rolling-ball",
                        sceneTitle = "Soccer Ball",
                        sceneIndex = 17,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Direction", "Object Speed", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Direction", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Object Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Left To Right Direction", PrettyName = "Left to Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Object Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Right To Left Direction", PrettyName = "Right to Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Object Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Blank Direction", PrettyName = "Blank" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> Bottle(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;

                case "medium":
                    level_ToggleName = "Grey Object Color";
                    level_PrettyName = "Blue";
                    break;

                case "hard":
                    level_ToggleName = "White Object Color";
                    level_PrettyName = "White";
                    break;

                default:
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "04-laundry-detergent-bottle",
                        sceneTitle = "Bottle",
                        sceneIndex = 4,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "04-laundry-detergent-bottle",
                        sceneTitle = "Bottle",
                        sceneIndex = 4,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Object Color", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Offsite Object Position", PrettyName = "Not Available" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> Candle(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;

                case "medium":
                    level_ToggleName = "Medium Room Light";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;

                default:
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "06-candles",
                        sceneTitle = "Candle",
                        sceneIndex = 6,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "06-candles",
                        sceneTitle = "Candle",
                        sceneIndex = 6,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Room Light", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Offsite Object Position", PrettyName = "Not Available" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> Car(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Slow Video Speed";
                    level_PrettyName = "Low";
                    break;

                case "medium":
                    level_ToggleName = "Medium Video Speed";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Fast Video Speed";
                    level_PrettyName = "High";
                    break;

                default:
                    level_ToggleName = "Slow Video Speed";
                    level_PrettyName = "Low";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "11-formula-1",
                        sceneTitle = "Car",
                        sceneIndex = 11,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "11-formula-1",
                        sceneTitle = "Car",
                        sceneIndex = 11,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Direction", "Video Speed", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Direction", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Video Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Left To Right Direction", PrettyName = "Left to Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Video Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Right To Left Direction", PrettyName = "Right to Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Video Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Blank Video Direction", PrettyName = "Blank" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> ComputerScreen(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;

                case "medium":
                    level_ToggleName = "Medium Room Light";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;

                default:
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "07-computer-screen",
                        sceneTitle = "Computer Screen",
                        sceneIndex = 7,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "07-computer-screen",
                        sceneTitle = "Computer Screen",
                        sceneIndex = 7,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "OnOrOff Object Color", "Room Light", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "OnOrOff Object Color", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "On", PrettyName = "On" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "OnOrOff Object Color", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Off", PrettyName = "Off" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                };
                return output;

            }
        }

        public static List<WilmerVRVData> Cursor(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Slow Video Speed";
                    level_PrettyName = "Low";
                    break;

                case "medium":
                    level_ToggleName = "Medium Video Speed";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Fast Video Speed";
                    level_PrettyName = "High";
                    break;

                default:
                    level_ToggleName = "Slow Video Speed";
                    level_PrettyName = "Low";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "10-moving-cursor",
                        sceneTitle = "Cursor",
                        sceneIndex = 10,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "10-moving-cursor",
                        sceneTitle = "Cursor",
                        sceneIndex = 10,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Direction", "Video Speed", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Direction", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Video Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Left To Right Direction", PrettyName = "Left to Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Video Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Right To Left Direction", PrettyName = "Right to Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Video Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Bottom To Top Direction", PrettyName = "Bottom to Top" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Direction", "Video Speed", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Top To Bottom Direction", PrettyName = "Top to Bottom" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> FlickerBrightness(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Easy Video";
                    level_PrettyName = "30% Contrast";
                    break;

                case "medium":
                    level_ToggleName = "Medium Video";
                    level_PrettyName = "10% Contrast";
                    break;

                case "hard":
                    level_ToggleName = "Hard Video";
                    level_PrettyName = "3% Contrast";
                    break;

                default:
                    level_ToggleName = "Easy Video";
                    level_PrettyName = "30% Contrast";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {//note that the name in the wilmerVR program is mistakenly replaced by the contrast variation but this playlist would generate the correct scene and save the data correctly
                        sceneName = "21-flickering-refresh-rate",
                        sceneTitle = "Flickering (Contrast Variation)",
                        sceneIndex = 21,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {//note that the name in the wilmerVR program is mistakenly replaced by the contrast variation but this playlist would generate the correct scene and save the data correctly
                        sceneName = "21-flickering-refresh-rate",
                        sceneTitle = "Flickering (Contrast Variation)",
                        sceneIndex = 21,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Video", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Video", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Available Object Position", PrettyName = "Yes" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Video", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Not Available Object Position", PrettyName = "No" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    }

                };
                return output;

            }
        }

        public static List<WilmerVRVData> FlickerFrequency(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Easy Video";
                    level_PrettyName = "3.5 Hz";
                    break;

                case "medium":
                    level_ToggleName = "Medium Video";
                    level_PrettyName = "11.7 Hz";
                    break;

                case "hard":
                    level_ToggleName = "Hard Video";
                    level_PrettyName = "35 Hz";
                    break;

                default:
                    level_ToggleName = "Easy Video";
                    level_PrettyName = "3.5 Hz";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {//note that the name in the wilmerVR program is mistakenly replaced by the refresh variation but this playlist would generate the correct scene and save the data correctly
                        sceneName = "20-flickering-contrast",
                        sceneTitle = "Flickering (Refresh Variation)",
                        sceneIndex = 20,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {//note that the name in the wilmerVR program is mistakenly replaced by the refresh variation but this playlist would generate the correct scene and save the data correctly
                        sceneName = "20-flickering-contrast",
                        sceneTitle = "Flickering (Refresh Variation)",
                        sceneIndex = 20,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Video", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Video", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Available Object Position", PrettyName = "Yes" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Video", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Not Available Object Position", PrettyName = "No" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    }

                };
                return output;

            }
        }

        public static List<WilmerVRVData> HandMovement(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Outside Shoulder Animation";
                    level_PrettyName = "Outside Shoulders";
                    break;

                case "medium":
                    level_ToggleName = "Shoulder Width Animation";
                    level_PrettyName = "Shoulder Width";
                    break;

                case "hard":
                    level_ToggleName = "Center Body Animation";
                    level_PrettyName = "Center of Body";
                    break;

                default:
                    level_ToggleName = "Outside Shoulder Animation";
                    level_PrettyName = "Outside Shoulders";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "12-hand-gestures",
                        sceneTitle = "Hand Movements",
                        sceneIndex = 12,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "12-hand-gestures",
                        sceneTitle = "Hand Movements",
                        sceneIndex = 12,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Gesturing", "Animation", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Gesturing", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Gesturing", "Animation", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Yes Gesturing", PrettyName = "Yes" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Gesturing", "Animation", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "No Gesturing", PrettyName = "No" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    }

                };
                return output;

            }
        }

        public static List<WilmerVRVData> LightBehindScreen(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;

                case "medium":
                    level_ToggleName = "Medium Room Light";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;

                default:
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "09-white-spot-on-screen",
                        sceneTitle = "Light Behind Screen",
                        sceneIndex = 9,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "09-white-spot-on-screen",
                        sceneTitle = "Light Behind Screen",
                        sceneIndex = 9,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Room Light", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Upper Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Upper Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Lower Left Object Position", PrettyName = "Lower Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Lower Right Object Position", PrettyName = "Lower Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    }

                };
                return output;

            }
        }

        public static List<WilmerVRVData> Pill(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;

                case "medium":
                    level_ToggleName = "Medium Room Light";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;

                default:
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "19-pill",
                        sceneTitle = "Pill",
                        sceneIndex = 19,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "19-pill",
                        sceneTitle = "Pill",
                        sceneIndex = 19,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Room Light", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Offsite Object Position", PrettyName = "Not Available" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> PlaceSetting(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;

                case "medium":
                    level_ToggleName = "Medium Room Light";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;

                default:
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "18-place-setting-missing",
                        sceneTitle = "Place Setting",
                        sceneIndex = 18,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "18-place-setting-missing",
                        sceneTitle = "Place Setting",
                        sceneIndex = 18,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Room Light", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Full Setup Object Position", PrettyName = "Full setup" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "3 o'clock" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "6 o'clock" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Lower Left Object Position", PrettyName = "9 o'clock" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Lower Right Object Position", PrettyName = "12 o'clock" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> PracticeBottle(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;

                default:
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "02-pre-test-bottle",
                        sceneTitle = "Bottle (Pretest)",
                        sceneIndex = 2,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "02-pre-test-bottle",
                        sceneTitle = "Bottle (Pretest)",
                        sceneIndex = 2,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Object Color", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Offsite Object Position", PrettyName = "Not Available" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> PracticeRoomLight(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;

                default:
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "00-pre-test-roomlight",
                        sceneTitle = "Room Light (Pretest)",
                        sceneIndex = 0,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "00-pre-test-roomlight",
                        sceneTitle = "Room Light (Pretest)",
                        sceneIndex = 0,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "OnOrOff Room Light", "Room Light", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "OnOrOff Room Light", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "On", PrettyName = "On" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "OnOrOff Room Light", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Off", PrettyName = "Off" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    }

                };
                return output;

            }
        }

        public static List<WilmerVRVData> PracticeTowel(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;

                default:
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "01-pre-test-towel",
                        sceneTitle = "Towel (Pretest)",
                        sceneIndex = 1,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "01-pre-test-towel",
                        sceneTitle = "Towel (Pretest)",
                        sceneIndex = 1,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Object Color", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Offsite Object Position", PrettyName = "Not Available" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> RoomLight(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;

                case "medium":
                    level_ToggleName = "Medium Room Light";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;

                default:
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "08-room-light",
                        sceneTitle = "Room Light",
                        sceneIndex = 8,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "08-room-light",
                        sceneTitle = "Room Light",
                        sceneIndex = 8,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "OnOrOff Room Light", "Room Light", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{  "OnOrOff Room Light","Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "On", PrettyName = "On" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{  "OnOrOff Room Light", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Off", PrettyName = "Off" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                };
                return output;

            }
        }

        public static List<WilmerVRVData> Smudge(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;

                case "medium":
                    level_ToggleName = "Grey Object Color";
                    level_PrettyName = "Pink";
                    break;

                case "hard":
                    level_ToggleName = "White Object Color";
                    level_PrettyName = "Blue";
                    break;

                default:
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "15-smudge-mirror",
                        sceneTitle = "Smudge",
                        sceneIndex = 15,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "15-smudge-mirror",
                        sceneTitle = "Smudge",
                        sceneIndex = 15,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Object Color", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Upper Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Upper Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Lower Left Object Position", PrettyName = "Lower Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Lower Right Object Position", PrettyName = "Lower Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    }

                };
                return output;

            }
        }

        public static List<WilmerVRVData> Tie(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Dark Blue";
                    break;

                case "medium":
                    level_ToggleName = "Grey Object Color";
                    level_PrettyName = "Light Blue";
                    break;

                case "hard":
                    level_ToggleName = "White Object Color";
                    level_PrettyName = "Gold";
                    break;

                default:
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Dark Blue";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "13-tie",
                        sceneTitle = "Tie",
                        sceneIndex = 13,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "13-tie",
                        sceneTitle = "Tie",
                        sceneIndex = 13,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Object Color", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Available Object Position", PrettyName = "Yes" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Not Available Object Position", PrettyName = "No" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                };
                return output;

            }
        }

        public static List<WilmerVRVData> Towel(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;

                case "medium":
                    level_ToggleName = "Grey Object Color";
                    level_PrettyName = "Grey";
                    break;

                case "hard":
                    level_ToggleName = "White Object Color";
                    level_PrettyName = "White";
                    break;

                default:
                    level_ToggleName = "Black Object Color";
                    level_PrettyName = "Black";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "03-towel-on-rack",
                        sceneTitle = "Towel",
                        sceneIndex = 3,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "03-towel-on-rack",
                        sceneTitle = "Towel",
                        sceneIndex = 3,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Object Color", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Object Color", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Offsite Object Position", PrettyName = "Not Available" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> TubeOfCream(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;

                case "medium":
                    level_ToggleName = "Medium Room Light";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;

                default:
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "14-tube-of-cream",
                        sceneTitle = "Tube of Cream",
                        sceneIndex = 14,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "14-tube-of-cream",
                        sceneTitle = "Tube of Cream",
                        sceneIndex = 14,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Room Light", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Offsite Object Position", PrettyName = "Not Available" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> VerticalLine(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":

                    level_ToggleName = "Bright Room Light";
                    level_PrettyName = "Bright";
                    break;

                case "medium":
                    level_ToggleName = "Medium Room Light";
                    level_PrettyName = "Medium";
                    break;

                case "hard":
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;

                default:
                    level_ToggleName = "Dark Room Light";
                    level_PrettyName = "Dark";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "16-guitar-strap",
                        sceneTitle = "Vertical Line",
                        sceneIndex = 16,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "16-guitar-strap",
                        sceneTitle = "Vertical Line",
                        sceneIndex = 16,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Object Position", "Room Light", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Object Position", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Left Object Position", PrettyName = "Left" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Upper Right Object Position", PrettyName = "Right" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Object Position", "Room Light", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Offsite Object Position", PrettyName = "Not Available" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() {ToggleName = "Demo Mode", PrettyName = "Demo"}
                        }
                    }
                };
                return output;

            }
        }

        public static List<WilmerVRVData> WindowBlinds(string level = "easy", int numTest = 3, int time = 3, bool demo = true)
        {
            List<WilmerVRVData> data = new();

            //difficulty level
            string level_ToggleName, level_PrettyName;
            switch (level)
            {
                case "easy":
                    level_ToggleName = "Black Background";
                    level_PrettyName = "Black";
                    break;

                case "medium":
                    level_ToggleName = "Grey Background";
                    level_PrettyName = "Grey";
                    break;

                case "hard":
                    level_ToggleName = "White Background";
                    level_PrettyName = "White";
                    break;

                default:
                    level_ToggleName = "Black Background";
                    level_PrettyName = "Black";
                    break;
            }

            //add demo if demo is true
            if (demo)
            {
                List<Option_dict> demotests = Option_dict_demo();
                foreach (Option_dict item in demotests)
                {
                    data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "05-window-blinds",
                        sceneTitle = "Window Blinds",
                        sceneIndex = 5,
                        presentationTime = time,
                        option_dict = item
                    }
                    );
                }

            }

            //add tests
            for (int i = 0; i < numTest; i++)
            {
                data.Add(
                    new WilmerVRVData()
                    {
                        sceneName = "05-window-blinds",
                        sceneTitle = "Window Blinds",
                        sceneIndex = 5,
                        presentationTime = time,
                        option_dict = new Option_dict
                        {
                            key_strings = new string[3] { "Window", "Background", "Experiment Mode" },
                            value_strings = new Option_dict_Value[3]
                            {
                                    new Option_dict_Value() { ToggleName = "Random Window", PrettyName = "Random" }
                                    , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                                    , new Option_dict_Value() { ToggleName = "Real Test Mode", PrettyName = "Real Test" }
                            }

                        }
                    }
                    ); ;
            }

            return data;

            List<Option_dict> Option_dict_demo()
            {
                List<Option_dict> output = new()
                {
                    new Option_dict
                    {
                        key_strings = new string[3]{ "Window", "Background", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Vertical Window", PrettyName = "Vertical" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Window", "Background", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Horizontal Window", PrettyName = "Horizontal" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    },

                    new Option_dict
                    {
                        key_strings = new string[3]{ "Window", "Background", "Experiment Mode" },
                        value_strings = new Option_dict_Value[3]
                        {
                            new Option_dict_Value() { ToggleName = "Empty Window", PrettyName = "No Blind" }
                            , new Option_dict_Value() { ToggleName = level_ToggleName, PrettyName = level_PrettyName }
                            , new Option_dict_Value() { ToggleName = "Demo Mode", PrettyName = "Demo" }
                        }
                    }

                };
                return output;

            }
        }


    }



}
