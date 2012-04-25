using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GalaxySmash
{
    public enum UniversalRemoteAction
    {
        None,
        ReloadSimulation
    }

    
    public partial class UniversalRemote : Form
    {
        private UniversalRemoteAction _universalRemoteAction = UniversalRemoteAction.ReloadSimulation;
        private int _previouslySelectedGalaxyIndex = -1;

        public UniversalRemote()
        {
            InitializeComponent();
        }

        private string CurrentUniverseID()
        {
            return SettingsLocal.GetAsString("CurrentUniverseID");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UniversalRemoteAction GetRequestedAction()
        {
            UniversalRemoteAction temp = _universalRemoteAction;

            _universalRemoteAction = UniversalRemoteAction.None;

            return temp;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Save();

            _universalRemoteAction = UniversalRemoteAction.ReloadSimulation;

            Close();
        }

        private void UniversalRemote_Load(object sender, EventArgs e)
        {
            checkRenderStars.Checked           = SettingsLocal.GetAsBool("RenderStars");
            checkRenderSectors.Checked         = SettingsLocal.GetAsBool("RenderSectorGeometry");
            checkRenderVelocityVectors.Checked = SettingsLocal.GetAsBool("RenderVelocityVectors");
            numStarBufferSize.Value            = SettingsLocal.GetAsInt("StarBufferSize");
            numProcessingThreads.Value         = SettingsLocal.GetAsInt("MaxProcessingThreadCount");
            numMaxStarsPerSector.Value         = SettingsLocal.GetAsInt("MaxStarsPerSector");

            RefreshUniverseList(CurrentUniverseID());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextUniverseID"></param>
        private void RefreshUniverseList(string nextUniverseID)
        {
            listUniverses.Items.Clear();
            listGalaxies.Items.Clear();

            listUniverses.Items.AddRange(SettingsLocal.AllValuesAsString("UniverseID").ToArray());

            int indexToSelect = listUniverses.Items.IndexOf(nextUniverseID);

            if (indexToSelect == -1)
                return;

            listUniverses.SelectedIndex = indexToSelect;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="universeID"></param>
        private void LoadUniverse(string universeID)
        {
            listGalaxies.Items.Clear();

            SettingsLocal.UpdateSetting("CurrentUniverseID", universeID);

            _previouslySelectedGalaxyIndex = -1;

            List<string> galaxyIDs = SettingsLocal.AllValuesAsString("Universe" + CurrentUniverseID() + "GalaxyID");
            RefreshSelectedGalaxyData();

            if (galaxyIDs.Count == 0)
                return;

            foreach (string galaxyID in galaxyIDs)
            {
                listGalaxies.Items.Add(galaxyID);
            }

            listGalaxies.SelectedIndex = 0;
            RefreshSelectedGalaxyData();
        }


        /// <summary>
        /// 
        /// </summary>
        private void Save()
        {
            if (listGalaxies.SelectedIndex == -1)
                return;

            string galaxyID;

            if (_previouslySelectedGalaxyIndex == -1)
                galaxyID = listGalaxies.Items[listGalaxies.SelectedIndex].ToString();
            else
                galaxyID = listGalaxies.Items[_previouslySelectedGalaxyIndex].ToString();

            SettingsLocal.AddSetting("Universe" + CurrentUniverseID() + "GalaxyID", galaxyID, false);

            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "NumberOfStars", numGalaxyStarCount.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "DistributionIterations", numStarDistributionIterations.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "SupermassiveBlackHoleSolarMasses", numSupermassiveBlackHoleSolarMasses.Value.ToString());

            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "PositionX", numGalaxyCenterX.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "PositionY", numGalaxyCenterY.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "PositionZ", numGalaxyCenterZ.Value.ToString());

            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "ChanceSkewX", numStarDistributionPercentX.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "ChanceSkewY", numStarDistributionPercentY.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "ChanceSkewZ", numStarDistributionPercentZ.Value.ToString());

            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "ChanceSkewLowX", numStarDistributionSkewLowX.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "ChanceSkewLowY", numStarDistributionSkewLowY.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "ChanceSkewLowZ", numStarDistributionSkewLowZ.Value.ToString());

            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "ChanceSkewHighX", numStarDistributionSkewHighX.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "ChanceSkewHighY", numStarDistributionSkewHighY.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "ChanceSkewHighZ", numStarDistributionSkewHighZ.Value.ToString());

            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "StarVelocity", numStarVelocity.Value.ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "StarMass",  numStarMass.Value.ToString());

            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "StarColor", panelGalaxyColor.BackColor.ToArgb().ToString());
            SettingsLocal.UpdateSetting("Galaxy" + galaxyID + "MinDistanceToBlackHole", numMiniumDistanceToBlackHole.Value.ToString());
            
           
            SettingsLocal.UpdateSetting("RenderStars",           checkRenderStars.Checked.ToString());
            SettingsLocal.UpdateSetting("RenderSectorGeometry",  checkRenderSectors.Checked.ToString());
            SettingsLocal.UpdateSetting("RenderVelocityVectors", checkRenderVelocityVectors.Checked.ToString());

            SettingsLocal.UpdateSetting("StarBufferSize",           numStarBufferSize.Value.ToString());
            SettingsLocal.UpdateSetting("MaxProcessingThreadCount", numProcessingThreads.Value.ToString());
            SettingsLocal.UpdateSetting("MaxStarsPerSector",        numMaxStarsPerSector.Value.ToString());
            
            SettingsLocal.Save();
        }

        private void listGalaxies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_previouslySelectedGalaxyIndex != -1)
                Save();

            RefreshSelectedGalaxyData();

            _previouslySelectedGalaxyIndex = listGalaxies.SelectedIndex;
        }


        /// <summary>
        /// 
        /// </summary>
        private void RefreshSelectedGalaxyData()
        {
            if (listGalaxies.SelectedIndex == -1)
            {
                groupGalaxy.Enabled = false;

                ClearGalaxyFormData();
                return;
            }

            groupGalaxy.Enabled = true;

            string galaxyID = listGalaxies.Items[listGalaxies.SelectedIndex].ToString();

            DisplayGalaxyData(galaxyID);
        }


        /// <summary>
        /// 
        /// </summary>
        private void ClearGalaxyFormData()
        {
            numGalaxyStarCount.Value = 0;
            numStarDistributionIterations.Value = 0;

            numGalaxyCenterX.Value = 0;
            numGalaxyCenterY.Value = 0;
            numGalaxyCenterZ.Value = 0;

            numStarDistributionPercentX.Value = 0;
            numStarDistributionPercentY.Value = 0;
            numStarDistributionPercentZ.Value = 0;

            numStarDistributionSkewLowX.Value = 0;
            numStarDistributionSkewLowY.Value = 0;
            numStarDistributionSkewLowZ.Value = 0;

            numStarDistributionSkewHighX.Value = 0;
            numStarDistributionSkewHighY.Value = 0;
            numStarDistributionSkewHighZ.Value = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="galaxyID"></param>
        private void DisplayGalaxyData(string galaxyID)
        {
            numGalaxyStarCount.Value                  = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "NumberOfStars");
            numStarDistributionIterations.Value       = SettingsLocal.GetAsInt("Galaxy"     + galaxyID + "DistributionIterations");
            numSupermassiveBlackHoleSolarMasses.Value = SettingsLocal.GetAsLong("Galaxy"    + galaxyID + "SupermassiveBlackHoleSolarMasses");

            numGalaxyCenterX.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "PositionX");
            numGalaxyCenterY.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "PositionY");
            numGalaxyCenterZ.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "PositionZ");

            numStarDistributionPercentX.Value = SettingsLocal.GetAsInt("Galaxy" + galaxyID + "ChanceSkewX");
            numStarDistributionPercentY.Value = SettingsLocal.GetAsInt("Galaxy" + galaxyID + "ChanceSkewY");
            numStarDistributionPercentZ.Value = SettingsLocal.GetAsInt("Galaxy" + galaxyID + "ChanceSkewZ");

            numStarDistributionSkewLowX.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "ChanceSkewLowX");
            numStarDistributionSkewLowY.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "ChanceSkewLowY");
            numStarDistributionSkewLowZ.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "ChanceSkewLowZ");

            numStarDistributionSkewHighX.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "ChanceSkewHighX");
            numStarDistributionSkewHighY.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "ChanceSkewHighY");
            numStarDistributionSkewHighZ.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "ChanceSkewHighZ");

            numMiniumDistanceToBlackHole.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "MinDistanceToBlackHole");

            numStarMass.Value     = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "StarMass");
            numStarVelocity.Value = SettingsLocal.GetAsDecimal("Galaxy" + galaxyID + "StarVelocity");

            panelGalaxyColor.BackColor = Color.FromArgb(SettingsLocal.GetAsInt("Galaxy" + galaxyID + "StarColor"));
        }

        private void btnNewUniverse_Click(object sender, EventArgs e)
        {
            Save();

            string nextUniverseID = SettingsLocal.GetAsString("NextUniqueUniverseID");

            SettingsLocal.AddSetting("UniverseID", nextUniverseID, false);

            SettingsLocal.UpdateSetting("NextUniqueUniverseID", (int.Parse(nextUniverseID) + 1).ToString());

            RefreshUniverseList(nextUniverseID);
        }

        private void listUniverses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listUniverses.SelectedIndex == -1)
                return;

            LoadUniverse(listUniverses.Items[listUniverses.SelectedIndex].ToString());
        }

        private void btnNewGalaxy_Click(object sender, EventArgs e)
        {
            AddNewGalaxy();
        }


        /// <summary>
        /// 
        /// </summary>
        private void AddNewGalaxy()
        {
            string nextGalaxyID = SettingsLocal.GetAsString("NextUniqueGalaxyID");

            SettingsLocal.UpdateSetting("NextUniqueGalaxyID", (int.Parse(nextGalaxyID) + 1).ToString());

            SettingsLocal.AddSetting("Universe" + CurrentUniverseID() + "GalaxyID", nextGalaxyID);

            SettingsLocal.EnsureSettingExists("GridSizeUniverse" + CurrentUniverseID(), "40");
            SettingsLocal.EnsureSettingExists("Universe" + CurrentUniverseID() + "GalaxyID", "0");

            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "NumberOfStars", "10000");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "DistributionIterations", "100");

            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "PositionX", "0");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "PositionY", "0");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "PositionZ", "0");

            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "ChanceSkewX", "10");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "ChanceSkewY", "12");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "ChanceSkewZ", "13");

            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "ChanceSkewLowX", "1.0");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "ChanceSkewLowY", "1.0");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "ChanceSkewLowZ", "1.05");

            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "ChanceSkewHighX", "1.15");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "ChanceSkewHighY", "1.1");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "ChanceSkewHighZ", "1.15");

            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "StarMass", "10");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "StarVelocity", "0.01");
            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "SupermassiveBlackHoleSolarMasses", "100");

            SettingsLocal.EnsureSettingExists("Galaxy" + nextGalaxyID + "StarColor", Color.White.ToArgb().ToString());

            int insertedAt = listGalaxies.Items.Add(nextGalaxyID);
            listGalaxies.SelectedIndex = insertedAt;
        }

        private void btnGalaxyColor_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != colorDialog1.ShowDialog())
                return;

            panelGalaxyColor.BackColor = colorDialog1.Color;
        }
    }
}
