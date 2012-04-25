namespace GalaxySmash
{
    partial class UniversalRemote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numGridSize = new System.Windows.Forms.NumericUpDown();
            this.listGalaxies = new System.Windows.Forms.ListBox();
            this.btnNewGalaxy = new System.Windows.Forms.Button();
            this.groupGalaxy = new System.Windows.Forms.GroupBox();
            this.btnGalaxyColor = new System.Windows.Forms.Button();
            this.panelGalaxyColor = new System.Windows.Forms.Panel();
            this.numStarMass = new GalaxySmash.LabeledNumericControl();
            this.numStarVelocity = new GalaxySmash.LabeledNumericControl();
            this.numSupermassiveBlackHoleSolarMasses = new GalaxySmash.LabeledNumericControl();
            this.groupGalaxyOrientation = new System.Windows.Forms.GroupBox();
            this.numGalaxyCenterZ = new GalaxySmash.LabeledNumericControl();
            this.numGalaxyCenterX = new GalaxySmash.LabeledNumericControl();
            this.numGalaxyCenterY = new GalaxySmash.LabeledNumericControl();
            this.groupStarDistribution = new System.Windows.Forms.GroupBox();
            this.numStarDistributionIterations = new GalaxySmash.LabeledNumericControl();
            this.numStarDistributionPercentZ = new GalaxySmash.LabeledNumericControl();
            this.numStarDistributionSkewLowX = new GalaxySmash.LabeledNumericControl();
            this.numStarDistributionSkewHighZ = new GalaxySmash.LabeledNumericControl();
            this.numStarDistributionSkewHighX = new GalaxySmash.LabeledNumericControl();
            this.numStarDistributionSkewLowZ = new GalaxySmash.LabeledNumericControl();
            this.numStarDistributionPercentX = new GalaxySmash.LabeledNumericControl();
            this.numStarDistributionPercentY = new GalaxySmash.LabeledNumericControl();
            this.numStarDistributionSkewLowY = new GalaxySmash.LabeledNumericControl();
            this.numStarDistributionSkewHighY = new GalaxySmash.LabeledNumericControl();
            this.numGalaxyStarCount = new GalaxySmash.LabeledNumericControl();
            this.listUniverses = new System.Windows.Forms.ListBox();
            this.labelUniverses = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewUniverse = new System.Windows.Forms.Button();
            this.checkRenderStars = new System.Windows.Forms.CheckBox();
            this.checkRenderSectors = new System.Windows.Forms.CheckBox();
            this.checkRenderVelocityVectors = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.numProcessingThreads = new GalaxySmash.LabeledNumericControl();
            this.numStarBufferSize = new GalaxySmash.LabeledNumericControl();
            this.numMaxStarsPerSector = new GalaxySmash.LabeledNumericControl();
            this.numMiniumDistanceToBlackHole = new GalaxySmash.LabeledNumericControl();
            ((System.ComponentModel.ISupportInitialize)(this.numGridSize)).BeginInit();
            this.groupGalaxy.SuspendLayout();
            this.groupGalaxyOrientation.SuspendLayout();
            this.groupStarDistribution.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(475, 552);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(210, 42);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Save and Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(959, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grid Size";
            // 
            // numGridSize
            // 
            this.numGridSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numGridSize.Location = new System.Drawing.Point(1008, 36);
            this.numGridSize.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numGridSize.Name = "numGridSize";
            this.numGridSize.Size = new System.Drawing.Size(94, 20);
            this.numGridSize.TabIndex = 3;
            this.numGridSize.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // listGalaxies
            // 
            this.listGalaxies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listGalaxies.FormattingEnabled = true;
            this.listGalaxies.Location = new System.Drawing.Point(140, 40);
            this.listGalaxies.Name = "listGalaxies";
            this.listGalaxies.Size = new System.Drawing.Size(122, 485);
            this.listGalaxies.TabIndex = 5;
            this.listGalaxies.SelectedIndexChanged += new System.EventHandler(this.listGalaxies_SelectedIndexChanged);
            // 
            // btnNewGalaxy
            // 
            this.btnNewGalaxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewGalaxy.Location = new System.Drawing.Point(140, 542);
            this.btnNewGalaxy.Name = "btnNewGalaxy";
            this.btnNewGalaxy.Size = new System.Drawing.Size(122, 23);
            this.btnNewGalaxy.TabIndex = 6;
            this.btnNewGalaxy.Text = "New";
            this.btnNewGalaxy.UseVisualStyleBackColor = true;
            this.btnNewGalaxy.Click += new System.EventHandler(this.btnNewGalaxy_Click);
            // 
            // groupGalaxy
            // 
            this.groupGalaxy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupGalaxy.Controls.Add(this.btnGalaxyColor);
            this.groupGalaxy.Controls.Add(this.panelGalaxyColor);
            this.groupGalaxy.Controls.Add(this.numStarMass);
            this.groupGalaxy.Controls.Add(this.numStarVelocity);
            this.groupGalaxy.Controls.Add(this.numSupermassiveBlackHoleSolarMasses);
            this.groupGalaxy.Controls.Add(this.groupGalaxyOrientation);
            this.groupGalaxy.Controls.Add(this.groupStarDistribution);
            this.groupGalaxy.Controls.Add(this.numGalaxyStarCount);
            this.groupGalaxy.Location = new System.Drawing.Point(268, 26);
            this.groupGalaxy.Name = "groupGalaxy";
            this.groupGalaxy.Size = new System.Drawing.Size(621, 505);
            this.groupGalaxy.TabIndex = 7;
            this.groupGalaxy.TabStop = false;
            this.groupGalaxy.Text = "Galaxy - (None Selected)";
            // 
            // btnGalaxyColor
            // 
            this.btnGalaxyColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGalaxyColor.Location = new System.Drawing.Point(26, 87);
            this.btnGalaxyColor.Name = "btnGalaxyColor";
            this.btnGalaxyColor.Size = new System.Drawing.Size(65, 23);
            this.btnGalaxyColor.TabIndex = 20;
            this.btnGalaxyColor.Text = "Color...";
            this.btnGalaxyColor.UseVisualStyleBackColor = true;
            this.btnGalaxyColor.Click += new System.EventHandler(this.btnGalaxyColor_Click);
            // 
            // panelGalaxyColor
            // 
            this.panelGalaxyColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelGalaxyColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGalaxyColor.Location = new System.Drawing.Point(97, 87);
            this.panelGalaxyColor.Name = "panelGalaxyColor";
            this.panelGalaxyColor.Size = new System.Drawing.Size(103, 23);
            this.panelGalaxyColor.TabIndex = 19;
            // 
            // numStarMass
            // 
            this.numStarMass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarMass.DecimalPlaces = 3;
            this.numStarMass.Location = new System.Drawing.Point(335, 53);
            this.numStarMass.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarMass.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numStarMass.Name = "numStarMass";
            this.numStarMass.Size = new System.Drawing.Size(174, 28);
            this.numStarMass.TabIndex = 21;
            this.numStarMass.Title = "Star Mass";
            this.numStarMass.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numStarVelocity
            // 
            this.numStarVelocity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarVelocity.DecimalPlaces = 10;
            this.numStarVelocity.Location = new System.Drawing.Point(26, 53);
            this.numStarVelocity.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarVelocity.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numStarVelocity.Name = "numStarVelocity";
            this.numStarVelocity.Size = new System.Drawing.Size(174, 28);
            this.numStarVelocity.TabIndex = 19;
            this.numStarVelocity.Title = "Star Velocity";
            this.numStarVelocity.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // numSupermassiveBlackHoleSolarMasses
            // 
            this.numSupermassiveBlackHoleSolarMasses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numSupermassiveBlackHoleSolarMasses.DecimalPlaces = 0;
            this.numSupermassiveBlackHoleSolarMasses.Location = new System.Drawing.Point(206, 19);
            this.numSupermassiveBlackHoleSolarMasses.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numSupermassiveBlackHoleSolarMasses.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numSupermassiveBlackHoleSolarMasses.Name = "numSupermassiveBlackHoleSolarMasses";
            this.numSupermassiveBlackHoleSolarMasses.Size = new System.Drawing.Size(303, 28);
            this.numSupermassiveBlackHoleSolarMasses.TabIndex = 20;
            this.numSupermassiveBlackHoleSolarMasses.Title = "Supermassive Black Hole Solar Masses";
            this.numSupermassiveBlackHoleSolarMasses.Value = new decimal(new int[] {
            41000000,
            0,
            0,
            0});
            // 
            // groupGalaxyOrientation
            // 
            this.groupGalaxyOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupGalaxyOrientation.Controls.Add(this.numGalaxyCenterZ);
            this.groupGalaxyOrientation.Controls.Add(this.numGalaxyCenterX);
            this.groupGalaxyOrientation.Controls.Add(this.numGalaxyCenterY);
            this.groupGalaxyOrientation.Location = new System.Drawing.Point(29, 133);
            this.groupGalaxyOrientation.Name = "groupGalaxyOrientation";
            this.groupGalaxyOrientation.Size = new System.Drawing.Size(556, 153);
            this.groupGalaxyOrientation.TabIndex = 19;
            this.groupGalaxyOrientation.TabStop = false;
            this.groupGalaxyOrientation.Text = "Galaxy Orientation";
            // 
            // numGalaxyCenterZ
            // 
            this.numGalaxyCenterZ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numGalaxyCenterZ.DecimalPlaces = 2;
            this.numGalaxyCenterZ.Location = new System.Drawing.Point(22, 102);
            this.numGalaxyCenterZ.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numGalaxyCenterZ.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numGalaxyCenterZ.Name = "numGalaxyCenterZ";
            this.numGalaxyCenterZ.Size = new System.Drawing.Size(129, 28);
            this.numGalaxyCenterZ.TabIndex = 18;
            this.numGalaxyCenterZ.Title = "Z";
            this.numGalaxyCenterZ.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numGalaxyCenterX
            // 
            this.numGalaxyCenterX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numGalaxyCenterX.DecimalPlaces = 2;
            this.numGalaxyCenterX.Location = new System.Drawing.Point(22, 34);
            this.numGalaxyCenterX.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numGalaxyCenterX.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numGalaxyCenterX.Name = "numGalaxyCenterX";
            this.numGalaxyCenterX.Size = new System.Drawing.Size(129, 28);
            this.numGalaxyCenterX.TabIndex = 16;
            this.numGalaxyCenterX.Title = "X";
            this.numGalaxyCenterX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numGalaxyCenterY
            // 
            this.numGalaxyCenterY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numGalaxyCenterY.DecimalPlaces = 2;
            this.numGalaxyCenterY.Location = new System.Drawing.Point(22, 68);
            this.numGalaxyCenterY.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numGalaxyCenterY.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numGalaxyCenterY.Name = "numGalaxyCenterY";
            this.numGalaxyCenterY.Size = new System.Drawing.Size(129, 28);
            this.numGalaxyCenterY.TabIndex = 17;
            this.numGalaxyCenterY.Title = "Y";
            this.numGalaxyCenterY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // groupStarDistribution
            // 
            this.groupStarDistribution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupStarDistribution.Controls.Add(this.numMiniumDistanceToBlackHole);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionIterations);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionPercentZ);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionSkewLowX);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionSkewHighZ);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionSkewHighX);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionSkewLowZ);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionPercentX);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionPercentY);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionSkewLowY);
            this.groupStarDistribution.Controls.Add(this.numStarDistributionSkewHighY);
            this.groupStarDistribution.Location = new System.Drawing.Point(29, 302);
            this.groupStarDistribution.Name = "groupStarDistribution";
            this.groupStarDistribution.Size = new System.Drawing.Size(556, 185);
            this.groupStarDistribution.TabIndex = 15;
            this.groupStarDistribution.TabStop = false;
            this.groupStarDistribution.Text = "Star Distribution";
            // 
            // numStarDistributionIterations
            // 
            this.numStarDistributionIterations.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionIterations.DecimalPlaces = 0;
            this.numStarDistributionIterations.Location = new System.Drawing.Point(48, 19);
            this.numStarDistributionIterations.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarDistributionIterations.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numStarDistributionIterations.Name = "numStarDistributionIterations";
            this.numStarDistributionIterations.Size = new System.Drawing.Size(177, 28);
            this.numStarDistributionIterations.TabIndex = 1;
            this.numStarDistributionIterations.Title = "For Iterations";
            this.numStarDistributionIterations.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numStarDistributionPercentZ
            // 
            this.numStarDistributionPercentZ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionPercentZ.DecimalPlaces = 0;
            this.numStarDistributionPercentZ.Location = new System.Drawing.Point(18, 136);
            this.numStarDistributionPercentZ.MaximumValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numStarDistributionPercentZ.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numStarDistributionPercentZ.Name = "numStarDistributionPercentZ";
            this.numStarDistributionPercentZ.Size = new System.Drawing.Size(123, 28);
            this.numStarDistributionPercentZ.TabIndex = 14;
            this.numStarDistributionPercentZ.Title = "%";
            this.numStarDistributionPercentZ.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numStarDistributionSkewLowX
            // 
            this.numStarDistributionSkewLowX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionSkewLowX.DecimalPlaces = 5;
            this.numStarDistributionSkewLowX.Location = new System.Drawing.Point(147, 68);
            this.numStarDistributionSkewLowX.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarDistributionSkewLowX.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numStarDistributionSkewLowX.Name = "numStarDistributionSkewLowX";
            this.numStarDistributionSkewLowX.Size = new System.Drawing.Size(243, 28);
            this.numStarDistributionSkewLowX.TabIndex = 2;
            this.numStarDistributionSkewLowX.Title = "chance to skew X between";
            this.numStarDistributionSkewLowX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numStarDistributionSkewHighZ
            // 
            this.numStarDistributionSkewHighZ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionSkewHighZ.DecimalPlaces = 5;
            this.numStarDistributionSkewHighZ.Location = new System.Drawing.Point(396, 136);
            this.numStarDistributionSkewHighZ.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarDistributionSkewHighZ.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numStarDistributionSkewHighZ.Name = "numStarDistributionSkewHighZ";
            this.numStarDistributionSkewHighZ.Size = new System.Drawing.Size(133, 28);
            this.numStarDistributionSkewHighZ.TabIndex = 13;
            this.numStarDistributionSkewHighZ.Title = "and";
            this.numStarDistributionSkewHighZ.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numStarDistributionSkewHighX
            // 
            this.numStarDistributionSkewHighX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionSkewHighX.DecimalPlaces = 5;
            this.numStarDistributionSkewHighX.Location = new System.Drawing.Point(396, 68);
            this.numStarDistributionSkewHighX.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarDistributionSkewHighX.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numStarDistributionSkewHighX.Name = "numStarDistributionSkewHighX";
            this.numStarDistributionSkewHighX.Size = new System.Drawing.Size(133, 28);
            this.numStarDistributionSkewHighX.TabIndex = 5;
            this.numStarDistributionSkewHighX.Title = "and";
            this.numStarDistributionSkewHighX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numStarDistributionSkewLowZ
            // 
            this.numStarDistributionSkewLowZ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionSkewLowZ.DecimalPlaces = 5;
            this.numStarDistributionSkewLowZ.Location = new System.Drawing.Point(147, 136);
            this.numStarDistributionSkewLowZ.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarDistributionSkewLowZ.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numStarDistributionSkewLowZ.Name = "numStarDistributionSkewLowZ";
            this.numStarDistributionSkewLowZ.Size = new System.Drawing.Size(243, 28);
            this.numStarDistributionSkewLowZ.TabIndex = 12;
            this.numStarDistributionSkewLowZ.Title = "chance to skew Z between";
            this.numStarDistributionSkewLowZ.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numStarDistributionPercentX
            // 
            this.numStarDistributionPercentX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionPercentX.DecimalPlaces = 0;
            this.numStarDistributionPercentX.Location = new System.Drawing.Point(18, 68);
            this.numStarDistributionPercentX.MaximumValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numStarDistributionPercentX.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numStarDistributionPercentX.Name = "numStarDistributionPercentX";
            this.numStarDistributionPercentX.Size = new System.Drawing.Size(123, 28);
            this.numStarDistributionPercentX.TabIndex = 8;
            this.numStarDistributionPercentX.Title = "%";
            this.numStarDistributionPercentX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numStarDistributionPercentY
            // 
            this.numStarDistributionPercentY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionPercentY.DecimalPlaces = 0;
            this.numStarDistributionPercentY.Location = new System.Drawing.Point(18, 102);
            this.numStarDistributionPercentY.MaximumValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numStarDistributionPercentY.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numStarDistributionPercentY.Name = "numStarDistributionPercentY";
            this.numStarDistributionPercentY.Size = new System.Drawing.Size(123, 28);
            this.numStarDistributionPercentY.TabIndex = 11;
            this.numStarDistributionPercentY.Title = "%";
            this.numStarDistributionPercentY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numStarDistributionSkewLowY
            // 
            this.numStarDistributionSkewLowY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionSkewLowY.DecimalPlaces = 5;
            this.numStarDistributionSkewLowY.Location = new System.Drawing.Point(147, 102);
            this.numStarDistributionSkewLowY.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarDistributionSkewLowY.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numStarDistributionSkewLowY.Name = "numStarDistributionSkewLowY";
            this.numStarDistributionSkewLowY.Size = new System.Drawing.Size(243, 28);
            this.numStarDistributionSkewLowY.TabIndex = 9;
            this.numStarDistributionSkewLowY.Title = "chance to skew Y between";
            this.numStarDistributionSkewLowY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numStarDistributionSkewHighY
            // 
            this.numStarDistributionSkewHighY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numStarDistributionSkewHighY.DecimalPlaces = 5;
            this.numStarDistributionSkewHighY.Location = new System.Drawing.Point(396, 102);
            this.numStarDistributionSkewHighY.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarDistributionSkewHighY.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numStarDistributionSkewHighY.Name = "numStarDistributionSkewHighY";
            this.numStarDistributionSkewHighY.Size = new System.Drawing.Size(133, 28);
            this.numStarDistributionSkewHighY.TabIndex = 10;
            this.numStarDistributionSkewHighY.Title = "and";
            this.numStarDistributionSkewHighY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numGalaxyStarCount
            // 
            this.numGalaxyStarCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numGalaxyStarCount.DecimalPlaces = 0;
            this.numGalaxyStarCount.Location = new System.Drawing.Point(34, 19);
            this.numGalaxyStarCount.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numGalaxyStarCount.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numGalaxyStarCount.Name = "numGalaxyStarCount";
            this.numGalaxyStarCount.Size = new System.Drawing.Size(166, 28);
            this.numGalaxyStarCount.TabIndex = 0;
            this.numGalaxyStarCount.Title = "Star Count";
            this.numGalaxyStarCount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // listUniverses
            // 
            this.listUniverses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listUniverses.FormattingEnabled = true;
            this.listUniverses.Location = new System.Drawing.Point(16, 40);
            this.listUniverses.Name = "listUniverses";
            this.listUniverses.Size = new System.Drawing.Size(122, 485);
            this.listUniverses.TabIndex = 8;
            this.listUniverses.SelectedIndexChanged += new System.EventHandler(this.listUniverses_SelectedIndexChanged);
            // 
            // labelUniverses
            // 
            this.labelUniverses.AutoSize = true;
            this.labelUniverses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUniverses.Location = new System.Drawing.Point(12, 9);
            this.labelUniverses.Name = "labelUniverses";
            this.labelUniverses.Size = new System.Drawing.Size(71, 20);
            this.labelUniverses.TabIndex = 9;
            this.labelUniverses.Text = "Universe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Galaxies";
            // 
            // btnNewUniverse
            // 
            this.btnNewUniverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewUniverse.Location = new System.Drawing.Point(12, 542);
            this.btnNewUniverse.Name = "btnNewUniverse";
            this.btnNewUniverse.Size = new System.Drawing.Size(122, 23);
            this.btnNewUniverse.TabIndex = 11;
            this.btnNewUniverse.Text = "New";
            this.btnNewUniverse.UseVisualStyleBackColor = true;
            this.btnNewUniverse.Click += new System.EventHandler(this.btnNewUniverse_Click);
            // 
            // checkRenderStars
            // 
            this.checkRenderStars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRenderStars.AutoSize = true;
            this.checkRenderStars.Location = new System.Drawing.Point(962, 69);
            this.checkRenderStars.Name = "checkRenderStars";
            this.checkRenderStars.Size = new System.Drawing.Size(88, 17);
            this.checkRenderStars.TabIndex = 12;
            this.checkRenderStars.Text = "Render Stars";
            this.checkRenderStars.UseVisualStyleBackColor = true;
            // 
            // checkRenderSectors
            // 
            this.checkRenderSectors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRenderSectors.AutoSize = true;
            this.checkRenderSectors.Location = new System.Drawing.Point(962, 92);
            this.checkRenderSectors.Name = "checkRenderSectors";
            this.checkRenderSectors.Size = new System.Drawing.Size(100, 17);
            this.checkRenderSectors.TabIndex = 13;
            this.checkRenderSectors.Text = "Render Sectors";
            this.checkRenderSectors.UseVisualStyleBackColor = true;
            // 
            // checkRenderVelocityVectors
            // 
            this.checkRenderVelocityVectors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRenderVelocityVectors.AutoSize = true;
            this.checkRenderVelocityVectors.Location = new System.Drawing.Point(962, 115);
            this.checkRenderVelocityVectors.Name = "checkRenderVelocityVectors";
            this.checkRenderVelocityVectors.Size = new System.Drawing.Size(140, 17);
            this.checkRenderVelocityVectors.TabIndex = 14;
            this.checkRenderVelocityVectors.Text = "Render Velocity Vectors";
            this.checkRenderVelocityVectors.UseVisualStyleBackColor = true;
            // 
            // numProcessingThreads
            // 
            this.numProcessingThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numProcessingThreads.DecimalPlaces = 0;
            this.numProcessingThreads.Location = new System.Drawing.Point(895, 182);
            this.numProcessingThreads.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numProcessingThreads.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numProcessingThreads.Name = "numProcessingThreads";
            this.numProcessingThreads.Size = new System.Drawing.Size(213, 28);
            this.numProcessingThreads.TabIndex = 23;
            this.numProcessingThreads.Title = "Processing Threads";
            this.numProcessingThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numStarBufferSize
            // 
            this.numStarBufferSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numStarBufferSize.DecimalPlaces = 0;
            this.numStarBufferSize.Location = new System.Drawing.Point(916, 148);
            this.numStarBufferSize.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numStarBufferSize.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStarBufferSize.Name = "numStarBufferSize";
            this.numStarBufferSize.Size = new System.Drawing.Size(192, 28);
            this.numStarBufferSize.TabIndex = 22;
            this.numStarBufferSize.Title = "Star Buffer Size";
            this.numStarBufferSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMaxStarsPerSector
            // 
            this.numMaxStarsPerSector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMaxStarsPerSector.DecimalPlaces = 0;
            this.numMaxStarsPerSector.Location = new System.Drawing.Point(895, 216);
            this.numMaxStarsPerSector.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numMaxStarsPerSector.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxStarsPerSector.Name = "numMaxStarsPerSector";
            this.numMaxStarsPerSector.Size = new System.Drawing.Size(213, 28);
            this.numMaxStarsPerSector.TabIndex = 24;
            this.numMaxStarsPerSector.Title = "Max Stars Per Sector";
            this.numMaxStarsPerSector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMiniumDistanceToBlackHole
            // 
            this.numMiniumDistanceToBlackHole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numMiniumDistanceToBlackHole.DecimalPlaces = 2;
            this.numMiniumDistanceToBlackHole.Location = new System.Drawing.Point(270, 19);
            this.numMiniumDistanceToBlackHole.MaximumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numMiniumDistanceToBlackHole.MinimumValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numMiniumDistanceToBlackHole.Name = "numMiniumDistanceToBlackHole";
            this.numMiniumDistanceToBlackHole.Size = new System.Drawing.Size(245, 28);
            this.numMiniumDistanceToBlackHole.TabIndex = 19;
            this.numMiniumDistanceToBlackHole.Title = "Min Distance to Black Hole";
            this.numMiniumDistanceToBlackHole.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UniversalRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 606);
            this.Controls.Add(this.numMaxStarsPerSector);
            this.Controls.Add(this.numProcessingThreads);
            this.Controls.Add(this.checkRenderVelocityVectors);
            this.Controls.Add(this.numStarBufferSize);
            this.Controls.Add(this.checkRenderSectors);
            this.Controls.Add(this.checkRenderStars);
            this.Controls.Add(this.btnNewUniverse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUniverses);
            this.Controls.Add(this.listUniverses);
            this.Controls.Add(this.groupGalaxy);
            this.Controls.Add(this.btnNewGalaxy);
            this.Controls.Add(this.listGalaxies);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numGridSize);
            this.Controls.Add(this.btnApply);
            this.Name = "UniversalRemote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Universal Remote";
            this.Load += new System.EventHandler(this.UniversalRemote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numGridSize)).EndInit();
            this.groupGalaxy.ResumeLayout(false);
            this.groupGalaxyOrientation.ResumeLayout(false);
            this.groupStarDistribution.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numGridSize;
        private System.Windows.Forms.ListBox listGalaxies;
        private System.Windows.Forms.Button btnNewGalaxy;
        private System.Windows.Forms.GroupBox groupGalaxy;
        private LabeledNumericControl numGalaxyStarCount;
        private LabeledNumericControl numStarDistributionIterations;
        private LabeledNumericControl numStarDistributionSkewLowX;
        private LabeledNumericControl numStarDistributionPercentZ;
        private LabeledNumericControl numStarDistributionSkewHighZ;
        private LabeledNumericControl numStarDistributionSkewLowZ;
        private LabeledNumericControl numStarDistributionPercentY;
        private LabeledNumericControl numStarDistributionSkewHighY;
        private LabeledNumericControl numStarDistributionSkewLowY;
        private LabeledNumericControl numStarDistributionPercentX;
        private LabeledNumericControl numStarDistributionSkewHighX;
        private System.Windows.Forms.GroupBox groupGalaxyOrientation;
        private LabeledNumericControl numGalaxyCenterZ;
        private LabeledNumericControl numGalaxyCenterX;
        private LabeledNumericControl numGalaxyCenterY;
        private System.Windows.Forms.GroupBox groupStarDistribution;
        private System.Windows.Forms.ListBox listUniverses;
        private System.Windows.Forms.Label labelUniverses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewUniverse;
        private System.Windows.Forms.CheckBox checkRenderStars;
        private System.Windows.Forms.CheckBox checkRenderSectors;
        private LabeledNumericControl numSupermassiveBlackHoleSolarMasses;
        private System.Windows.Forms.CheckBox checkRenderVelocityVectors;
        private LabeledNumericControl numStarVelocity;
        private LabeledNumericControl numStarMass;
        private System.Windows.Forms.Button btnGalaxyColor;
        private System.Windows.Forms.Panel panelGalaxyColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private LabeledNumericControl numProcessingThreads;
        private LabeledNumericControl numStarBufferSize;
        private LabeledNumericControl numMaxStarsPerSector;
        private LabeledNumericControl numMiniumDistanceToBlackHole;

    }
}