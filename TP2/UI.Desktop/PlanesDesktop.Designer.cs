
namespace UI.Desktop
{
    partial class PlanesDesktop
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
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.lblDesc_Plan = new System.Windows.Forms.Label();
            this.lblIdEspecialidad = new System.Windows.Forms.Label();
            this.txtIDPlan = new System.Windows.Forms.TextBox();
            this.txtDescPlan = new System.Windows.Forms.TextBox();
            this.txtIDEspecialidad = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.AutoSize = true;
            this.lblIdPlan.Location = new System.Drawing.Point(38, 44);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(48, 13);
            this.lblIdPlan.TabIndex = 0;
            this.lblIdPlan.Text = "ID Plan: ";
            // 
            // lblDesc_Plan
            // 
            this.lblDesc_Plan.AutoSize = true;
            this.lblDesc_Plan.Location = new System.Drawing.Point(38, 77);
            this.lblDesc_Plan.Name = "lblDesc_Plan";
            this.lblDesc_Plan.Size = new System.Drawing.Size(93, 13);
            this.lblDesc_Plan.TabIndex = 1;
            this.lblDesc_Plan.Text = "Descripcion Plan: ";
            // 
            // lblIdEspecialidad
            // 
            this.lblIdEspecialidad.AutoSize = true;
            this.lblIdEspecialidad.Location = new System.Drawing.Point(38, 112);
            this.lblIdEspecialidad.Name = "lblIdEspecialidad";
            this.lblIdEspecialidad.Size = new System.Drawing.Size(87, 13);
            this.lblIdEspecialidad.TabIndex = 2;
            this.lblIdEspecialidad.Text = "ID Especialidad: ";
            // 
            // txtIDPlan
            // 
            this.txtIDPlan.Location = new System.Drawing.Point(137, 37);
            this.txtIDPlan.Name = "txtIDPlan";
            this.txtIDPlan.Size = new System.Drawing.Size(100, 20);
            this.txtIDPlan.TabIndex = 3;
            // 
            // txtDescPlan
            // 
            this.txtDescPlan.Location = new System.Drawing.Point(137, 70);
            this.txtDescPlan.Name = "txtDescPlan";
            this.txtDescPlan.Size = new System.Drawing.Size(100, 20);
            this.txtDescPlan.TabIndex = 4;
            // 
            // txtIDEspecialidad
            // 
            this.txtIDEspecialidad.Location = new System.Drawing.Point(137, 105);
            this.txtIDEspecialidad.Name = "txtIDEspecialidad";
            this.txtIDEspecialidad.Size = new System.Drawing.Size(100, 20);
            this.txtIDEspecialidad.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(56, 164);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(149, 164);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // PlanesDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 218);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtIDEspecialidad);
            this.Controls.Add(this.txtDescPlan);
            this.Controls.Add(this.txtIDPlan);
            this.Controls.Add(this.lblIdEspecialidad);
            this.Controls.Add(this.lblDesc_Plan);
            this.Controls.Add(this.lblIdPlan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlanesDesktop";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlanesDesktop";
            this.Load += new System.EventHandler(this.PlanesDesktop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.Label lblDesc_Plan;
        private System.Windows.Forms.Label lblIdEspecialidad;
        private System.Windows.Forms.TextBox txtIDPlan;
        private System.Windows.Forms.TextBox txtDescPlan;
        private System.Windows.Forms.TextBox txtIDEspecialidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}