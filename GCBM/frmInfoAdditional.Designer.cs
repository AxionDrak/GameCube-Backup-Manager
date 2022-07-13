
using System.ComponentModel;
using System.Windows.Forms;

namespace GCBM
{
    partial class frmInfoAdditional
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoAdditional));
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.tbGameSHA1 = new System.Windows.Forms.TextBox();
            this.tbGameMD5 = new System.Windows.Forms.TextBox();
            this.tbGameCRC = new System.Windows.Forms.TextBox();
            this.lblSha1 = new System.Windows.Forms.Label();
            this.lblMd5 = new System.Windows.Forms.Label();
            this.lblCrc = new System.Windows.Forms.Label();
            this.tbGameVersion = new System.Windows.Forms.TextBox();
            this.tbGameControl = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblRequirements = new System.Windows.Forms.Label();
            this.tbGamePlayersOnline = new System.Windows.Forms.TextBox();
            this.tbGamePlayers = new System.Windows.Forms.TextBox();
            this.tbGameDescriptor = new System.Windows.Forms.TextBox();
            this.lblPlayersOnline = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.pbGameTitle = new System.Windows.Forms.PictureBox();
            this.tbGameRatingValue = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDateGlobal = new System.Windows.Forms.Label();
            this.tbGameMonth = new System.Windows.Forms.TextBox();
            this.tbGameDay = new System.Windows.Forms.TextBox();
            this.lblInternalName = new System.Windows.Forms.Label();
            this.tbGameInternalName = new System.Windows.Forms.TextBox();
            this.tbGameSynopsis = new System.Windows.Forms.TextBox();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbESRB_T = new System.Windows.Forms.PictureBox();
            this.pbESRB_C = new System.Windows.Forms.PictureBox();
            this.pbESRB_RP = new System.Windows.Forms.PictureBox();
            this.pbESRB_A = new System.Windows.Forms.PictureBox();
            this.pbESRB_M = new System.Windows.Forms.PictureBox();
            this.pbESRB_Eplus = new System.Windows.Forms.PictureBox();
            this.pbESRB_E = new System.Windows.Forms.PictureBox();
            this.tbGameRegion = new System.Windows.Forms.TextBox();
            this.tbGameRatingType = new System.Windows.Forms.TextBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.tbGameGenre = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.tbGameYear = new System.Windows.Forms.TextBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.tbGameDeveloper = new System.Windows.Forms.TextBox();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.tbGamePublisher = new System.Windows.Forms.TextBox();
            this.tbGameLanguage = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameTitle)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_T)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_C)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_RP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_Eplus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_E)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.tbGameSHA1);
            this.grpInfo.Controls.Add(this.tbGameMD5);
            this.grpInfo.Controls.Add(this.tbGameCRC);
            this.grpInfo.Controls.Add(this.lblSha1);
            this.grpInfo.Controls.Add(this.lblMd5);
            this.grpInfo.Controls.Add(this.lblCrc);
            this.grpInfo.Controls.Add(this.tbGameVersion);
            this.grpInfo.Controls.Add(this.tbGameControl);
            this.grpInfo.Controls.Add(this.lblVersion);
            this.grpInfo.Controls.Add(this.lblRequirements);
            this.grpInfo.Controls.Add(this.tbGamePlayersOnline);
            this.grpInfo.Controls.Add(this.tbGamePlayers);
            this.grpInfo.Controls.Add(this.tbGameDescriptor);
            this.grpInfo.Controls.Add(this.lblPlayersOnline);
            this.grpInfo.Controls.Add(this.lblPlayers);
            this.grpInfo.Controls.Add(this.lblContent);
            this.grpInfo.Controls.Add(this.pbGameTitle);
            this.grpInfo.Controls.Add(this.tbGameRatingValue);
            this.grpInfo.Controls.Add(this.lblType);
            this.grpInfo.Controls.Add(this.lblDateGlobal);
            this.grpInfo.Controls.Add(this.tbGameMonth);
            this.grpInfo.Controls.Add(this.tbGameDay);
            this.grpInfo.Controls.Add(this.lblInternalName);
            this.grpInfo.Controls.Add(this.tbGameInternalName);
            this.grpInfo.Controls.Add(this.tbGameSynopsis);
            this.grpInfo.Controls.Add(this.lblSynopsis);
            this.grpInfo.Controls.Add(this.groupBox1);
            this.grpInfo.Controls.Add(this.tbGameRegion);
            this.grpInfo.Controls.Add(this.tbGameRatingType);
            this.grpInfo.Controls.Add(this.lblRegion);
            this.grpInfo.Controls.Add(this.tbGameGenre);
            this.grpInfo.Controls.Add(this.lblDate);
            this.grpInfo.Controls.Add(this.lblGenre);
            this.grpInfo.Controls.Add(this.tbGameYear);
            this.grpInfo.Controls.Add(this.lblLanguage);
            this.grpInfo.Controls.Add(this.lblRating);
            this.grpInfo.Controls.Add(this.tbGameDeveloper);
            this.grpInfo.Controls.Add(this.lblDeveloper);
            this.grpInfo.Controls.Add(this.lblPublisher);
            this.grpInfo.Controls.Add(this.tbGamePublisher);
            this.grpInfo.Controls.Add(this.tbGameLanguage);
            resources.ApplyResources(this.grpInfo, "grpInfo");
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.TabStop = false;
            // 
            // tbGameSHA1
            // 
            this.tbGameSHA1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameSHA1, "tbGameSHA1");
            this.tbGameSHA1.Name = "tbGameSHA1";
            this.tbGameSHA1.ReadOnly = true;
            // 
            // tbGameMD5
            // 
            this.tbGameMD5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameMD5, "tbGameMD5");
            this.tbGameMD5.Name = "tbGameMD5";
            this.tbGameMD5.ReadOnly = true;
            // 
            // tbGameCRC
            // 
            this.tbGameCRC.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameCRC, "tbGameCRC");
            this.tbGameCRC.Name = "tbGameCRC";
            this.tbGameCRC.ReadOnly = true;
            // 
            // lblSha1
            // 
            resources.ApplyResources(this.lblSha1, "lblSha1");
            this.lblSha1.Name = "lblSha1";
            // 
            // lblMd5
            // 
            resources.ApplyResources(this.lblMd5, "lblMd5");
            this.lblMd5.Name = "lblMd5";
            // 
            // lblCrc
            // 
            resources.ApplyResources(this.lblCrc, "lblCrc");
            this.lblCrc.Name = "lblCrc";
            // 
            // tbGameVersion
            // 
            this.tbGameVersion.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameVersion, "tbGameVersion");
            this.tbGameVersion.Name = "tbGameVersion";
            this.tbGameVersion.ReadOnly = true;
            // 
            // tbGameControl
            // 
            this.tbGameControl.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameControl, "tbGameControl");
            this.tbGameControl.Name = "tbGameControl";
            this.tbGameControl.ReadOnly = true;
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            // 
            // lblRequirements
            // 
            resources.ApplyResources(this.lblRequirements, "lblRequirements");
            this.lblRequirements.Name = "lblRequirements";
            // 
            // tbGamePlayersOnline
            // 
            this.tbGamePlayersOnline.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGamePlayersOnline, "tbGamePlayersOnline");
            this.tbGamePlayersOnline.Name = "tbGamePlayersOnline";
            this.tbGamePlayersOnline.ReadOnly = true;
            // 
            // tbGamePlayers
            // 
            this.tbGamePlayers.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGamePlayers, "tbGamePlayers");
            this.tbGamePlayers.Name = "tbGamePlayers";
            this.tbGamePlayers.ReadOnly = true;
            // 
            // tbGameDescriptor
            // 
            this.tbGameDescriptor.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameDescriptor, "tbGameDescriptor");
            this.tbGameDescriptor.Name = "tbGameDescriptor";
            this.tbGameDescriptor.ReadOnly = true;
            // 
            // lblPlayersOnline
            // 
            resources.ApplyResources(this.lblPlayersOnline, "lblPlayersOnline");
            this.lblPlayersOnline.Name = "lblPlayersOnline";
            // 
            // lblPlayers
            // 
            resources.ApplyResources(this.lblPlayers, "lblPlayers");
            this.lblPlayers.Name = "lblPlayers";
            // 
            // lblContent
            // 
            resources.ApplyResources(this.lblContent, "lblContent");
            this.lblContent.Name = "lblContent";
            // 
            // pbGameTitle
            // 
            resources.ApplyResources(this.pbGameTitle, "pbGameTitle");
            this.pbGameTitle.Image = global::GCBM.Properties.Resources.website_grayscale;
            this.pbGameTitle.Name = "pbGameTitle";
            this.pbGameTitle.TabStop = false;
            this.pbGameTitle.Click += new System.EventHandler(this.pbGameTitle_Click);
            // 
            // tbGameRatingValue
            // 
            this.tbGameRatingValue.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameRatingValue, "tbGameRatingValue");
            this.tbGameRatingValue.Name = "tbGameRatingValue";
            this.tbGameRatingValue.ReadOnly = true;
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // lblDateGlobal
            // 
            resources.ApplyResources(this.lblDateGlobal, "lblDateGlobal");
            this.lblDateGlobal.Name = "lblDateGlobal";
            // 
            // tbGameMonth
            // 
            this.tbGameMonth.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameMonth, "tbGameMonth");
            this.tbGameMonth.Name = "tbGameMonth";
            this.tbGameMonth.ReadOnly = true;
            // 
            // tbGameDay
            // 
            this.tbGameDay.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameDay, "tbGameDay");
            this.tbGameDay.Name = "tbGameDay";
            this.tbGameDay.ReadOnly = true;
            // 
            // lblInternalName
            // 
            resources.ApplyResources(this.lblInternalName, "lblInternalName");
            this.lblInternalName.Name = "lblInternalName";
            // 
            // tbGameInternalName
            // 
            this.tbGameInternalName.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameInternalName, "tbGameInternalName");
            this.tbGameInternalName.Name = "tbGameInternalName";
            this.tbGameInternalName.ReadOnly = true;
            // 
            // tbGameSynopsis
            // 
            this.tbGameSynopsis.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameSynopsis, "tbGameSynopsis");
            this.tbGameSynopsis.Name = "tbGameSynopsis";
            this.tbGameSynopsis.ReadOnly = true;
            // 
            // lblSynopsis
            // 
            resources.ApplyResources(this.lblSynopsis, "lblSynopsis");
            this.lblSynopsis.Name = "lblSynopsis";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbESRB_T);
            this.groupBox1.Controls.Add(this.pbESRB_C);
            this.groupBox1.Controls.Add(this.pbESRB_RP);
            this.groupBox1.Controls.Add(this.pbESRB_A);
            this.groupBox1.Controls.Add(this.pbESRB_M);
            this.groupBox1.Controls.Add(this.pbESRB_Eplus);
            this.groupBox1.Controls.Add(this.pbESRB_E);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pbESRB_T
            // 
            this.pbESRB_T.Image = global::GCBM.Properties.Resources.ESRB_Teen_grayscale;
            resources.ApplyResources(this.pbESRB_T, "pbESRB_T");
            this.pbESRB_T.Name = "pbESRB_T";
            this.pbESRB_T.TabStop = false;
            // 
            // pbESRB_C
            // 
            this.pbESRB_C.Image = global::GCBM.Properties.Resources.ESRB_Early_Childhood_grayscale;
            resources.ApplyResources(this.pbESRB_C, "pbESRB_C");
            this.pbESRB_C.Name = "pbESRB_C";
            this.pbESRB_C.TabStop = false;
            // 
            // pbESRB_RP
            // 
            this.pbESRB_RP.Image = global::GCBM.Properties.Resources.ESRB_RP_grayscale;
            resources.ApplyResources(this.pbESRB_RP, "pbESRB_RP");
            this.pbESRB_RP.Name = "pbESRB_RP";
            this.pbESRB_RP.TabStop = false;
            // 
            // pbESRB_A
            // 
            this.pbESRB_A.Image = global::GCBM.Properties.Resources.ESRB_Adults_Only_18__grayscale;
            resources.ApplyResources(this.pbESRB_A, "pbESRB_A");
            this.pbESRB_A.Name = "pbESRB_A";
            this.pbESRB_A.TabStop = false;
            // 
            // pbESRB_M
            // 
            this.pbESRB_M.Image = global::GCBM.Properties.Resources.ESRB_Mature_17__grayscale;
            resources.ApplyResources(this.pbESRB_M, "pbESRB_M");
            this.pbESRB_M.Name = "pbESRB_M";
            this.pbESRB_M.TabStop = false;
            // 
            // pbESRB_Eplus
            // 
            this.pbESRB_Eplus.Image = global::GCBM.Properties.Resources.ESRB_Everyone_10__grayscale;
            resources.ApplyResources(this.pbESRB_Eplus, "pbESRB_Eplus");
            this.pbESRB_Eplus.Name = "pbESRB_Eplus";
            this.pbESRB_Eplus.TabStop = false;
            // 
            // pbESRB_E
            // 
            this.pbESRB_E.Image = global::GCBM.Properties.Resources.ESRB_Everyone_grayscale;
            resources.ApplyResources(this.pbESRB_E, "pbESRB_E");
            this.pbESRB_E.Name = "pbESRB_E";
            this.pbESRB_E.TabStop = false;
            // 
            // tbGameRegion
            // 
            this.tbGameRegion.BackColor = System.Drawing.Color.White;
            this.tbGameRegion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tbGameRegion, "tbGameRegion");
            this.tbGameRegion.Name = "tbGameRegion";
            this.tbGameRegion.ReadOnly = true;
            // 
            // tbGameRatingType
            // 
            this.tbGameRatingType.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameRatingType, "tbGameRatingType");
            this.tbGameRatingType.Name = "tbGameRatingType";
            this.tbGameRatingType.ReadOnly = true;
            // 
            // lblRegion
            // 
            resources.ApplyResources(this.lblRegion, "lblRegion");
            this.lblRegion.Name = "lblRegion";
            // 
            // tbGameGenre
            // 
            this.tbGameGenre.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameGenre, "tbGameGenre");
            this.tbGameGenre.Name = "tbGameGenre";
            this.tbGameGenre.ReadOnly = true;
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            // 
            // lblGenre
            // 
            resources.ApplyResources(this.lblGenre, "lblGenre");
            this.lblGenre.Name = "lblGenre";
            // 
            // tbGameYear
            // 
            this.tbGameYear.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameYear, "tbGameYear");
            this.tbGameYear.Name = "tbGameYear";
            this.tbGameYear.ReadOnly = true;
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // lblRating
            // 
            resources.ApplyResources(this.lblRating, "lblRating");
            this.lblRating.Name = "lblRating";
            // 
            // tbGameDeveloper
            // 
            this.tbGameDeveloper.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGameDeveloper, "tbGameDeveloper");
            this.tbGameDeveloper.Name = "tbGameDeveloper";
            this.tbGameDeveloper.ReadOnly = true;
            // 
            // lblDeveloper
            // 
            resources.ApplyResources(this.lblDeveloper, "lblDeveloper");
            this.lblDeveloper.Name = "lblDeveloper";
            // 
            // lblPublisher
            // 
            resources.ApplyResources(this.lblPublisher, "lblPublisher");
            this.lblPublisher.Name = "lblPublisher";
            // 
            // tbGamePublisher
            // 
            this.tbGamePublisher.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tbGamePublisher, "tbGamePublisher");
            this.tbGamePublisher.Name = "tbGamePublisher";
            this.tbGamePublisher.ReadOnly = true;
            // 
            // tbGameLanguage
            // 
            this.tbGameLanguage.BackColor = System.Drawing.Color.White;
            this.tbGameLanguage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tbGameLanguage, "tbGameLanguage");
            this.tbGameLanguage.Name = "tbGameLanguage";
            this.tbGameLanguage.ReadOnly = true;
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // frmInfoAdditional
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfoAdditional";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameTitle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_T)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_C)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_RP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_Eplus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbESRB_E)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grpInfo;
        private TextBox tbGameSHA1;
        private TextBox tbGameMD5;
        private TextBox tbGameCRC;
        private Label lblSha1;
        private Label lblMd5;
        private Label lblCrc;
        private TextBox tbGameVersion;
        private TextBox tbGameControl;
        private Label lblVersion;
        private Label lblRequirements;
        private TextBox tbGamePlayersOnline;
        private TextBox tbGamePlayers;
        private TextBox tbGameDescriptor;
        private Label lblPlayersOnline;
        private Label lblPlayers;
        private Label lblContent;
        private PictureBox pbGameTitle;
        private TextBox tbGameRatingValue;
        private Label lblType;
        private Label lblDateGlobal;
        private TextBox tbGameMonth;
        private TextBox tbGameDay;
        private Label lblInternalName;
        private TextBox tbGameInternalName;
        private TextBox tbGameSynopsis;
        private Label lblSynopsis;
        private GroupBox groupBox1;
        private PictureBox pbESRB_T;
        private PictureBox pbESRB_C;
        private PictureBox pbESRB_RP;
        private PictureBox pbESRB_A;
        private PictureBox pbESRB_M;
        private PictureBox pbESRB_Eplus;
        private PictureBox pbESRB_E;
        private TextBox tbGameRegion;
        private TextBox tbGameRatingType;
        private Label lblRegion;
        private TextBox tbGameGenre;
        private Label lblDate;
        private Label lblGenre;
        private TextBox tbGameYear;
        private Label lblLanguage;
        private Label lblRating;
        private TextBox tbGameDeveloper;
        private Label lblDeveloper;
        private Label lblPublisher;
        private TextBox tbGamePublisher;
        private TextBox tbGameLanguage;
        private Button btnClose;
        private NotifyIcon notifyIcon;
    }
}