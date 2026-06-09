namespace Vendinha;

partial class Form1
{
    private void InitializeComponent()
    {
        txtBusca = new TextBox();
        btnNovoCliente = new Button();
        dgvClientes = new DataGridView();
        btnExcluir = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
        SuspendLayout();
        // 
        // txtBusca
        // 
        txtBusca.Location = new Point(14, 20);
        txtBusca.Margin = new Padding(3, 4, 3, 4);
        txtBusca.Name = "txtBusca";
        txtBusca.PlaceholderText = "Digite o nome do cliente para buscar...";
        txtBusca.Size = new Size(799, 27);
        txtBusca.TabIndex = 0;
        // 
        // btnNovoCliente
        // 
        btnNovoCliente.Location = new Point(823, 16);
        btnNovoCliente.Margin = new Padding(3, 4, 3, 4);
        btnNovoCliente.Name = "btnNovoCliente";
        btnNovoCliente.Size = new Size(171, 40);
        btnNovoCliente.TabIndex = 1;
        btnNovoCliente.Text = "Novo Cliente";
        btnNovoCliente.UseVisualStyleBackColor = true;
        // 
        // dgvClientes
        // 
        dgvClientes.AllowUserToAddRows = false;
        dgvClientes.AllowUserToDeleteRows = false;
        dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClientes.BackgroundColor = Color.White;
        dgvClientes.BorderStyle = BorderStyle.None;
        dgvClientes.ColumnHeadersHeight = 29;
        dgvClientes.Location = new Point(14, 73);
        dgvClientes.Margin = new Padding(3, 4, 3, 4);
        dgvClientes.MultiSelect = false;
        dgvClientes.Name = "dgvClientes";
        dgvClientes.ReadOnly = true;
        dgvClientes.RowHeadersWidth = 51;
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClientes.Size = new Size(983, 520);
        dgvClientes.TabIndex = 2;
        // 
        // btnExcluir
        // 
        btnExcluir.Location = new Point(904, 553);
        btnExcluir.Name = "btnExcluir";
        btnExcluir.Size = new Size(94, 40);
        btnExcluir.TabIndex = 6;
        btnExcluir.Text = "Excluir";
        btnExcluir.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1010, 615);
        Controls.Add(btnExcluir);
        Controls.Add(dgvClientes);
        Controls.Add(btnNovoCliente);
        Controls.Add(txtBusca);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Vendinha Plena - Controle de Contas";
        ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private TextBox txtBusca;
    private DataGridView dgvClientes;
    private Button btnNovoCliente;
    private Button btnExcluir;
}