namespace Vendinha;

partial class FormGerenciarDividas
{
    private Label lblCliente;
    private DataGridView dgvDividas;
    private NumericUpDown numValor;
    private Button btnPendurar, btnPagar, btnExcluirDivida;

    private void InitializeComponent()
    {
        lblCliente       = new Label();
        dgvDividas       = new DataGridView();
        numValor         = new NumericUpDown();
        btnPendurar      = new Button();
        btnPagar         = new Button();
        btnExcluirDivida = new Button();

        ((System.ComponentModel.ISupportInitialize)dgvDividas).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numValor).BeginInit();
        SuspendLayout();

        lblCliente.AutoSize = true;
        lblCliente.Font     = new Font("Segoe UI", 10, FontStyle.Bold);
        lblCliente.Location = new Point(12, 12);
        lblCliente.Name     = "lblCliente";
        lblCliente.Size     = new Size(300, 20);
        lblCliente.TabIndex = 0;
        lblCliente.Text     = "Cliente: ";

        dgvDividas.AllowUserToAddRows    = false;
        dgvDividas.AllowUserToDeleteRows = false;
        dgvDividas.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDividas.BackgroundColor       = Color.White;
        dgvDividas.BorderStyle           = BorderStyle.None;
        dgvDividas.Location              = new Point(12, 40);
        dgvDividas.MultiSelect           = false;
        dgvDividas.Name                  = "dgvDividas";
        dgvDividas.ReadOnly              = true;
        dgvDividas.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
        dgvDividas.Size                  = new Size(760, 200);
        dgvDividas.TabIndex              = 1;

        // Label valor
        var lblValor = new Label();
        lblValor.Text     = "Valor (R$):";
        lblValor.Location = new Point(12, 255);
        lblValor.AutoSize = true;

        numValor.Location      = new Point(12, 275);
        numValor.Name          = "numValor";
        numValor.Size          = new Size(150, 27);
        numValor.TabIndex      = 2;
        numValor.DecimalPlaces = 2;
        numValor.Minimum       = 0m;
        numValor.Maximum       = 9999.99m;
        numValor.Value         = 0m;

        btnPendurar.Location             = new Point(175, 272);
        btnPendurar.Name                 = "btnPendurar";
        btnPendurar.Size                 = new Size(130, 33);
        btnPendurar.TabIndex             = 3;
        btnPendurar.Text                 = "Pendurar Dívida";
        btnPendurar.UseVisualStyleBackColor = true;

        btnPagar.Location             = new Point(315, 272);
        btnPagar.Name                 = "btnPagar";
        btnPagar.Size                 = new Size(130, 33);
        btnPagar.TabIndex             = 4;
        btnPagar.Text                 = "Marcar como Paga";
        btnPagar.BackColor            = Color.FromArgb(40, 167, 69);
        btnPagar.ForeColor            = Color.White;
        btnPagar.UseVisualStyleBackColor = false;

        btnExcluirDivida.Location             = new Point(455, 272);
        btnExcluirDivida.Name                 = "btnExcluirDivida";
        btnExcluirDivida.Size                 = new Size(130, 33);
        btnExcluirDivida.TabIndex             = 5;
        btnExcluirDivida.Text                 = "Excluir Dívida";
        btnExcluirDivida.BackColor            = Color.FromArgb(220, 53, 69);
        btnExcluirDivida.ForeColor            = Color.White;
        btnExcluirDivida.UseVisualStyleBackColor = false;

        ClientSize = new Size(800, 325);
        Controls.Add(lblCliente);
        Controls.Add(dgvDividas);
        Controls.Add(lblValor);
        Controls.Add(numValor);
        Controls.Add(btnPendurar);
        Controls.Add(btnPagar);
        Controls.Add(btnExcluirDivida);

        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox     = false;
        StartPosition   = FormStartPosition.CenterScreen;
        Name            = "FormGerenciarDividas";
        Text            = "Gerenciar Dívidas do Cliente";

        ((System.ComponentModel.ISupportInitialize)dgvDividas).EndInit();
        ((System.ComponentModel.ISupportInitialize)numValor).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
