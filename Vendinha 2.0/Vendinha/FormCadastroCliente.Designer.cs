namespace Vendinha;

partial class FormCadastroCliente
{
    private TextBox txtNome;
    private TextBox txtCpf;
    private TextBox txtEmail;
    private DateTimePicker dtpDataNascimento;
    private Button btnSalvar;

    private void InitializeComponent()
    {
        txtNome = new TextBox();
        txtCpf = new TextBox();
        dtpDataNascimento = new DateTimePicker();
        txtEmail = new TextBox();
        btnSalvar = new Button();
        SuspendLayout();
        // 
        // txtNome
        // 
        txtNome.Location = new Point(23, 27);
        txtNome.Margin = new Padding(3, 4, 3, 4);
        txtNome.Name = "txtNome";
        txtNome.PlaceholderText = "Nome completo";
        txtNome.Size = new Size(571, 27);
        txtNome.TabIndex = 0;
        // 
        // txtCpf
        // 
        txtCpf.Location = new Point(23, 80);
        txtCpf.Margin = new Padding(3, 4, 3, 4);
        txtCpf.Name = "txtCpf";
        txtCpf.PlaceholderText = "CPF";
        txtCpf.Size = new Size(285, 27);
        txtCpf.TabIndex = 1;
        // 
        // dtpDataNascimento
        // 
        dtpDataNascimento.Location = new Point(23, 133);
        dtpDataNascimento.Margin = new Padding(3, 4, 3, 4);
        dtpDataNascimento.Name = "dtpDataNascimento";
        dtpDataNascimento.Size = new Size(285, 27);
        dtpDataNascimento.TabIndex = 2;
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(23, 187);
        txtEmail.Margin = new Padding(3, 4, 3, 4);
        txtEmail.Name = "txtEmail";
        txtEmail.PlaceholderText = "E-mail";
        txtEmail.Size = new Size(571, 27);
        txtEmail.TabIndex = 3;
        // 
        // btnSalvar
        // 
        btnSalvar.Location = new Point(509, 253);
        btnSalvar.Margin = new Padding(3, 4, 3, 4);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(86, 40);
        btnSalvar.TabIndex = 4;
        btnSalvar.Text = "Salvar";
        btnSalvar.UseVisualStyleBackColor = true;
        // 
        // FormCadastroCliente
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(629, 333);
        Controls.Add(txtNome);
        Controls.Add(txtCpf);
        Controls.Add(dtpDataNascimento);
        Controls.Add(txtEmail);
        Controls.Add(btnSalvar);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        Name = "FormCadastroCliente";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Novo Cliente";
        ResumeLayout(false);
        PerformLayout();
    }
}