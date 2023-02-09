
namespace Cohesion_Project
{
   partial class Frm_Main
   {
      /// <summary>
      /// 필수 디자이너 변수입니다.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// 사용 중인 모든 리소스를 정리합니다.
      /// </summary>
      /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form 디자이너에서 생성한 코드

      /// <summary>
      /// 디자이너 지원에 필요한 메서드입니다. 
      /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.Flp_Side = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnWorkOrder = new System.Windows.Forms.Button();
            this.btnProductBOM = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnOperation = new System.Windows.Forms.Button();
            this.btnEquipment = new System.Windows.Forms.Button();
            this.btnEquipmentOperationRel = new System.Windows.Forms.Button();
            this.btnInspection = new System.Windows.Forms.Button();
            this.btnOperationInspectionRel = new System.Windows.Forms.Button();
            this.btnProductOperationRel = new System.Windows.Forms.Button();
            this.btnCommon = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnUserGroup = new System.Windows.Forms.Button();
            this.btnFunctionUserGroup = new System.Windows.Forms.Button();
            this.btnFuction_ = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Lbl_Position = new System.Windows.Forms.Label();
            this.Lbl_Part = new System.Windows.Forms.Label();
            this.Lbl_Id = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Pnl_Top = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.cc_TabControl1 = new Cohesion_Project.Cc_TabControl();
            this.Flp_Side.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Pnl_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // Flp_Side
            // 
            this.Flp_Side.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Flp_Side.AutoScroll = true;
            this.Flp_Side.BackColor = System.Drawing.Color.Transparent;
            this.Flp_Side.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Flp_Side.CausesValidation = false;
            this.Flp_Side.Controls.Add(this.btnProduct);
            this.Flp_Side.Controls.Add(this.btnOrder);
            this.Flp_Side.Controls.Add(this.btnWorkOrder);
            this.Flp_Side.Controls.Add(this.btnProductBOM);
            this.Flp_Side.Controls.Add(this.btnStore);
            this.Flp_Side.Controls.Add(this.btnOperation);
            this.Flp_Side.Controls.Add(this.btnEquipment);
            this.Flp_Side.Controls.Add(this.btnEquipmentOperationRel);
            this.Flp_Side.Controls.Add(this.btnInspection);
            this.Flp_Side.Controls.Add(this.btnOperationInspectionRel);
            this.Flp_Side.Controls.Add(this.btnProductOperationRel);
            this.Flp_Side.Controls.Add(this.btnCommon);
            this.Flp_Side.Controls.Add(this.btnUser);
            this.Flp_Side.Controls.Add(this.btnUserGroup);
            this.Flp_Side.Controls.Add(this.btnFunctionUserGroup);
            this.Flp_Side.Controls.Add(this.btnFuction_);
            this.Flp_Side.Location = new System.Drawing.Point(0, 56);
            this.Flp_Side.Margin = new System.Windows.Forms.Padding(0);
            this.Flp_Side.Name = "Flp_Side";
            this.Flp_Side.Size = new System.Drawing.Size(180, 942);
            this.Flp_Side.TabIndex = 11;
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnProduct.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProduct.Location = new System.Drawing.Point(0, 0);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(0);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProduct.Size = new System.Drawing.Size(177, 50);
            this.btnProduct.TabIndex = 2;
            this.btnProduct.Text = "▶ 제품 관리";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            this.btnProduct.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnProduct.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnOrder.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOrder.Location = new System.Drawing.Point(0, 50);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnOrder.Size = new System.Drawing.Size(177, 50);
            this.btnOrder.TabIndex = 7;
            this.btnOrder.Text = "▶ 주문 관리";
            this.btnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            this.btnOrder.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnOrder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnWorkOrder
            // 
            this.btnWorkOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnWorkOrder.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnWorkOrder.FlatAppearance.BorderSize = 0;
            this.btnWorkOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWorkOrder.Location = new System.Drawing.Point(0, 100);
            this.btnWorkOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnWorkOrder.Name = "btnWorkOrder";
            this.btnWorkOrder.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnWorkOrder.Size = new System.Drawing.Size(177, 50);
            this.btnWorkOrder.TabIndex = 8;
            this.btnWorkOrder.Text = "▶ 생산지시 관리";
            this.btnWorkOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorkOrder.UseVisualStyleBackColor = false;
            this.btnWorkOrder.Click += new System.EventHandler(this.btnWorkOrder_Click);
            this.btnWorkOrder.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnWorkOrder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnProductBOM
            // 
            this.btnProductBOM.BackColor = System.Drawing.Color.Transparent;
            this.btnProductBOM.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnProductBOM.FlatAppearance.BorderSize = 0;
            this.btnProductBOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductBOM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProductBOM.Location = new System.Drawing.Point(0, 150);
            this.btnProductBOM.Margin = new System.Windows.Forms.Padding(0);
            this.btnProductBOM.Name = "btnProductBOM";
            this.btnProductBOM.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProductBOM.Size = new System.Drawing.Size(177, 50);
            this.btnProductBOM.TabIndex = 10;
            this.btnProductBOM.Text = "▶ BOM 관리";
            this.btnProductBOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductBOM.UseVisualStyleBackColor = false;
            this.btnProductBOM.Click += new System.EventHandler(this.btnProductBOM_Click);
            this.btnProductBOM.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnProductBOM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnStore
            // 
            this.btnStore.BackColor = System.Drawing.Color.Transparent;
            this.btnStore.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnStore.FlatAppearance.BorderSize = 0;
            this.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStore.Location = new System.Drawing.Point(0, 200);
            this.btnStore.Margin = new System.Windows.Forms.Padding(0);
            this.btnStore.Name = "btnStore";
            this.btnStore.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnStore.Size = new System.Drawing.Size(177, 50);
            this.btnStore.TabIndex = 11;
            this.btnStore.Text = "▶ 창고 관리";
            this.btnStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStore.UseVisualStyleBackColor = false;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            this.btnStore.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnStore.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnOperation
            // 
            this.btnOperation.BackColor = System.Drawing.Color.Transparent;
            this.btnOperation.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOperation.FlatAppearance.BorderSize = 0;
            this.btnOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOperation.Location = new System.Drawing.Point(0, 250);
            this.btnOperation.Margin = new System.Windows.Forms.Padding(0);
            this.btnOperation.Name = "btnOperation";
            this.btnOperation.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnOperation.Size = new System.Drawing.Size(177, 50);
            this.btnOperation.TabIndex = 13;
            this.btnOperation.Text = "▶ 공정 관리";
            this.btnOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOperation.UseVisualStyleBackColor = false;
            this.btnOperation.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnOperation.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnOperation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnEquipment
            // 
            this.btnEquipment.BackColor = System.Drawing.Color.Transparent;
            this.btnEquipment.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEquipment.FlatAppearance.BorderSize = 0;
            this.btnEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquipment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEquipment.Location = new System.Drawing.Point(0, 300);
            this.btnEquipment.Margin = new System.Windows.Forms.Padding(0);
            this.btnEquipment.Name = "btnEquipment";
            this.btnEquipment.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEquipment.Size = new System.Drawing.Size(177, 50);
            this.btnEquipment.TabIndex = 20;
            this.btnEquipment.Text = "▶ 설비 관리";
            this.btnEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEquipment.UseVisualStyleBackColor = false;
            this.btnEquipment.Click += new System.EventHandler(this.btnEquipment_Click);
            this.btnEquipment.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnEquipment.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnEquipmentOperationRel
            // 
            this.btnEquipmentOperationRel.BackColor = System.Drawing.Color.Transparent;
            this.btnEquipmentOperationRel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEquipmentOperationRel.FlatAppearance.BorderSize = 0;
            this.btnEquipmentOperationRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquipmentOperationRel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEquipmentOperationRel.Location = new System.Drawing.Point(0, 350);
            this.btnEquipmentOperationRel.Margin = new System.Windows.Forms.Padding(0);
            this.btnEquipmentOperationRel.Name = "btnEquipmentOperationRel";
            this.btnEquipmentOperationRel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEquipmentOperationRel.Size = new System.Drawing.Size(177, 50);
            this.btnEquipmentOperationRel.TabIndex = 21;
            this.btnEquipmentOperationRel.Text = "▶ 설비 공정 관계 설정";
            this.btnEquipmentOperationRel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEquipmentOperationRel.UseVisualStyleBackColor = false;
            this.btnEquipmentOperationRel.Click += new System.EventHandler(this.btnEquipmentOperationRel_Click);
            this.btnEquipmentOperationRel.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnEquipmentOperationRel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnInspection
            // 
            this.btnInspection.BackColor = System.Drawing.Color.Transparent;
            this.btnInspection.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnInspection.FlatAppearance.BorderSize = 0;
            this.btnInspection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInspection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInspection.Location = new System.Drawing.Point(0, 400);
            this.btnInspection.Margin = new System.Windows.Forms.Padding(0);
            this.btnInspection.Name = "btnInspection";
            this.btnInspection.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnInspection.Size = new System.Drawing.Size(177, 50);
            this.btnInspection.TabIndex = 4;
            this.btnInspection.Text = "▶ 검사항목 관리";
            this.btnInspection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInspection.UseVisualStyleBackColor = false;
            this.btnInspection.Click += new System.EventHandler(this.btnInspection_Click);
            this.btnInspection.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnInspection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnOperationInspectionRel
            // 
            this.btnOperationInspectionRel.BackColor = System.Drawing.Color.Transparent;
            this.btnOperationInspectionRel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOperationInspectionRel.FlatAppearance.BorderSize = 0;
            this.btnOperationInspectionRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperationInspectionRel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOperationInspectionRel.Location = new System.Drawing.Point(0, 450);
            this.btnOperationInspectionRel.Margin = new System.Windows.Forms.Padding(0);
            this.btnOperationInspectionRel.Name = "btnOperationInspectionRel";
            this.btnOperationInspectionRel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnOperationInspectionRel.Size = new System.Drawing.Size(177, 50);
            this.btnOperationInspectionRel.TabIndex = 15;
            this.btnOperationInspectionRel.Text = "▶ 공정 검사 관계 설정";
            this.btnOperationInspectionRel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOperationInspectionRel.UseVisualStyleBackColor = false;
            this.btnOperationInspectionRel.Click += new System.EventHandler(this.btnOperationInspectionRel_Click);
            this.btnOperationInspectionRel.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnOperationInspectionRel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnProductOperationRel
            // 
            this.btnProductOperationRel.BackColor = System.Drawing.Color.Transparent;
            this.btnProductOperationRel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnProductOperationRel.FlatAppearance.BorderSize = 0;
            this.btnProductOperationRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductOperationRel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProductOperationRel.Location = new System.Drawing.Point(0, 500);
            this.btnProductOperationRel.Margin = new System.Windows.Forms.Padding(0);
            this.btnProductOperationRel.Name = "btnProductOperationRel";
            this.btnProductOperationRel.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProductOperationRel.Size = new System.Drawing.Size(177, 50);
            this.btnProductOperationRel.TabIndex = 14;
            this.btnProductOperationRel.Text = "▶ 제품 공정 관계 설정";
            this.btnProductOperationRel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductOperationRel.UseVisualStyleBackColor = false;
            this.btnProductOperationRel.Click += new System.EventHandler(this.btnProductOperationRel_Click);
            this.btnProductOperationRel.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnProductOperationRel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnCommon
            // 
            this.btnCommon.BackColor = System.Drawing.Color.Transparent;
            this.btnCommon.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCommon.FlatAppearance.BorderSize = 0;
            this.btnCommon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCommon.Location = new System.Drawing.Point(0, 550);
            this.btnCommon.Margin = new System.Windows.Forms.Padding(0);
            this.btnCommon.Name = "btnCommon";
            this.btnCommon.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCommon.Size = new System.Drawing.Size(177, 50);
            this.btnCommon.TabIndex = 3;
            this.btnCommon.Text = "▶ 공통코드 관리";
            this.btnCommon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommon.UseVisualStyleBackColor = false;
            this.btnCommon.Click += new System.EventHandler(this.btnCommon_Click);
            this.btnCommon.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnCommon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.Transparent;
            this.btnUser.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUser.Location = new System.Drawing.Point(0, 600);
            this.btnUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnUser.Size = new System.Drawing.Size(177, 50);
            this.btnUser.TabIndex = 19;
            this.btnUser.Text = "▶ 사용자 관리";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            this.btnUser.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnUser.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnUserGroup
            // 
            this.btnUserGroup.BackColor = System.Drawing.Color.Transparent;
            this.btnUserGroup.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnUserGroup.FlatAppearance.BorderSize = 0;
            this.btnUserGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUserGroup.Location = new System.Drawing.Point(0, 650);
            this.btnUserGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnUserGroup.Name = "btnUserGroup";
            this.btnUserGroup.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnUserGroup.Size = new System.Drawing.Size(177, 50);
            this.btnUserGroup.TabIndex = 18;
            this.btnUserGroup.Text = "▶ 사용자 그룹 관리";
            this.btnUserGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserGroup.UseVisualStyleBackColor = false;
            this.btnUserGroup.Click += new System.EventHandler(this.btnUserGroup_Click);
            this.btnUserGroup.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnUserGroup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnFunctionUserGroup
            // 
            this.btnFunctionUserGroup.BackColor = System.Drawing.Color.Transparent;
            this.btnFunctionUserGroup.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnFunctionUserGroup.FlatAppearance.BorderSize = 0;
            this.btnFunctionUserGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFunctionUserGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFunctionUserGroup.Location = new System.Drawing.Point(0, 700);
            this.btnFunctionUserGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnFunctionUserGroup.Name = "btnFunctionUserGroup";
            this.btnFunctionUserGroup.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnFunctionUserGroup.Size = new System.Drawing.Size(177, 50);
            this.btnFunctionUserGroup.TabIndex = 16;
            this.btnFunctionUserGroup.Text = "▶ 사용자 권한 관리";
            this.btnFunctionUserGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFunctionUserGroup.UseVisualStyleBackColor = false;
            this.btnFunctionUserGroup.Click += new System.EventHandler(this.btnFunctionUserGroup_Click);
            this.btnFunctionUserGroup.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnFunctionUserGroup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // btnFuction_
            // 
            this.btnFuction_.BackColor = System.Drawing.Color.Transparent;
            this.btnFuction_.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnFuction_.FlatAppearance.BorderSize = 0;
            this.btnFuction_.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuction_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFuction_.Location = new System.Drawing.Point(0, 750);
            this.btnFuction_.Margin = new System.Windows.Forms.Padding(0);
            this.btnFuction_.Name = "btnFuction_";
            this.btnFuction_.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnFuction_.Size = new System.Drawing.Size(177, 50);
            this.btnFuction_.TabIndex = 17;
            this.btnFuction_.Text = "▶ 화면 기능 관리";
            this.btnFuction_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFuction_.UseVisualStyleBackColor = false;
            this.btnFuction_.Click += new System.EventHandler(this.btnFuction__Click);
            this.btnFuction_.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnFuction_.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.Flp_Side);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 1000);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 55);
            this.panel3.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(74, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "Cohesion";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 55);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(180, 980);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 20);
            this.panel1.TabIndex = 18;
            this.panel1.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Position, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Part, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Id, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(443, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 20);
            this.tableLayoutPanel1.TabIndex = 72;
            // 
            // Lbl_Position
            // 
            this.Lbl_Position.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lbl_Position.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Lbl_Position.Location = new System.Drawing.Point(803, 0);
            this.Lbl_Position.Name = "Lbl_Position";
            this.Lbl_Position.Size = new System.Drawing.Size(94, 20);
            this.Lbl_Position.TabIndex = 1;
            this.Lbl_Position.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_Part
            // 
            this.Lbl_Part.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lbl_Part.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Lbl_Part.Location = new System.Drawing.Point(703, 0);
            this.Lbl_Part.Name = "Lbl_Part";
            this.Lbl_Part.Size = new System.Drawing.Size(94, 20);
            this.Lbl_Part.TabIndex = 2;
            this.Lbl_Part.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_Id
            // 
            this.Lbl_Id.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lbl_Id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Lbl_Id.Location = new System.Drawing.Point(603, 0);
            this.Lbl_Id.Name = "Lbl_Id";
            this.Lbl_Id.Size = new System.Drawing.Size(94, 20);
            this.Lbl_Id.TabIndex = 3;
            this.Lbl_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(180, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1346, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // Pnl_Top
            // 
            this.Pnl_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.Pnl_Top.Controls.Add(this.lblUserName);
            this.Pnl_Top.Controls.Add(this.Btn_Close);
            this.Pnl_Top.Controls.Add(this.menuStrip2);
            this.Pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Top.Location = new System.Drawing.Point(180, 0);
            this.Pnl_Top.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pnl_Top.Name = "Pnl_Top";
            this.Pnl_Top.Size = new System.Drawing.Size(1346, 30);
            this.Pnl_Top.TabIndex = 23;
            // 
            // lblUserName
            // 
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUserName.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblUserName.Location = new System.Drawing.Point(1216, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(80, 30);
            this.lblUserName.TabIndex = 17;
            this.lblUserName.Text = "관리자";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_Close
            // 
            this.Btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.Btn_Close.FlatAppearance.BorderSize = 0;
            this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Btn_Close.Location = new System.Drawing.Point(1296, 0);
            this.Btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(50, 30);
            this.Btn_Close.TabIndex = 7;
            this.Btn_Close.Text = "X";
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1346, 24);
            this.menuStrip2.TabIndex = 18;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.Visible = false;
            // 
            // cc_TabControl1
            // 
            this.cc_TabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cc_TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.cc_TabControl1.Location = new System.Drawing.Point(180, 30);
            this.cc_TabControl1.Name = "cc_TabControl1";
            this.cc_TabControl1.SelectedIndex = 0;
            this.cc_TabControl1.Size = new System.Drawing.Size(1346, 26);
            this.cc_TabControl1.TabIndex = 24;
            this.cc_TabControl1.SelectedIndexChanged += new System.EventHandler(this.cc_TabControl1_SelectedIndexChanged);
            this.cc_TabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cc_TabControl1_MouseDown);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1526, 1000);
            this.Controls.Add(this.cc_TabControl1);
            this.Controls.Add(this.Pnl_Top);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip2;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Flp_Side.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Pnl_Top.ResumeLayout(false);
            this.Pnl_Top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.FlowLayoutPanel Flp_Side;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Panel panel1;
      protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label Lbl_Position;
      private System.Windows.Forms.Label Lbl_Part;
      private System.Windows.Forms.Label Lbl_Id;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel Pnl_Top;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button Btn_Close;
        private Cc_TabControl cc_TabControl1;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCommon;
        private System.Windows.Forms.Button btnInspection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip2;
      private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnWorkOrder;
        private System.Windows.Forms.Button btnProductBOM;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnOperation;
        private System.Windows.Forms.Button btnProductOperationRel;
        private System.Windows.Forms.Button btnOperationInspectionRel;
        private System.Windows.Forms.Button btnFunctionUserGroup;
        private System.Windows.Forms.Button btnFuction_;
        private System.Windows.Forms.Button btnUserGroup;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnEquipment;
        private System.Windows.Forms.Button btnEquipmentOperationRel;
    }
}

