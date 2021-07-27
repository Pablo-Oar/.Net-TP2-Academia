

using System.Windows.Forms;

namespace UI.Desktop
{
     public partial class ApplicationForm
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
            this.SuspendLayout();
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ApplicationForm";
            this.Text = "ApplicationForm";
            this.Load += new System.EventHandler(this.ApplicationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

//        public enum ModoForm
//        {
//            Alta,
//            Baja,
//            Modificacion,
//            Consulta
//        }

//        public ModoForm Modo
//        {
//            get
//            {
//                return _Modo;
//            }
//            set
//            {
//                _Modo = value;
//            }
//        }

//        public virtual void MapearDeDatos() { }
//        public virtual void MapearADatos() { }
//        public virtual void GuardarCambios() { }
//        public virtual bool Validar() { return false; }

//        public void Notificar(string titulo, string mensaje, MessageBoxButtons
//botones, MessageBoxIcon icono)
//        {
//            MessageBox.Show(mensaje, titulo, botones, icono);
//        }
//        public void Notificar(string mensaje, MessageBoxButtons botones,
//        MessageBoxIcon icono)
//        {
//            this.Notificar(this.Text, mensaje, botones, icono);
//        }
     }
}