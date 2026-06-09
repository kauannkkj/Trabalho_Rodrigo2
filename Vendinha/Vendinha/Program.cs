namespace Vendinha;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        
        using (var context = new Vendinha.Dados.VendinhaContext())
        {
            context.Database.EnsureCreated(); 
        }
        Application.Run(new Form1()); 
    }
}