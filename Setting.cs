using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;

// This is a change i've made

namespace GalaxySmash
{
    public static class SettingsLocal
    {
        private static readonly Dictionary<string, List<string>> Settings = new Dictionary<string, List<string>>(new SettingsKeyComparer());
        private static string _settingsFileName;
        private static string _settingsDirectory = ".\\";
        private static SettingsLoadBehavior _settingsLoadBehavior;
        public enum SettingsLoadBehavior { FailIfMissing, ForceCreateNew, CreateNewIfMissing };
        public enum LoadState { NewFileCreated, ExistingFileLoaded };


        /// <summary>
        /// 
        /// </summary>
        public static string SettingsDirectory
        {
            get
            {
                var dir = new DirectoryInfo(_settingsDirectory);

                return dir.FullName;
            }

            set
            {
                if (!Directory.Exists(_settingsDirectory))
                    throw new Exception("Directory '" + _settingsDirectory + "' does not exist");

                _settingsDirectory = value;
            }
        }

        public static bool FileExists
        {
            get { return File.Exists(SettingsFileFullPath); }
        }

        public static string SettingsFileFullPath
        {
            get { return Path.Combine(SettingsDirectory, _settingsFileName); }
        }


        /// <summary>
        /// 
        /// </summary>
        private static void CreateBlankSettingsFile()
        {
            var utf8 = Encoding.UTF8;

            using (var sw = new StreamWriter(SettingsFileFullPath, false, utf8))
            {
                sw.Write("<?xml version='1.0' encoding='utf-8' ?><settings></settings>");
                sw.Close();
            }
        }


        /// <summary>
        /// Loads the settings file.
        /// </summary>
        /// <returns>TRUE if new settings file was created, otherwise FALSE</returns>
        public static LoadState Load(SettingsLoadBehavior settingsLoadBehavior, string fileName)
        {
            var state = LoadState.ExistingFileLoaded;

            _settingsFileName = fileName;
            _settingsLoadBehavior = settingsLoadBehavior;

            switch (_settingsLoadBehavior)
            {
                case SettingsLoadBehavior.CreateNewIfMissing:
                    if (!FileExists)
                    {
                        CreateBlankSettingsFile();
                        state = LoadState.NewFileCreated;
                    }
                    break;

                case SettingsLoadBehavior.ForceCreateNew:
                    CreateBlankSettingsFile();
                    state = LoadState.NewFileCreated;
                    break;
            }

            if (!FileExists)
                throw new Exception("Settings file not found at: '" + SettingsFileFullPath + "'");

            Settings.Clear();

            using (var ds = new DataSet())
            {
                ds.ReadXml(SettingsFileFullPath);

                // zero should be ok, since its a valid settings file just with no settings
                if (ds.Tables.Count > 1)
                    throw new Exception("Invalid number of tables '" + ds.Tables.Count + "' in settings file");

                // settings file is there, just no settings in it
                if (ds.Tables.Count == 0)
                    return state;

                DataTable table = ds.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    if (row.ItemArray.Length != 2)
                        throw new Exception("Invalid number of rows '" + row.ItemArray.Length + "' in setting. Details: " + row);

                    AddSetting((string)row[0], (string)row[1]);
                }
            }

            return state;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void UpdateSetting(string key, string value)
        {
            if (!Settings.ContainsKey(key))
                throw new Exception(string.Format("String {0} does not exist", key));

            if(Settings[key].Count != 1)
                throw new Exception(string.Format("Cannot use update when the are multiple duplicate key names. Found {0} duplicate keys for '{1}'",
                    Settings[key].Count, key));

            AddSetting(key, value, true);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddSetting(string key, string value)
        {
            AddSetting(key, value, false);
        }

        public static void EnsureSettingExists(string key, string value)
        {
            if (Settings.ContainsKey(key))
                return;

            AddSetting(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="clearExistingValues"></param>
        public static void AddSetting(string key, string value, bool clearExistingValues)
        {
            List<string> values;

            if (!Settings.TryGetValue(key, out values))
            {
                values = new List<string> { value };

                Settings.Add(key, values);
            }
            else
            {
                if (clearExistingValues)
                {
                    Settings[key].Clear();
                    Settings[key].Add(value);
                }
                else if (!Settings[key].Contains(value))
                {
                    Settings[key].Add(value);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<string> Lookup(string key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : new List<string>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string FirstValue(string key)
        {
            return Lookup(key)[0];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<string> AllValuesAsString(string key)
        {
            return Lookup(key);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<int> AllValuesAsInt(string key)
        {
            var ints = new List<int>(Lookup(key).Count);

            for (int a = 0; a < ints.Capacity; a++)
                ints.Add(int.Parse(Lookup(key)[a]));

            return ints;
        }


        /// <summary>
        /// 
        /// </summary>
        public static void Save()
        {
            var xmlSettings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true, IndentChars = "    " };

            using (var xml = XmlWriter.Create(SettingsFileFullPath, xmlSettings))
            {
                if (xml == null)
                    throw new Exception("XML Writer is null");

                xml.WriteStartElement("settings");

                foreach (KeyValuePair<string, List<string>> s in Settings)
                {
                    foreach (string val in s.Value)
                    {
                        xml.WriteStartElement("setting");
                        xml.WriteAttributeString("key", s.Key);
                        xml.WriteAttributeString("value", val);
                        xml.WriteEndElement();
                    }
                }

                xml.WriteEndElement();

                xml.Close();
            }
        }

        public static bool GetAsBool(string key)
        {
            return bool.Parse(FirstValue(key));
        }

        public static byte GetAsByte(string key)
        {
            return byte.Parse(FirstValue(key));
        }

        public static char GetAsChar(string key)
        {
            return char.Parse(FirstValue(key));
        }

        public static decimal GetAsDecimal(string key)
        {
            return decimal.Parse(FirstValue(key));
        }

        public static double GetAsDouble(string key)
        {
            return double.Parse(FirstValue(key));
        }

        public static float GetAsFloat(string key)
        {
            return float.Parse(FirstValue(key));
        }

        public static int GetAsInt(string key)
        {
            return int.Parse(FirstValue(key));
        }

        public static long GetAsLong(string key)
        {
            return long.Parse(FirstValue(key));
        }

        public static sbyte GetAsSByte(string key)
        {
            return sbyte.Parse(FirstValue(key));
        }

        public static short GetAsShort(string key)
        {
            return short.Parse(FirstValue(key));
        }

        public static string GetAsString(string key)
        {
            return FirstValue(key);
        }

        public static uint GetAsUInt(string key)
        {
            return uint.Parse(FirstValue(key));
        }

        public static ulong GetAsULong(string key)
        {
            return ulong.Parse(FirstValue(key));
        }

        public static ushort GetAsUShort(string key)
        {
            return ushort.Parse(FirstValue(key));
        }
    }
}